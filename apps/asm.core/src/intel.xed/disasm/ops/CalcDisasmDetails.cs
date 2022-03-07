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

    using N = XedRules.RuleOpName;

    partial class XedDisasmSvc
    {
        Outcome CalcDisasmDetails(WsContext context, in DisasmFileBlocks src, ConcurrentBag<DisasmDetail> buffer)
        {
            var blocks = src.LineBlocks;
            var count = blocks.Count;
            var result = XedDisasmOps.ParseSummaries(context, src.Source, out var summaries);
            if(result.Fail)
                return result;

            if(summaries.RowCount != count)
            {
                result = (false, string.Format("{0} != {1}", count, summaries.RowCount));
                return result;
            }

            for(var i=0u; i<count; i++)
            {
                ref readonly var block = ref blocks[i];
                ref readonly var encoding =ref summaries[i];
                var detail = DisasmDetail.Empty;
                result = CalcDisasmDetail(block, encoding, out detail);
                if(result.Fail)
                    break;
                else
                    buffer.Add(detail);
            }

            return result;
        }

        static DisasmOps CalcDisasmOps(RuleMachine machine, in AsmHexCode code, in DisasmState state)
        {
            ref readonly var rules = ref state.RuleState;

            var ops = list<DisasmOp>();

            if(rules.DISP_WIDTH != 0)
                ops.Add(new DisasmOp(N.DISP, disp(rules, code)));

            if(rules.BRDISP_WIDTH != 0)
                ops.Add(new DisasmOp(N.RELBR, (Disp)state.RELBRVal));
            else if(state.RELBRVal.IsNonZero)
                ops.Add(new DisasmOp(N.RELBR, rules.RELBRVal));

            if(state.MEM0Val.IsNonEmpty)
                ops.Add(new DisasmOp(N.MEM0, state.MEM0Val));
            else if(state.MEM0Val.IsNonEmpty)
                ops.Add(new DisasmOp(N.MEM0, rules.MEM0Val));

            if(state.MEM1Val.IsNonEmpty)
                ops.Add(new DisasmOp(N.MEM1, state.MEM1Val));
            else if(rules.MEM1Val.IsNonEmpty)
                ops.Add(new DisasmOp(N.MEM1, rules.MEM1Val));

            if(state.AGENVal.IsNonEmpty)
                ops.Add(new DisasmOp(N.AGEN, state.AGENVal));
            else if(state.AGENVal.IsNonEmpty)
                ops.Add(new DisasmOp(N.AGEN, rules.AGENVal));

            var dst = map(ops, o => (o.Name, o)).ToDictionary();
            iter(machine.RuleOps(code).Values, o => dst.TryAdd(o.Name, convert(o)));
            return dst;
        }

        [MethodImpl(Inline)]
        static DisasmOp convert(RuleOp src)
        {
            var dst =default(DisasmOp);
            dst.Name = src.Name;
            dst.Value = src.Value;
            return dst;
        }

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

            var parser = new DisasmFieldParser();
            parser.ParseState(inst.Props.Edit, out var state);
            ref readonly var rules = ref state.RuleState;
            var machine = RuleMachine.create(rules);

            dst.Offsets = machine.Offsets();
            dst.OpCode = rules.NOMINAL_OPCODE;
            dst.OpDetails = alloc<DisasmOpDetail>(block.OperandCount);

            var ocpos = rules.POS_NOMINAL_OPCODE;
            var ocsrm = math.and((byte)rules.SRM, rules.NOMINAL_OPCODE);
            Require.equal(rules.SRM, ocsrm);

            if(rules.NOMINAL_OPCODE != code[ocpos])
                return (false, string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", rules.NOMINAL_OPCODE, rules.MODRM_BYTE));

            var ops = CalcDisasmOps(machine, code, state);
            var opcount = block.OperandCount;
            for(var k=0; k<opcount; k++)
            {
                ref readonly var opsrc = ref skip(block.Operands, k);
                result = ParseOpInfo(opsrc.Content, out var info);
                if(result.Fail)
                    break;

                ref var opdetail = ref dst.OpDetails[k];
                opdetail.OpInfo = info;

                var title = string.Format("Op{0}", k);
                var opwidth = OperandWidth(info.WidthType);
                opdetail.OpWidth = opwidth;
                var indicator = opwidth.Name;
                var width = opwidth.Width64;
                var widthdesc = string.Format("{0}:{1}", opwidth.Name, opwidth.Width64);
                var opname = XedRules.opname(info.Kind);
                opdetail.OpName = opname;
                var optxt = EmptyString;
                if(ops.TryGetValue(opname, out var opval))
                {
                    opdetail.Def = opval;
                    optxt = opval.Format();
                    opdetail.RuleDescription = optxt;
                }

                opdetail.DefDescription = string.Format(DisasmOpDetails.RenderPattern, title, opname, optxt, info.Action, info.Visiblity, width, indicator, info.Prop2);
            }

            if(ops.TryGetValue(RuleOpName.DISP, out var disp))
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

            var has_rex = rex(rules, out var _rex);
            if(has_rex)
                dst.Rex = _rex;

            var has_modrm = modrm(rules, out var _modrm);
            if(has_modrm)
            {
                dst.ModRm = _modrm;
                if(_modrm != rules.MODRM_BYTE)
                {
                    result = (false, string.Format("Derived RM value {0} differs from parsed value {1}", _modrm, rules.MODRM_BYTE));
                    return result;
                }

                if(_modrm != code[rules.POS_MODRM])
                {
                    result = (false, string.Format("Derived RM value {0} differs from encoded value {1}", _modrm, code[rules.POS_MODRM]));
                    return result;
                }
            }

            var has_sib = sib(rules, out var _sib);
            if(has_sib)
            {
                dst.Sib = _sib;
                var sibenc = Sib.init(code[rules.POS_SIB]);
                if(sibenc.Value() != _sib)
                {
                    result = (false, string.Format("Derived Sib value {0} differs from encoded value {1}", _sib, sibenc));
                    return result;
                }
            }

            if(rules.VEXVALID == (byte)VexKind.VV1)
            {
                var vexcode = VexPrefix.code(prefix);
                var vexsize = VexPrefix.size(vexcode.Value);
                var vexbytes = slice(prefix, vexcode.Offset, vexsize);
                var vexdest = (uint5)((uint3)rules.VEXDEST210 | (byte)rules.VEXDEST3 << 3 | (byte)rules.VEXDEST4 << 4);
                Require.equal(vexbytes.Length, vexsize);

                if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C4)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC4,skip(vexbytes, 1), skip(vexbytes,2));
                else if(vexcode.Value == AsmPrefixCodes.VexPrefixCode.C5)
                    dst.Vex = VexPrefix.define(AsmPrefixCodes.VexPrefixKind.xC5,skip(vexbytes, 1));

            }
            else if(rules.VEXVALID == (byte)VexKind.EVV)
                dst.Evex = EvexPrefix.define(slice(prefix,legacyskip));

            if(rules.IMM0)
                dst.Imm = asm.imm(code, rules.POS_IMM, rules.IMM0SIGNED, Sizes.native(rules.IMM_WIDTH));

            dst.EASZ = Sizes.native(width((EASZ)rules.EASZ));
            dst.EOSZ = Sizes.native(width((EOSZ)rules.EOSZ));

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