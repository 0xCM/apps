//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedDisasm;

    using K = XedRules.FieldKind;

    partial class XedDisasmSvc
    {
        void EmitDisasmChecks(WsContext context, DisasmDetailDoc doc)
        {
            const string RenderPattern = "{0,-24} | {1}";
            ref readonly var file = ref doc.File;
            var emitted = hashset<FieldKind>(
                    K.MODE,
                    K.OSZ, K.ASZ, K.EASZ, K.EOSZ, K.PREFIX66, K.DF32, K.DF64,
                    K.NPREFIXES, K.NSEG_PREFIXES, K.HINT, K.REP,
                    K.REXW, K.REXR, K.REXX, K.REXB, K.REX, K.NREXES,
                    K.VEXVALID, K.VEX_PREFIX, K.VEXDEST210, K.VEXDEST3, K.VEXDEST4,
                    K.MAP, K.NOMINAL_OPCODE, K.SRM,
                    K.OUTREG, K.REG0, K.REG1, K.REG2, K.REG3, K.REG4, K.REG5, K.REG6, K.REG7, K.REG8, K.REG9,
                    K.ELEMENT_SIZE, K.VL, K.NELEM,
                    K.MODRM_BYTE, K.HAS_MODRM, K.MOD, K.REG, K.RM,
                    K.HAS_SIB, K.SIBBASE, K.SIBINDEX, K.SIBSCALE,
                    K.DISP_WIDTH, K.DISP,
                    K.IMM0, K.IMM0SIGNED, K.IMM_WIDTH,
                    K.IMM1, K.IMM1_BYTES,
                    K.MASK, K.BCAST,
                    K.ROUNDC, K.SAE, K.ZEROING, K.LLRC, K.BCRC, K.ESRC,
                    K.POS_IMM, K.POS_IMM1, K.POS_DISP, K.POS_SIB, K.POS_NOMINAL_OPCODE, K.POS_MODRM,
                    K.MEM0, K.MEM1, K.UBIT, K.NEED_MEMDISP,
                    K.MAX_BYTES, K.LZCNT, K.TZCNT, K.USING_DEFAULT_SEGMENT0, K.SMODE, K.P4
                    );

            var buffer = text.buffer();
            var count = doc.RowCount;
            var dstpath = DisasmChecksPath(context,file.Source);
            using var writer = dstpath.AsciWriter();
            var emitting = EmittingFile(dstpath);
            var counter = 0;
            for(var j=0; j<count; j++)
            {
                var state = RuleState.Empty;
                buffer.Clear();

                ref readonly var detail = ref doc[j].Detail;
                ref readonly var ops = ref detail.Ops;
                ref readonly var block = ref doc[j].Block;
                ref readonly var summary = ref block.Summary;
                ref readonly var lines = ref block.Lines;
                ref readonly var asmhex = ref summary.Encoded;
                ref readonly var asmtxt = ref summary.Asm;
                ref readonly var ip = ref summary.IP;

                var cells = XedDisasm.update(lines, ref state);
                var ocindex = XedState.ocindex(state);
                var ockind = XedPatterns.ockind(ocindex);
                var encoding  = XedState.encoding(state, asmhex);
                var ocbyte = XedState.ocbyte(state);
                var ochex = XedRender.format(ocbyte);
                var ocbits = BitRender.format8x4(ocbyte);

                writer.WriteLine(RP.PageBreak240);
                writer.AppendLine(lines.Format());
                writer.WriteLine(RP.PageBreak80);

                writer.AppendLineFormat(RenderPattern, nameof(IClass), detail.InstClass);
                writer.AppendLineFormat(RenderPattern, "IFORM", detail.InstForm);
                writer.AppendLineFormat("{0,-24} | {1,-5} {2}", asmhex, ip, asmtxt);
                writer.AppendLineFormat(RenderPattern, "OcMap", ockind);
                writer.AppendLine(encoding.Format());
                writer.WriteLine(RP.PageBreak80);

                if(state.OSZ)
                {
                    Require.invariant(state.PREFIX66);
                    writer.AppendLineFormat(RenderPattern, nameof(state.OSZ), "0x66");
                }

                if(state.ASZ)
                    writer.AppendLineFormat(RenderPattern, nameof(state.ASZ), "0x67");

                if(state.DF64)
                    writer.AppendLineFormat(RenderPattern, nameof(state.DF64), "64");

                if(state.DF32)
                    writer.AppendLineFormat(RenderPattern, nameof(state.DF32), "32");

                if(detail.PSZ != 0)
                    writer.AppendLineFormat(RenderPattern, nameof(detail.PSZ), detail.PSZ);

                if(state.NSEG_PREFIXES != 0)
                    writer.AppendLineFormat(RenderPattern, nameof(state.NSEG_PREFIXES), state.NSEG_PREFIXES);

                if(state.HINT != 0)
                    writer.AppendLineFormat(RenderPattern, nameof(state.HINT), XedRender.format(XedState.hint(state)));

                if(state.REP != 0)
                    writer.AppendLineFormat(RenderPattern, nameof(state.REP), XedRender.format(XedState.rep(state)));

                writer.AppendLineFormat(RenderPattern, nameof(state.EASZ), XedRender.format(XedState.easz(state)));
                writer.AppendLineFormat(RenderPattern, nameof(state.EOSZ), XedRender.format(XedState.eosz(state)));
                writer.AppendLineFormat(RenderPattern, nameof(state.MODE), XedRender.format(XedState.mode(state)));
                writer.AppendLineFormat(RenderPattern, "OpCode", string.Format("{0} [{1}]", ochex, ocbits));

                if(state.SRM != 0)
                {
                    var srmHex = XedRender.format((Hex8)state.SRM);
                    var srmBits = BitRender.format8x4(state.SRM);
                    writer.AppendLineFormat(RenderPattern, nameof(state.SRM), string.Format("{0} [{1}]", srmHex, srmBits));
                }

                if(state.HAS_MODRM)
                {
                    var modrm = XedState.modrm(state);
                    writer.AppendLineFormat(RenderPattern, "ModRm", string.Format("{0} [{1}]", modrm.Format(), modrm.ToBitString()));
                }

                if(state.HAS_SIB)
                {
                    var sib = XedState.sib(state);
                    writer.AppendLineFormat(RenderPattern, "Sib", string.Format("{0} [{1}]",  sib.Format(), sib.ToBitString()));
                }

                if(state.REX)
                {
                    var rex = XedState.rex(state);
                    Require.invariant(state.NREXES != 0);
                    writer.AppendLineFormat(RenderPattern, "Rex", string.Format("{0} [{1}]", rex, rex.ToBitString()));
                    writer.AppendLineFormat(RenderPattern, "RexBits", string.Format("[0100 | W:{0} | R:{1} | X:{2} | B:{3}]", state.REXW, state.REXR, state.REXX, state.REXB));
                }

                if(encoding.Disp != 0)
                {
                    writer.AppendLineFormat(RenderPattern, nameof(state.DISP_WIDTH), state.DISP_WIDTH);
                    writer.AppendLineFormat(RenderPattern, nameof(encoding.Disp), encoding.Disp);
                }

                if(state.MEM0)
                    writer.AppendLineFormat(RenderPattern, nameof(state.MEM0), state.MEM0);

                if(state.MEM1)
                    writer.AppendLineFormat(RenderPattern, nameof(state.MEM1), state.MEM1);

                if(state.NEED_MEMDISP)
                    writer.AppendLineFormat(RenderPattern, nameof(state.NEED_MEMDISP), state.NEED_MEMDISP);

                if(state.UBIT)
                    writer.AppendLineFormat(RenderPattern, nameof(state.UBIT), state.UBIT);

                if(state.IMM0)
                {
                    writer.AppendLineFormat(RenderPattern, nameof(state.IMM_WIDTH), state.IMM_WIDTH);
                    writer.AppendLineFormat(RenderPattern, nameof(encoding.Imm), encoding.Imm);
                }

                if(state.IMM1)
                    writer.AppendLineFormat(RenderPattern, nameof(encoding.Imm1), encoding.Imm1);

                if(state.SAE)
                    writer.AppendLineFormat(RenderPattern, nameof(state.SAE), state.SAE);

                if(state.ESRC != 0)
                    writer.AppendLineFormat(RenderPattern, nameof(state.ESRC), XedRender.format((Hex8)state.ESRC));

                if(state.ROUNDC != 0)
                    writer.AppendLineFormat(RenderPattern, nameof(state.ROUNDC), XedRender.format(XedState.rounc(state)));

                var rc = (ROUNDC)state.ROUNDC;
                if(rc == 0 && state.LLRC != 0)
                    writer.AppendLineFormat(RenderPattern, nameof(state.LLRC), XedRender.format((Hex8)state.LLRC));

                if(rc != 0)
                {
                    var llrc = (LLRC)state.LLRC;
                    Require.equal(state.BCRC, bit.On);
                    switch(rc)
                    {
                        case ROUNDC.RnSae:
                            Require.invariant(llrc == LLRC.LLRC0);
                            Require.invariant(state.SAE);
                        break;
                        case ROUNDC.RdSae:
                            Require.invariant(llrc == LLRC.LLRC1);
                            Require.invariant(state.SAE);
                        break;
                        case ROUNDC.RuSae:
                            Require.invariant(llrc == LLRC.LLRC2);
                            Require.invariant(state.SAE);
                        break;
                        case ROUNDC.RzSae:
                            Require.invariant(llrc == LLRC.LLRC3);
                            Require.invariant(state.SAE);
                        break;
                    }
                }

                var vc = XedState.vexclass(state);
                if(vc != 0)
                {
                    var vk = XedState.vexkind(state);
                    var vex5 = BitNumbers.join((uint3)state.VEXDEST210, state.VEXDEST4, state.VEXDEST3);
                    var vexBits = string.Format("[{0} {1} {2}]", state.VEXDEST4, state.VEXDEST3, (uint3)state.VEXDEST210);
                    var vexHex = XedRender.format((Hex8)(byte)vex5);
                    writer.AppendLineFormat(RenderPattern, nameof(state.VEXVALID), XedRender.format(vc));
                    writer.AppendLineFormat(RenderPattern, nameof(state.VEX_PREFIX), vk == 0 ? "VNP" : XedRender.format(vk));
                    if(vc == VexClass.VV1)
                        writer.AppendLineFormat(RenderPattern, "Vex", detail.Vex);
                    else if(vc == VexClass.EVV)
                        writer.AppendLineFormat(RenderPattern, "Evex", detail.Evex);
                    writer.AppendLineFormat(RenderPattern, "VEXDEST", string.Format("{0} {1}", vexHex, vexBits));
                }

                if(state.ELEMENT_SIZE != 0)
                {
                    writer.AppendLineFormat(RenderPattern, "VexSize", string.Format("{0}x{1}", XedRender.format(XedState.vl(state)), state.ELEMENT_SIZE));
                }

                if(state.NELEM != 0)
                    writer.AppendLineFormat(RenderPattern, nameof(state.NELEM), state.NELEM);

                if(state.BCAST != 0)
                    writer.AppendLineFormat(RenderPattern, nameof(state.BCAST), XedState.bcast(state));

                for(var k=0; k<cells.Count; k++, counter++)
                {
                    ref readonly var value = ref cells[k];
                    ref readonly var fk = ref value.Field;
                    if(!emitted.Contains(fk))
                        writer.AppendLineFormat(RenderPattern, "**" + XedRender.format(fk), XedRender.format(value));
                }

                if(state.OUTREG != 0)
                {
                    writer.AppendLineFormat(RenderPattern, nameof(state.OUTREG), XedRegMap.map(state.OUTREG));
                }

                DisasmRender.RenderOps(ops,buffer);
                writer.WriteLine(buffer.Emit());
            }

            EmittedFile(emitting,counter);
        }
    }
}