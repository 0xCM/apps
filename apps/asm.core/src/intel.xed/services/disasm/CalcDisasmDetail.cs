//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedDisasmSvc
    {
        Outcome CalcDisasmDetail(in DisasmLineBlock block, in AsmDisasmSummary summary, out DisasmDetail dst)
        {
            dst = default;
            var result = ParseInstruction(block, out var inst);
            if(result.Fail)
            {
                dst = default;
                return result;
            }

            ref readonly var code = ref summary.Encoded;
            dst.Seq = summary.Seq;
            dst.DocSeq = summary.DocSeq;
            dst.OriginId = summary.OriginId;
            dst.OriginName = summary.OriginName;
            dst.EncodingId = summary.EncodingId;
            dst.InstructionId = AsmBytes.instid(summary.OriginId, summary.IP, code.Bytes);
            dst.IP = summary.IP;
            dst.Encoded = summary.Encoded;
            dst.Asm = summary.Asm;
            dst.IForm = inst.Form;
            dst.SourceName = text.remove(summary.Source.Path.FileName.Format(), "." + FileKindNames.xeddisasm_raw);

            var parser = new FieldParser();
            parser.ParseState(inst.Props.Edit, out var state);
            var machine = RuleMachine.create(state);

            dst.Offsets = machine.Offsets();
            dst.OpCode = state.NOMINAL_OPCODE;
            dst.Operands = alloc<DisasmOpDetail>(block.OperandCount);

            var ocpos = state.POS_NOMINAL_OPCODE;
            var ocsrm = math.and((byte)state.SRM, state.NOMINAL_OPCODE);
            Require.equal(state.SRM, ocsrm);

            if(state.NOMINAL_OPCODE != code[ocpos])
                return (false, string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", state.NOMINAL_OPCODE, state.MODRM_BYTE));

            var ruleops = machine.Operands(code);
            var opcount = dst.Operands.Count;
            for(var k=0; k<opcount; k++)
            {
                ref readonly var opsrc = ref skip(block.Operands, k);
                result = parser.ParseDisasmOperand(opsrc.Content, out var op);
                if(result.Fail)
                    break;

                ref var opdetail = ref dst.Operands[k];
                opdetail.Def = op;

                var title = string.Format("Op{0}", k);
                var opwidth = OperandWidth(op.WidthType);
                opdetail.Width = opwidth;
                var indicator = opwidth.Name;
                var width = opwidth.Width64;
                var widthdesc = string.Format("{0}:{1}", opwidth.Name, opwidth.Width64);
                var opname = XedRules.opname(op.Kind);
                opdetail.RuleOpName = opname;
                var opval = RuleOperand.Empty;
                var opvalfmt = EmptyString;
                if(ruleops.TryGetValue(opname, out opval))
                {
                    opdetail.Rule = opval;
                    opvalfmt = opval.Format();
                    if(opname == RuleOpName.RELBR)
                    {
                        var w = state.BRDISP_WIDTH;
                        var val = (Disp)opval.Value;
                        opvalfmt = val.Format();
                    }
                    opdetail.RuleDescription = opvalfmt;
                }

                opdetail.DefDescription = string.Format(DisasmOpDetails.RenderPattern, title, opname, opvalfmt, op.Action, op.Visiblity, width, indicator, op.Prop2);
            }

            if(ruleops.TryGetValue(RuleOpName.DISP, out var disp))
                dst.Disp = (Disp)disp.Value;

            var prefix = ocpos != 0 ? slice(code.Bytes,0,ocpos) : default;
            dst.PSZ = (byte)prefix.Length;

            var legacyskip = z8;
            for(var k=0; k<prefix.Length; k++)
            {
                ref readonly var b = ref skip(prefix,k);
                if(AsmPrefixTests.opsz(b))
                {
                    dst.SZOV = AsmPrefix.opsz();
                    legacyskip++;
                }
                else if(AsmPrefixTests.adsz(b))
                {
                    dst.SZOV = AsmPrefix.adsz();
                    legacyskip++;
                }
            }

            var has_rex = rex(state, out var _rex);
            if(has_rex)
                dst.Rex = _rex;

            var has_modrm = modrm(state, out var _modrm);
            if(has_modrm)
            {
                dst.ModRm = _modrm;
                if(_modrm != state.MODRM_BYTE)
                {
                    result = (false, string.Format("Derived RM value {0} differs from parsed value {1}", _modrm, state.MODRM_BYTE));
                    return result;
                }

                if(_modrm != code[state.POS_MODRM])
                {
                    result = (false, string.Format("Derived RM value {0} differs from encoded value {1}", _modrm, code[state.POS_MODRM]));
                    return result;
                }
            }

            var has_sib = sib(state, out var _sib);
            if(has_sib)
            {
                dst.Sib = _sib;
                var sibenc = Sib.init(code[state.POS_SIB]);
                if(sibenc.Value() != _sib)
                {
                    result = (false, string.Format("Derived Sib value {0} differs from encoded value {1}", _sib, sibenc));
                    return result;
                }
            }

            if(state.VEXVALID == (byte)VexKind.VV1)
            {
                var vexcode = VexPrefix.code(prefix);
                var vexsize = VexPrefix.size(vexcode.Value);
                var vexbytes = slice(prefix, vexcode.Offset, vexsize);
                var vexdest = (uint5)((uint3)state.VEXDEST210 | (byte)state.VEXDEST3 << 3 | (byte)state.VEXDEST4 << 4);
                Require.equal(vexbytes.Length, vexsize);

                if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C4)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC4,skip(vexbytes, 1), skip(vexbytes,2));
                else if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C5)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC5,skip(vexbytes, 1));

            }
            else if(state.VEXVALID == (byte)VexKind.EVV)
                dst.Evex = EvexPrefix.define(slice(prefix,legacyskip));

            if(state.IMM0)
                dst.Imm = asm.imm(code, state.POS_IMM, state.IMM0SIGNED, Sizes.native(state.IMM_WIDTH));

            dst.EASZ = Sizes.native(width((EASZ)state.EASZ));
            dst.EOSZ = Sizes.native(width((EOSZ)state.EOSZ));

            var flags = machine.Flags().Delimit();
            return result;
        }

        Outcome ParseInstruction(in DisasmLineBlock block, out DisasmInstruction inst)
        {
            var result = Outcome.Success;
            inst = default(DisasmInstruction);
            ref readonly var content = ref block.Instruction.Content;
            if(text.nonempty(content))
            {
                var j = text.index(content, Chars.Space);
                if(j > 0)
                {
                    var expr = text.left(content,j);
                    if(Classes.Lookup(expr, out var @class))
                        inst.Class = @class;
                    else
                    {
                        result = (false, AppMsg.ParseFailure.Format(nameof(IClass), content));
                        return result;
                    }

                    var k = text.index(content, j+1, Chars.Space);
                    if(k > 0)
                    {
                        expr = text.inside(content, j, k);
                        if(Forms.Lookup(expr, out var form))
                            inst.Form = form;
                        else
                        {
                            result = (false, AppMsg.ParseFailure.Format(nameof(IFormType), expr));
                            return result;
                        }
                    }

                    var props = text.words(text.right(content,k), Chars.Comma);
                    var kP = props.Count;
                    inst.Props = alloc<Facet<string>>(kP);
                    for(var m=0; m<kP; m++)
                    {
                        ref readonly var p = ref props[m];
                        if(p.Contains(Chars.Colon))
                        {
                            var kv = text.split(p, Chars.Colon);
                            if(kv.Length == 2)
                                inst.Props[m] = (skip(kv,0).Trim(), skip(kv,1).Trim());
                        }
                        else
                        {
                            inst.Props[m] = (p.Trim(), EmptyString);
                        }
                    }
                }
            }
            return result;
        }

    }
}