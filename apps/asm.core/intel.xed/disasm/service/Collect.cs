//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasmModels;

    partial class XedDisasmSvc
    {
        public void Collect(WsContext context)
        {
            Projects.ProjectData(context.Project, scope).Clear();
            var docs = CalcDocs(context);
            exec(PllExec,
                () => EmitConsolidated(context,docs),
                () => EmitBreakdowns(context,docs)
                );
        }
    }
}