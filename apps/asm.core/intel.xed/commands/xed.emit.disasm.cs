//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/disasm")]
        Outcome EmitDisasm(CmdArgs args)
        {
            XedDisasmSvc.EmitDisasmDetail(Context());
            return true;
        }

        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            CheckDisasm();
            return true;
        }

        void CheckDisasm()
        {
            var context = Context();
            var files = context.Files(FileKind.XedRawDisasm);
            core.iter(files, file => CheckDisasm(context,file), true);
        }

        FS.FilePath CheckPath(WsContext context, in FileRef src)
            => Projects.XedDisasmDir(context.Project) + FS.file(string.Format("{0}.checks", src.Path.FileName.WithoutExtension), FS.Txt);

        void CheckDisasm(WsContext context, in FileRef src)
        {
            const string RenderPattern = "{0,-24} | {1}";
            var summaries = XedDisasm.summarize(context, XedDisasm.blocks(src));
            var count = summaries.Count;
            var dstpath = CheckPath(context,src);
            using var writer = dstpath.AsciWriter();
            var emitting = EmittingFile(dstpath);
            var counter = 0;
            for(var j=0; j<count; j++)
            {
                var state = RuleState.Empty;
                ref readonly var sb = ref summaries[j];
                ref readonly var block = ref sb.Block;

                ref readonly var summary = ref sb.Summary;
                writer.AppendLineFormat("{0,-24} | {1,-5} {2}", summary.Encoded, summary.IP, summary.Asm);
                writer.WriteLine(RP.PageBreak80);
                var fields = XedDisasm.update(block, ref state);

                writer.WriteLine(RenderPattern, nameof(state.EASZ), XedRender.format(XedFields.easz(state)));
                writer.WriteLine(RenderPattern, nameof(state.EOSZ), XedRender.format(XedFields.eosz(state)));
                writer.WriteLine(RenderPattern, nameof(state.MODE), XedRender.format(XedFields.mode(state)));
                writer.WriteLine(RenderPattern, "OCMAP", XedRender.format(XedFields.ocindex(state)));
                writer.WriteLine(RenderPattern, "OCBYTE", XedRender.format(XedFields.ocbyte(state)));

                if(state.HAS_MODRM)
                    writer.WriteLine(RenderPattern, "MODRM", XedFields.modrm(state));
                if(state.REX)
                    writer.WriteLine(RenderPattern, "REX", XedFields.rex(state));
                if(state.HAS_SIB)
                    writer.WriteLine(RenderPattern, "SIB", XedFields.sib(state));

                if(state.OUTREG != 0)
                    writer.WriteLine(RenderPattern, nameof(state.OUTREG), XedFields.outreg(state));

                var regs = XedFields.regs(state);
                for(var k=z8; k<regs.Count; k++)
                    writer.WriteLine(RenderPattern, string.Format("REG{0}",k), XedRegMap.map(regs[k]));

                var vc = XedFields.vexclass(state);
                if(vc != 0)
                {
                    var vk = XedFields.vexkind(state);
                    writer.WriteLine(RenderPattern, "VEXCLASS", XedRender.format(vc));
                    writer.WriteLine(RenderPattern, "VEXKIND", XedRender.format(vk));
                    if(state.ELEMENT_SIZE != 0)
                    {
                        var vl = XedFields.vl(state);
                        writer.WriteLine(RenderPattern, "SZ", string.Format("{0}x{1}", XedRender.format(vl), state.ELEMENT_SIZE));
                    }
                }

                if(state.BCAST != 0)
                    writer.WriteLine(RenderPattern, nameof(state.BCAST), XedRender.format(XedFields.bcast(state)));

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