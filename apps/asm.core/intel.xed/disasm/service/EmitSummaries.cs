//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedMachine;

    partial class XedDisasmSvc
    {
        public void EmitSummaries(WsContext context, Index<DisasmSummaryDoc> src, bool pll = true)
        {
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            iter(src, doc =>{
                ref readonly var origin = ref doc.Origin;
                var target = outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.summary.csv");
                TableEmit(doc.Rows.View, DisasmSummaryRow.RenderWidths, TextEncodingKind.Asci, target);
            },pll);
        }
    }
}