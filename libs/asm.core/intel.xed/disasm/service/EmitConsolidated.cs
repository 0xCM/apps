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
    using static XedDisasmModels;

    partial class XedDisasmSvc
    {
        void EmitConsolidated(WsContext context, Index<Document> src)
        {
            var summaries = bag<XedDisasmRow>();
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
            var target = CmdFlows.table<InstOpClass>(context.Project.Project, disasm);
            AppSvc.TableEmit(XedDisasm.opclasses(src).View, target);
        }

        void EmitConsolidated(WsContext context, Index<DetailBlock> src)
        {
            var target = CmdFlows.table<DetailBlockRow>(context.Project.Project);
            var buffer = text.buffer();
            DisasmRender.render(resequence(src), buffer);
            var emitting = EmittingFile(target);
            using var emitter = target.AsciEmitter();
            emitter.Write(buffer.Emit());
            EmittedFile(emitting, src.Count);
        }

        void EmitConsolidated(WsContext context, Index<XedDisasmRow> src)
            => AppSvc.TableEmit(resequence(src), CmdFlows.table<XedDisasmRow>(context.Project.Project));
    }
}