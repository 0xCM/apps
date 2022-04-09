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
        public static DisasmDetailDoc CalcDisasmDetail(WsContext context, in DisasmFile file, DisasmSummaryDoc summary)
        {
            var dst = bag<DetailBlock>();
            CalcDisasmDetail(context, summary, file, dst).Require();
            return DisasmDetailDoc.from(file, dst.ToArray().Sort());
        }

        static Outcome CalcDisasmDetail(WsContext context, DisasmSummaryDoc doc, in DisasmFile src, ConcurrentBag<DetailBlock> dst)
        {
            var blocks = doc.Blocks;
            var count = blocks.Count;
            var result = Outcome.Success;
            if(result.Fail)
                return result;

            if(doc.RowCount != count)
            {
                result = (false, string.Format("{0} != {1}", count, doc.RowCount));
                return result;
            }

            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref blocks[i];
                dst.Add(new (CalcDisasmDetail(block), block));
            }

            return result;
        }

        static DisasmDetail CalcDisasmDetail(in DisasmBlock block)
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
            dst.InstForm = inst.Form;
            dst.InstClass = inst.Class;
            dst.SourceName = text.remove(summary.Source.Path.FileName.Format(), "." + FileKindNames.xeddisasm_raw);
            DisasmParse.parse(inst.Props, out DisasmState dstate);
            var ops = XedState.ops(dstate, code);

            ref readonly var state = ref dstate.RuleState;
            dst.Offsets = XedState.offsets(state);
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
                result = DisasmParse.parse(skip(lines.Ops, k).Content, out operand.OpInfo);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var info = operand.OpInfo;
                var winfo = XedLookups.Service.WidthInfo(info.WidthCode);
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

            var has_rex = XedState.rex(state, out var _rex);
            if(has_rex)
                dst.Rex = _rex;

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