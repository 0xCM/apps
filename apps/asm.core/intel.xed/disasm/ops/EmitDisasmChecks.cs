//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDisasmSvc
    {
        FS.FilePath CheckPath(WsContext context, in FileRef src)
            => Projects.XedDisasmDir(context.Project) + FS.file(string.Format("{0}.checks", src.Path.FileName.WithoutExtension), FS.Txt);

        void EmitDisasmChecks(WsContext context, DisasmDetailDoc doc)
        {
            const string RenderPattern = "{0,-24} | {1}";
            ref readonly var file = ref doc.File;
            var count = doc.RowCount;
            var dstpath = CheckPath(context,file.Source);
            using var writer = dstpath.AsciWriter();
            var emitting = EmittingFile(dstpath);
            var counter = 0;
            for(var j=0; j<count; j++)
            {
                var state = RuleState.Empty;
                ref readonly var detail = ref doc[j];
                ref readonly var summary = ref detail.Block.Summary;
                ref readonly var lines = ref detail.Block.Lines;
                writer.AppendLineFormat("{0,-24} | {1,-5} {2}", summary.Encoded, summary.IP, summary.Asm);
                writer.WriteLine(RP.PageBreak80);
                var fields = XedDisasm.update(lines, ref state);

                writer.WriteLine(RenderPattern, nameof(state.EASZ), XedRender.format(XedState.easz(state)));
                writer.WriteLine(RenderPattern, nameof(state.EOSZ), XedRender.format(XedState.eosz(state)));
                writer.WriteLine(RenderPattern, nameof(state.MODE), XedRender.format(XedState.mode(state)));
                writer.WriteLine(RenderPattern, "OCMAP", XedRender.format(XedState.ocindex(state)));
                writer.WriteLine(RenderPattern, "OCBYTE", XedRender.format(XedState.ocbyte(state)));

                if(state.HAS_MODRM)
                    writer.WriteLine(RenderPattern, "MODRM", XedState.modrm(state));
                if(state.REX)
                    writer.WriteLine(RenderPattern, "REX", XedState.rex(state));
                if(state.HAS_SIB)
                    writer.WriteLine(RenderPattern, "SIB", XedState.sib(state));

                if(state.OUTREG != 0)
                    writer.WriteLine(RenderPattern, nameof(state.OUTREG), XedState.outreg(state));

                var regs = XedState.regs(state);
                for(var k=z8; k<regs.Count; k++)
                    writer.WriteLine(RenderPattern, string.Format("REG{0}",k), XedRegMap.map(regs[k]));

                var vc = XedState.vexclass(state);
                if(vc != 0)
                {
                    var vk = XedState.vexkind(state);
                    writer.WriteLine(RenderPattern, "VEXCLASS", XedRender.format(vc));
                    writer.WriteLine(RenderPattern, "VEXKIND", XedRender.format(vk));
                    if(state.ELEMENT_SIZE != 0)
                    {
                        var vl = XedState.vl(state);
                        writer.WriteLine(RenderPattern, "SZ", string.Format("{0}x{1}", XedRender.format(vl), state.ELEMENT_SIZE));
                    }
                }

                if(state.BCAST != 0)
                    writer.WriteLine(RenderPattern, nameof(state.BCAST), XedRender.format(XedState.bcast(state)));

                writer.WriteLine(RP.PageBreak40);
                for(var k=0; k<fields.Count; k++, counter++)
                {
                    ref readonly var value = ref fields[k];
                    ref readonly var fk = ref value.Field;
                    if(fk == FieldKind.MAX_BYTES || fk == FieldKind.LZCNT || fk == FieldKind.TZCNT || fk == FieldKind.USING_DEFAULT_SEGMENT0 || fk == FieldKind.SMODE)
                        continue;

                    writer.AppendLineFormat(RenderPattern, XedRender.format(value.Field), XedRender.format(value));
                }
                writer.WriteLine();
            }
            EmittedFile(emitting,counter);
        }
    }
}