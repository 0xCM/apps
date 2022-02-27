//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectDataServices
    {
        public Index<XedDisasmDetail> CollectXedDisasm(WsContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            var summaries = XedDisasm.EmitDisasmSummary(XedDisasm.CollectEncodingDocs(context), Projects.XedDisasmSummary(project));
            var details = XedDisasm.CollectDisasmDetails(context);
            return details;
        }
    }
}