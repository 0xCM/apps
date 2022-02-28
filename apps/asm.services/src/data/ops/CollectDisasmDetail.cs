//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectDataServices
    {
        public Index<AsmDisasmDetail> CollectDisasmDetail(WsContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            var summaries = XedDisasm.EmitDisasmSummary(XedDisasm.CollectDisasmSummaries(context), Projects.XedDisasmSummary(project));
            var details = XedDisasm.CollectDisasmDetails(context);
            return details;
        }
    }
}