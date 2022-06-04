//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasmSvc
    {
        public void Collect(WsContext context)
        {
            AppDb.ProjectDb(context.Project, disasm).Clear();
            var docs = CalcDocs(context);
            exec(PllExec,
                () => EmitConsolidated(context,docs),
                () => EmitBreakdowns(context,docs)
                );
        }
    }
}