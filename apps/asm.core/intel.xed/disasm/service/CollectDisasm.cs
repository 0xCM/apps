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
        public void CollectFields(WsContext context)
        {
            var files = context.Files(FileKind.XedRawDisasm);
            var dst = cdict<FileRef,DisasmDetailDoc>();
            iter(files, load, PllExec);
            EmitDisasmFields(context, CalcDocDetails(dst));

            void load(FileRef fref)
            {
                var file = XedDisasm.loadfile(fref);
                dst.TryAdd(fref, CalcDisasmDetail(context, file, XedDisasm.summarize(context, file)));
            }
        }

        public void Collect(WsContext context)
        {
            Projects.XedDisasmDir(context.Project).Clear();
            var files = context.Files(FileKind.XedRawDisasm);
            var dst = cdict<FileRef,DisasmDetailDoc>();
            iter(files, file => CollectDisasm(context, file, dst), PllExec);

            var summaries = map(dst.Values, v => map(v.View, x => x.Block.Summary)).SelectMany(x => x).Sort();
            for(var i=0u; i<summaries.Length; i++)
                seek(summaries,i).Seq = i;

            TableEmit(@readonly(summaries), DisasmSummary.RenderWidths, Projects.Table<DisasmSummary>(context.Project));
            EmitDisasmDetails(dst, Projects.Table<DisasmDetail>(context.Project));
            EmitDisasmFields(context, CalcDocDetails(dst));
        }

        void CollectDisasm(WsContext context, in FileRef fref, ConcurrentDictionary<FileRef,DisasmDetailDoc> dst)
        {
            var file = XedDisasm.loadfile(fref);
            var summaries = XedDisasm.summarize(context, file);
            var details = CalcDisasmDetail(context, file, summaries);
            dst.TryAdd(fref, details);
            exec(PllExec,
                () => EmitDisasmOps(context, details),
                () => EmitDisasmProps(context, details),
                () => EmitDisasmChecks(context, details)
            );
        }

        Index<DisasmDetail> EmitDisasmDetails(ConstLookup<FileRef,DisasmDetailDoc> src, FS.FilePath dst)
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
                opheader.Append(DisasmRender.OpDetailHeader(k));
            }

            var records = details(src);
            var header = string.Format("{0}{1}", headerBase, opheader.Emit());
            using var writer = dst.AsciWriter();
            writer.WriteLine(header);
            for(var i=0; i<records.Count; i++)
                writer.WriteLine(formatter.Format(records[i]));

            EmittedFile(emitting, records.Count);
            return records;
        }
    }
}