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
        void EmitConsolidated(WsContext context, Index<Document> src)
        {
            var summaries = bag<SummaryRow>();
            var details = bag<DetailBlock>();
            iter(src, pair =>{
                iter(pair.Summary.Rows, r => summaries.Add(r));
                iter(pair.Detail.Blocks, b => details.Add(b));
            });

            exec(PllExec,
                () => EmitOpClasses(context, src),
                () => EmitConsolidated(context, details.ToArray()),
                () => EmitConsolidated(context,summaries.ToArray()));
        }

        void EmitOpClasses(WsContext context, Index<Document> src)
        {
            var target = Projects.XedDisasmDir(context.Project) + Tables.filename<InstOpClass>(context.Project.Name.Format());
            TableEmit(XedDisasm.opclasses(src).View, InstOpClass.RenderWidths, target);
        }

        void EmitConsolidated(WsContext context, Index<DetailBlock> src)
        {
            var target = Projects.Table<DetailBlockRow>(context.Project);
            var buffer = text.buffer();
            DisasmRender.render(resequence(src), buffer);
            var emitting = EmittingFile(target);
            using var emitter = target.AsciEmitter();
            emitter.Write(buffer.Emit());
            EmittedFile(emitting, src.Count);
        }

        void EmitConsolidated(WsContext context, Index<SummaryRow> src)
        {
            var target = Projects.Table<SummaryRow>(context.Project);
            TableEmit(resequence(src).View, SummaryRow.RenderWidths, target);
        }
    }
}