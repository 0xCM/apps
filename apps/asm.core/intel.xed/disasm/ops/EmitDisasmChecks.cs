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

    using K = XedRules.FieldKind;

    partial class XedDisasmSvc
    {
        FS.FilePath CheckPath(WsContext context, in FileRef src)
            => Projects.XedDisasmDir(context.Project) + FS.file(string.Format("{0}.checks", src.Path.FileName.WithoutExtension), FS.Txt);

        void EmitDisasmChecks(WsContext context, DisasmDetailDoc doc)
        {
            const string RenderPattern = "{0,-24} | {1}";
            ref readonly var file = ref doc.File;
            var emitted = hashset<FieldKind>(
                    K.MODE,
                    K.OSZ, K.ASZ, K.EASZ, K.EOSZ, K.PREFIX66, K.DF32, K.DF64,
                    K.NPREFIXES,
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
                    K.MAX_BYTES, K.LZCNT, K.TZCNT, K.USING_DEFAULT_SEGMENT0, K.SMODE, K.P4
                    );

            var count = doc.RowCount;
            var dstpath = CheckPath(context,file.Source);
            using var writer = dstpath.AsciWriter();
            var emitting = EmittingFile(dstpath);
            var counter = 0;
            for(var j=0; j<count; j++)
            {
                var state = RuleState.Empty;
                ref readonly var detail = ref doc[j].Detail;
                ref readonly var ops = ref detail.Ops;
                ref readonly var block = ref doc[j].Block;
                ref readonly var summary = ref block.Summary;
                ref readonly var lines = ref block.Lines;
                ref readonly var asmhex = ref summary.Encoded;
                ref readonly var asmtxt = ref summary.Asm;
                ref readonly var ip = ref summary.IP;

                var fields = XedDisasm.update(lines, ref state);
                var ocindex = XedState.ocindex(state);
                var ockind = XedPatterns.ockind(ocindex);
                var encoding  = XedState.encoding(state, asmhex);
                var ocbyte = XedState.ocbyte(state);
                var ochex = XedRender.format(ocbyte);
                var ocbits = BitRender.format8x4(ocbyte);

                writer.WriteLine(RP.PageBreak240);
                writer.AppendLine(lines.Format());
                writer.WriteLine(RP.PageBreak80);

                writer.AppendLineFormat(RenderPattern, "InstClass", detail.InstClass);
                writer.AppendLineFormat(RenderPattern, "InstForm", detail.InstForm);
                writer.AppendLineFormat("{0,-24} | {1,-5} {2}", asmhex, ip, asmtxt);
                writer.AppendLineFormat(RenderPattern, "OcMap", ockind);
                writer.AppendLine(encoding.Format());
                writer.WriteLine(RP.PageBreak80);
                if(state.OSZ)
                {
                    Require.invariant(state.PREFIX66);
                    writer.AppendLineFormat(RenderPattern, "OszPrefix", "0x66");
                }
                if(state.ASZ)
                {
                    writer.AppendLineFormat(RenderPattern, "AszPrefix", "0x67");
                }
                if(state.DF64)
                {
                    writer.AppendLineFormat(RenderPattern, "SzDefault", "64");
                }
                if(state.DF32)
                {
                    writer.AppendLineFormat(RenderPattern, "SzDefault", "32");
                }

                writer.AppendLineFormat(RenderPattern, "PrefixSize", detail.PSZ);
                writer.AppendLineFormat(RenderPattern, "Easz", XedRender.format(XedState.easz(state)));
                writer.AppendLineFormat(RenderPattern, "Eosz", XedRender.format(XedState.eosz(state)));
                writer.AppendLineFormat(RenderPattern, "Mode", XedRender.format(XedState.mode(state)));
                writer.AppendLineFormat(RenderPattern, "OpCode", string.Format("{0} [{1}]", ochex, ocbits));
                if(state.SRM != 0)
                {
                    var srmHex = XedRender.format((Hex8)state.SRM);
                    var srmBits = BitRender.format8x4(state.SRM);
                    writer.AppendLineFormat(RenderPattern, "Srm", string.Format("{0} [{1}]", srmHex, srmBits));
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
                    writer.AppendLineFormat(RenderPattern, "DispWidth", state.DISP_WIDTH);
                    writer.AppendLineFormat(RenderPattern, "DispValue", encoding.Disp);
                }
                if(state.IMM0)
                {
                    writer.AppendLineFormat(RenderPattern, "ImmWidth", state.IMM_WIDTH);
                    writer.AppendLineFormat(RenderPattern, "Imm", encoding.Imm);
                }

                if(state.IMM1)
                    writer.AppendLineFormat(RenderPattern, "Imm1", encoding.Imm1);
                if(state.SAE)
                    writer.AppendLineFormat(RenderPattern, "Sae", state.SAE);
                if(state.ESRC != 0)
                    writer.AppendLineFormat(RenderPattern, "Esrc", XedRender.format((Hex8)state.ESRC));

                var rc = (ROUNDC)state.ROUNDC;
                if(rc == 0 && state.LLRC != 0)
                    writer.AppendLineFormat(RenderPattern, "Llrc", XedRender.format((Hex8)state.LLRC));

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

                    writer.AppendLineFormat(RenderPattern, "Rounding", XedRender.format(rc));
                }

                var vc = XedState.vexclass(state);
                if(vc != 0)
                {
                    var vk = XedState.vexkind(state);
                    var vex5 = BitNumbers.join((uint3)state.VEXDEST210, state.VEXDEST4, state.VEXDEST3);
                    var vexBits = string.Format("[{0} {1} {2}]", state.VEXDEST4, state.VEXDEST3, (uint3)state.VEXDEST210);
                    var vexHex = XedRender.format((Hex8)(byte)vex5);
                    writer.AppendLineFormat(RenderPattern, "VexClass", XedRender.format(vc));
                    writer.AppendLineFormat(RenderPattern, "VexKind", vk == 0 ? "VNP" : XedRender.format(vk));
                    if(vc == VexClass.VV1)
                        writer.AppendLineFormat(RenderPattern, "VexPrefix", detail.Vex);
                    else if(vc == VexClass.EVV)
                        writer.AppendLineFormat(RenderPattern, "EvexPrefix", detail.Evex);
                    writer.AppendLineFormat(RenderPattern, "VexDest", string.Format("{0} {1}", vexHex, vexBits));
                }

                if(state.ELEMENT_SIZE != 0)
                {
                    var vl = XedState.vl(state);
                    writer.AppendLineFormat(RenderPattern, "VexSize", string.Format("{0}x{1}", XedRender.format(vl), state.ELEMENT_SIZE));
                }

                if(state.NELEM != 0)
                {
                    writer.AppendLineFormat(RenderPattern, "ElementCount", state.NELEM);
                }

                if(state.BCAST != 0)
                    writer.AppendLineFormat(RenderPattern, "Broadcast", XedState.bcast(state));

                for(var k=0; k<fields.Count; k++, counter++)
                {
                    ref readonly var value = ref fields[k];
                    ref readonly var fk = ref value.Field;
                    if(!emitted.Contains(fk))
                        writer.AppendLineFormat(RenderPattern, XedRender.format(fk), XedRender.format(value));
                }

                if(state.OUTREG != 0)
                    writer.AppendLineFormat(RenderPattern, "OutReg", XedState.outreg(state));


                writer.WriteLine(RenderPattern,  "Operands", ops.Count);
                writer.WriteLine(RP.PageBreak80);
                for(var i=0; i<ops.Count; i++)
                {
                    ref readonly var op =ref ops[i];
                    var tabledef = FS.FileUri.Empty;
                    if(XedParsers.parse(op.OpInfo.Selector.Format(), out NontermKind nk))
                    {
                        var path = XedPaths.Service.TableDef(RuleTableKind.Enc, nk);
                        if(path.Exists)
                            tabledef = path;
                        else
                        {
                            path = XedPaths.Service.TableDef(RuleTableKind.Dec, nk);
                            if(path.Exists)
                                tabledef = path;
                        }
                    }

                    writer.AppendLine(string.Format("{0} | {1,-6} | {2,-4} | {3,-4} | {4,-4} | {5,-4} | {6}",
                        i,
                        XedRender.format(op.OpName),
                        XedRender.format(op.OpInfo.Action),
                        XedRender.format(op.OpInfo.WidthCode),
                        op.OpInfo.Visiblity.Code(),
                        XedRender.format(op.OpInfo.OpType),
                        nk != 0
                        ? string.Format("{0} => {1}", string.Format("{0}()",XedRender.format(nk)), tabledef)
                        : op.OpInfo.Selector
                    ));
                }

                writer.WriteLine();
            }
            EmittedFile(emitting,counter);
        }
    }
}