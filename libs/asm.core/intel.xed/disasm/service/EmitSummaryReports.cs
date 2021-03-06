//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedDisasmModels;

    partial class XedDisasmSvc
    {
        public void EmitSummaryReport(WsContext context, Document doc)
        {
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            ref readonly var summary = ref doc.Summary;
            ref readonly var origin = ref summary.Origin;
            AppSvc.TableEmit(summary.Rows, outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.summary.csv"));
        }
    }
}