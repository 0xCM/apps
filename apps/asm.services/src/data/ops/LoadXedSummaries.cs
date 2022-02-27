//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectDataServices
    {
        public Index<XedDisasmSummary> LoadXedSummaries(IProjectWs project)
            => XedDisasm.LoadDisasmSummaries(project);
    }
}