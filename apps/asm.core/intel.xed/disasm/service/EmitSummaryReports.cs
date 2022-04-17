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
        public void EmitSummaryReports(WsContext context, Index<DisasmSummaryDoc> src)
            => iter(src, doc => EmitSummaryReport(context,doc), PllExec);

        public void EmitSummaryReport(WsContext context, DisasmSummaryDoc doc)
        {
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            ref readonly var origin = ref doc.Origin;
            var target = outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.summary.csv");
            TableEmit(doc.Rows.View, DisasmSummaryRow.RenderWidths, TextEncodingKind.Asci, target);
        }

        public void EmitSummaryReport(WsContext context, Index<DisasmSummaryRow> src)
        {
            var target = Projects.Table<DisasmSummaryRow>(context.Project);
            TableEmit(resequence(src).View, DisasmSummaryRow.RenderWidths, target);
        }
    }
}