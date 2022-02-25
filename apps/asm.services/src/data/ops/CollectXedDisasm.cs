//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectDataServices
    {
        public Index<XedDisasmDetail> CollectXedDisasm(WsContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            var summaries = XedDisasm.EmitDisasmSummary(XedDisasm.CollectEncodingDocs(context), Projects.XedDisasmSummary(project));
            XedDisasm.CollectDetailPages(context);
            var details = XedDisasm.CollectDisasmDetails(context);
            return details;
        }
    }
}