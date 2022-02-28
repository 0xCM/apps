//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectDataServices
    {
        public Index<AsmDisasmSummary> LoadDisasmSummaries(IProjectWs project)
            => XedDisasm.LoadDisasmSummary(project);
    }
}