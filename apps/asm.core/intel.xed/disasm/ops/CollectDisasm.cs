//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        public void CollectDisasm(WsContext context)
        {
            Projects.XedDisasmDir(context.Project).Clear();
            var files = context.Files(FileKind.XedRawDisasm);
            var dst = cdict<FileRef,DisasmDetailDoc>();
            iter(files, file => CollectDisasm(context,file,dst),PllExec);
            var summaries = core.map(dst.Values, v => map(v.View, x => x.Block.Summary)).SelectMany(x => x).Sort();
            for(var i=0u; i<summaries.Length; i++)
                seek(summaries,i).Seq = i;

            TableEmit(@readonly(summaries), DisasmSummary.RenderWidths, Projects.Table<DisasmSummary>(context.Project));
            EmitDisasmDetails(dst, Projects.Table<DisasmDetail>(context.Project));
        }

        // void EmitDisasmSummary(Index<DisasmSummary> src, FS.FilePath dst)
        //     => TableEmit(src.View, DisasmSummary.RenderWidths, dst);

        void CollectDisasm(WsContext context, FileRef src, ConcurrentDictionary<FileRef,DisasmDetailDoc> dst)
        {
            var file = XedDisasm.loadfile(src);
            var summaries = XedDisasm.summarize(context, file);
            var details = CalcDisasmDetail(context, file, summaries);
            dst.TryAdd(src, details);
            EmitDisasmOps(context, details);
            EmitDisasmProps(context, details);
            EmitDisasmChecks(context, details);
        }

        void EmitDisasmDetails(ConstLookup<FileRef,DisasmDetailDoc> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            var formatter = Tables.formatter<DisasmDetail>(DisasmDetail.RenderWidths);
            var headerBase = formatter.FormatHeader();
            var j = text.lastindex(headerBase, Chars.Pipe);
            headerBase = text.left(headerBase,j);
            var opheader = text.buffer();
            for(var k=0; k<6; k++)
            {
                opheader.Append("| ");
                opheader.Append(XedDisasmRender.OpDetailHeader(k));
            }

            var details = core.map(src.Values, doc => map(doc.View, r => r.Detail)).SelectMany(x => x).Sort();

            for(var i=0u; i<details.Length; i++)
                seek(details,i).Seq = i;

            var header = string.Format("{0}{1}", headerBase, opheader.Emit());
            using var writer = dst.AsciWriter();
            writer.WriteLine(header);
            for(var i=0; i<details.Length; i++)
                writer.WriteLine(formatter.Format(skip(details,i)));

            EmittedFile(emitting, details.Length);
        }
    }
}