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
        public void Collect(WsContext context)
        {
            Projects.XedDisasmDir(context.Project).Clear();
            var files = context.Files(FileKind.XedRawDisasm);
            var dst = cdict<FileRef,DisasmDetailDoc>();
            iter(files, file => Collect(context, file, dst), PllExec);
            TableEmit(summarize(dst).View, DisasmSummary.RenderWidths, Projects.Table<DisasmSummary>(context.Project));
            EmitDetails(dst, Projects.Table<DetailBlockRow>(context.Project));
            EmitFields(context);
        }

        static Index<DisasmSummary> summarize(ConcurrentDictionary<FileRef,DisasmDetailDoc> src)
        {
            var dst = map(src.Values, v => map(v.View, x => x.Block.Summary)).SelectMany(x => x).Sort();
            for(var i=0u; i<dst.Length; i++)
                seek(dst,i).Seq = i;
            return dst;
        }

        void Collect(WsContext context, in FileRef src, ConcurrentDictionary<FileRef,DisasmDetailDoc> dst)
        {
            var file = load(src);
            var details = XedDisasm.doc(context, src);
            dst.TryAdd(src, details);
            exec(PllExec,
                () => EmitOps(context, details),
                () => EmitChecks(context, details)
            );
        }
    }
}