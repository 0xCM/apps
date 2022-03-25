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
        DisasmDetail CalcDisasmDetail(in DisasmBlock block)
        {
            ref readonly var lines = ref block.Lines;
            ref readonly var summary = ref block.Summary;
            ref readonly var code = ref summary.Encoded;
            var result = CalcInstruction(lines, out var inst);
            if(result.Fail)
                Errors.Throw(result.Message);

            var dst = DisasmDetail.Empty;
            dst.Seq = summary.Seq;
            dst.DocSeq = summary.DocSeq;
            dst.OriginId = summary.OriginId;
            dst.OriginName = summary.OriginName;
            dst.EncodingId = summary.EncodingId;
            dst.InstructionId = AsmBytes.instid(summary.OriginId, summary.IP, code.Bytes);
            dst.IP = summary.IP;
            dst.Encoded = summary.Encoded;
            dst.Asm = summary.Asm;
            dst.InstForm = inst.InstForm;
            dst.InstClass = inst.InstClass;
            dst.SourceName = text.remove(summary.Source.Path.FileName.Format(), "." + FileKindNames.xeddisasm_raw);
            result = XedDisasm.parse(inst.Props.Edit, out DisasmState state);
            ref readonly var rules = ref state.RuleState;
            dst.Offsets = XedFields.positions(rules);
            dst.OpCode = rules.NOMINAL_OPCODE;
            dst.Operands = alloc<DisasmOpDetail>(lines.OperandCount);

            var ocpos = rules.POS_NOMINAL_OPCODE;
            var opcode = rules.NOMINAL_OPCODE;
            var ocsrm = math.and((byte)rules.SRM, opcode);
            Require.equal(rules.SRM, ocsrm);

            if(opcode != code[ocpos])
            {
                var msg = string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", rules.NOMINAL_OPCODE, rules.MODRM_BYTE);
                Errors.Throw(msg);
            }

            var ops = XedDisasm.ops(rules, code);
            for(var k=0; k<lines.OperandCount; k++)
            {
                ref var operand = ref dst.Operands[k];
                ref readonly var opsrc = ref skip(lines.Operands, k);
                result = XedDisasm.parse(opsrc.Content, out operand.OpInfo);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var info = operand.OpInfo;
                var winfo = XedTables.WidthInfo(info.WidthCode);
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

            var has_rex = XedFields.rex(rules, out var _rex);
            if(has_rex)
                dst.Rex = _rex;

            if(rules.HAS_MODRM)
            {
                var modrm = XedFields.modrm(rules);
                dst.ModRm = XedFields.modrm(rules);
                if(modrm != code[rules.POS_MODRM])
                {
                    var msg = string.Format("Derived ModRM value {0} differs from encoded value {1}", modrm, code[rules.POS_MODRM]);
                    Errors.Throw(msg);
                }
            }

            if(rules.HAS_SIB)
            {
                var sib = XedFields.sib(rules);
                dst.Sib = sib;
                var sibenc = Sib.init(code[rules.POS_SIB]);
                if(sibenc.Value() != sib)
                {
                    var msg = string.Format("Derived Sib value {0} differs from encoded value {1}", sib, sibenc);
                    Errors.Throw(msg);
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
            return dst;
        }
    }
}