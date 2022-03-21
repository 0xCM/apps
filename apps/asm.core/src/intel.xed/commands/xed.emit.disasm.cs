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
            var context = Context();
            var files = context.Files(FileKind.XedRawDisasm);
            core.iter(files, file => CheckDisasm(context,file), true);
            return true;
        }

        FS.FilePath CheckPath(WsContext context, in FileRef src)
            => Projects.XedDisasmDir(context.Project) + FS.file(string.Format("{0}.checks", src.Path.FileName.WithoutExtension), FS.Txt);

        void CheckDisasm(WsContext context, in FileRef src)
        {
            const string RenderPattern = "{0,-24} | {1}";
            var blocks = XedDisasm.blocks(src);
            var summaries = XedDisasm.summarize(context, blocks);
            var count = Require.equal(blocks.Count,summaries.Count);
            var dstpath = CheckPath(context,src);
            using var writer = dstpath.AsciWriter();
            var emitting = EmittingFile(dstpath);
            var counter = 0;
            for(var j=0; j<count; j++)
            {
                var state = RuleState.Empty;
                ref readonly var block = ref blocks[j];
                ref readonly var summary = ref summaries[j];
                writer.AppendLineFormat("{0,-24} | {1,-5} {2}", summary.Encoded, summary.IP, summary.Asm);
                writer.WriteLine(RP.PageBreak80);
                var values = XedDisasm.update(block, ref state);

                writer.WriteLine(RenderPattern, nameof(state.EASZ), XedRender.format(XedFields.easz(state)));
                writer.WriteLine(RenderPattern, nameof(state.EOSZ), XedRender.format(XedFields.eosz(state)));
                writer.WriteLine(RenderPattern, nameof(state.MODE), XedRender.format(XedFields.mode(state)));
                writer.WriteLine(RenderPattern, nameof(state.MAP), XedRender.format(XedFields.ocindex(state)));
                if(state.HAS_MODRM)
                    writer.WriteLine(RenderPattern, "MODRM", XedFields.modrm(state));
                if(state.REXW || state.REXR || state.REXB || state.REXX)
                    writer.WriteLine(RenderPattern, "REX", XedFields.rex(state));
                var regs = XedFields.regs(state);
                for(var k=z8; k<regs.Count; k++)
                    writer.WriteLine(RenderPattern, string.Format("REG{0}",k), XedRender.format(regs[k]));

                var vc = XedFields.vexclass(state);
                if(vc != 0)
                {
                    var vk = XedFields.vexkind(state);
                    writer.WriteLine(RenderPattern, "VEXCLASS", XedRender.format(vc));
                    writer.WriteLine(RenderPattern, "VEXKIND", XedRender.format(vk));
                    var vl = XedFields.vl(state);
                    writer.WriteLine(RenderPattern, nameof(state.VL), XedRender.format(vl));
                    if(state.ELEMENT_SIZE != 0)
                        writer.WriteLine(RenderPattern, "SZ", string.Format("{0}x{1}", XedRender.format(vl), state.ELEMENT_SIZE));
                }

                writer.WriteLine(RP.PageBreak40);
                for(var k=0; k<values.Count; k++, counter++)
                {
                    ref readonly var value = ref values[k];
                    writer.AppendLineFormat(RenderPattern, XedRender.format(value.Field), XedRender.format(value));
                }
                writer.WriteLine();
            }
            EmittedFile(emitting,counter);
        }
    }
}