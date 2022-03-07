//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasmSvc
    {
        public void CollectDisasm(WsContext context)
        {
            EmitDisasmSummary(CollectDisasmSummaries(context), Projects.XedDisasmSummary(context.Project));
            CollectDisasmDetails(context);
        }
    }
}