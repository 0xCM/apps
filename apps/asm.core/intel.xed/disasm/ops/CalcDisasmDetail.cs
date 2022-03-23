//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRules;
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        // public const string OpDetailRenderPattern = "{0,-4} | {1,-8} | {2,-24} | {3,-10} | {4,-12} | {5,-12} | {6,-12} | {7,-12}";

        // static string[] OpColPatterns = new string[]{"Op{0}", "Op{0}Name", "Op{0}Val", "Op{0}Action", "Op{0}Vis", "Op{0}Width", "Op{0}WKind", "Op{0}Selector"};

        // public static string OpDetailHeader(int index)
        //     => string.Format(OpDetailRenderPattern, OpColPatterns.Select(x => string.Format(x, index)));

        Outcome CalcDisasmDetail(in DisasmLineBlock block, in AsmDisasmSummary summary, out DisasmDetail dst)
        {
            dst = default;
            var result = CalcInstruction(block, out var inst);
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
            dst.Mnemonic = inst.Class;
            dst.SourceName = text.remove(summary.Source.Path.FileName.Format(), "." + FileKindNames.xeddisasm_raw);

            XedDisasm.parse(inst.Props.Edit, out DisasmState state);
            ref readonly var rules = ref state.RuleState;
            dst.Offsets = XedRules.positions(rules);
            dst.OpCode = rules.NOMINAL_OPCODE;
            dst.Operands = alloc<DisasmOpDetail>(block.OperandCount);

            var ocpos = rules.POS_NOMINAL_OPCODE;
            var ocsrm = math.and((byte)rules.SRM, rules.NOMINAL_OPCODE);
            Require.equal(rules.SRM, ocsrm);

            if(rules.NOMINAL_OPCODE != code[ocpos])
                return (false, string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", rules.NOMINAL_OPCODE, rules.MODRM_BYTE));

            var ops = CalcDisasmOps(rules, code);
            for(var k=0; k<block.OperandCount; k++)
            {
                ref var operand = ref dst.Operands[k];
                ref readonly var opsrc = ref skip(block.Operands, k);
                result = XedDisasm.opinfo(opsrc.Content, out operand.OpInfo);
                if(result.Fail)
                    break;

                var info = operand.OpInfo;
                var winfo = OperandWidth(info.WidthCode);
                operand.OpWidth = winfo;
                var opname = XedRules.opname(info.Kind);
                operand.OpName = opname;
                var optxt = EmptyString;
                if(ops.TryGetValue(opname, out var opval))
                {
                    operand.Def = opval;
                    optxt = opval.Format();
                    operand.RuleDescription = optxt;
                }

                operand.DefDescription = string.Format(OpDetailRenderPattern,
                    string.Format("Op{0}", k),
                    opname,
                    optxt,
                    info.Action,
                    info.Visiblity,
                    winfo.Width64,
                    winfo.Name,
                    info.Selector
                    );
            }

            if(ops.TryGetValue(OpName.DISP, out var disp))
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

            if(rules.VEXVALID == (byte)VexClass.VV1)
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
            else if(rules.VEXVALID == (byte)VexClass.EVV)
                dst.Evex = AsmPrefix.evex(slice(prefix,legacyskip));

            if(rules.IMM0)
                dst.Imm = asm.imm(code, rules.POS_IMM, rules.IMM0SIGNED, Sizes.native(rules.IMM_WIDTH));

            dst.EASZ = Sizes.native(bitwidth((EASZ)rules.EASZ));
            dst.EOSZ = Sizes.native(bitwidth((EOSZ)rules.EOSZ));
            return result;
        }
    }
}