//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasmSvc
    {
        public void CollectDisasm(WsContext context)
        {
            EmitDisasmSummary(CollectDisasmSummaries(context), Projects.XedDisasmSummary(context.Project));
            CollectDisasmDetails(context);
            EmitDisasmDetail(context);
        }
    }
}