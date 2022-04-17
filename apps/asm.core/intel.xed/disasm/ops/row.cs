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

    partial class XedDisasm
    {
        static Dictionary<OpNameKind,DisasmOp> ops(in DisasmState state, in AsmHexCode code)
        {
            var dst = dict<OpNameKind,DisasmOp>();
            var values = XedState.Code.ops(state.RuleState, code);
            var count = values.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var value = ref values[i];
                dst.TryAdd(value.Name, new DisasmOp(value));
            }

            if(state.RELBRVal.IsNonZero)
                dst[OpNameKind.RELBR] = new DisasmOp(OpNameKind.RELBR, state.RELBRVal);
            if(state.MEM0Val.IsNonEmpty)
                dst[OpNameKind.MEM0] = new DisasmOp(OpNameKind.MEM0, state.MEM0Val);
            if(state.MEM1Val.IsNonEmpty)
                dst[OpNameKind.MEM1] = new DisasmOp(OpNameKind.MEM1, state.MEM1Val);
            if(state.AGENVal.IsNonEmpty)
                dst[OpNameKind.AGEN] = new DisasmOp(OpNameKind.AGEN, state.AGENVal);
            return dst;
        }

        static DetailBlockRow row(in DisasmSummaryLines src)
        {
            ref readonly var lines = ref src.Lines;
            ref readonly var summary = ref src.Summary;
            ref readonly var code = ref summary.Encoded;
            var inst = DisasmInstruction.Empty;
            var result = DisasmParse.parse(lines, out inst);
            if(result.Fail)
                Errors.Throw(result.Message);

            var dst = DetailBlockRow.Empty;
            dst.Seq = summary.Seq;
            dst.DocSeq = summary.DocSeq;
            dst.OriginId = summary.OriginId;
            dst.OriginName = summary.OriginName;
            dst.EncodingId = summary.EncodingId;
            dst.InstructionId = AsmBytes.instid(summary.OriginId, summary.IP, code.Bytes);
            dst.IP = summary.IP;
            dst.Encoded = summary.Encoded;
            dst.Asm = summary.Asm;
            dst.InstForm = inst.Form;
            dst.InstClass = inst.Class;
            dst.SourceName = text.remove(summary.Source.Path.FileName.Format(), "." + FileKindNames.xeddisasm_raw);
            DisasmParse.parse(inst.Props, out DisasmState dstate);
            var ops = XedDisasm.ops(dstate, code);
            ref readonly var state = ref dstate.RuleState;
            dst.Offsets = XedState.Code.offsets(state);
            dst.OpCode = state.NOMINAL_OPCODE;
            dst.Ops = alloc<DisasmOpDetail>(lines.OpCount);

            var ocpos = state.POS_NOMINAL_OPCODE;
            var opcode = state.NOMINAL_OPCODE;
            var ocsrm = math.and((byte)state.SRM, opcode);
            Require.equal(state.SRM, ocsrm);

            if(opcode != code[ocpos])
                Errors.Throw(string.Format("Extracted opcode value {0} differs from parsed opcode value {1}", state.NOMINAL_OPCODE, state.MODRM_BYTE));

            for(var k=0; k<lines.OpCount; k++)
            {
                ref var operand = ref dst.Ops[k];
                result = XedParsers.parse(skip(lines.Ops, k).Content, out operand.OpClass);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var info = operand.OpClass;
                var winfo = XedWidths.describe(info.WidthCode);
                operand.Index = (byte)operand.OpClass.Index;
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

                operand.DefDescription = string.Format(DisasmRender.OpDetailPattern,
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

            if(ops.TryGetValue(OpNameKind.DISP, out var disp))
                dst.Disp = (Disp)disp;

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

            if(state.REX)
                dst.Rex = XedState.rex(state);

            if(state.HAS_MODRM)
            {
                var modrm = XedState.modrm(state);
                dst.ModRm = modrm;
                if(modrm != code[state.POS_MODRM])
                {
                    var msg = string.Format("Derived ModRM value {0} differs from encoded value {1}", modrm, code[state.POS_MODRM]);
                    Errors.Throw(msg);
                }
            }

            if(state.HAS_SIB)
            {
                var sib = XedState.sib(state);
                dst.Sib = sib;
                var sibenc = Sib.init(code[state.POS_SIB]);
                if(sibenc.Value() != sib)
                {
                    var msg = string.Format("Derived Sib value {0} differs from encoded value {1}", sib, sibenc);
                    Errors.Throw(msg);
                }
            }

            if(state.VEXVALID == (byte)VexClass.VV1)
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
            else if(state.VEXVALID == (byte)VexClass.EVV)
                dst.Evex = AsmPrefix.evex(slice(prefix,legacyskip));

            if(state.IMM0)
                dst.Imm = asm.imm(code, state.POS_IMM, state.IMM0SIGNED, Sizes.native(state.IMM_WIDTH));

            dst.EASZ = Sizes.native(XedPatterns.bitwidth((EASZ)state.EASZ));
            dst.EOSZ = Sizes.native(XedPatterns.bitwidth((EOSZ)state.EOSZ));
            return dst;
        }
    }
}