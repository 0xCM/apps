//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedRules;

    partial class XedDisasmSvc
    {
        public void Collect(WsContext context)
        {
            Projects.XedDisasmDir(context.Project).Clear();
            var docs = XedDisasm.docs(context);
            var summaries = bag<DisasmSummaryRow>();
            var details = bag<DetailBlock>();
            exec(PllExec,
                () => EmitRecords(context,docs),
                () => EmitOpClasses(context, docs),
                () => EmitBreakdowns(context,docs)
                );
        }

        void EmitBreakdowns(WsContext context, Index<DisasmDocs> docs)
        {
            iter(docs.Select(x => x.Detail), d => {
                    EmitOps(context, d);
                    EmitChecks(context, d);
                    EmitFields(context, d);
                }, PllExec);
        }

        void EmitRecords(WsContext context, Index<DisasmDocs> src)
        {
            var summaries = bag<DisasmSummaryRow>();
            var details = bag<DetailBlock>();
            iter(src, pair =>{
                iter(pair.Summary.Rows, r => summaries.Add(r));
                iter(pair.Detail.Blocks, b => details.Add(b));
            });

            exec(PllExec,
                () => EmitDetailReport(context, details.ToArray()),
                () => EmitSummaryReport(context,summaries.ToArray()));
        }

        public void EmitOpClasses(WsContext context, Index<DisasmDocs> src)
        {
            var target = Projects.XedDisasmDir(context.Project) + Tables.filename<InstOpClass>(context.Project.Name.Format());
            TableEmit(XedDisasm.opclasses(src).View, InstOpClass.RenderWidths, target);
        }
    }
}