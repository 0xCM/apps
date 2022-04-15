//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        public static DisasmDetailDoc doc(WsContext context, in FileRef fref)
        {
            var file = XedDisasm.loadfile(fref);
            var summary = XedDisasm.summarize(context, file);
            return doc(context, file, summary);
        }

        public static DisasmDetailDoc doc(WsContext context, in DisasmFile file, DisasmSummaryDoc summary)
        {
            var dst = bag<DetailBlock>();
            CalcDetailBlocks(context, summary, file, dst).Require();
            return DisasmDetailDoc.from(file, dst.ToArray().Sort());
        }

        public static ConstLookup<FileRef,DisasmDetailDoc> docs(WsContext context, bool pll)
        {
            var files = context.Files(FileKind.XedRawDisasm);
            var dst = cdict<FileRef,DisasmDetailDoc>();
            iter(files, file => dst.TryAdd(file, doc(context,file)), pll);
            return dst;
        }
    }
}