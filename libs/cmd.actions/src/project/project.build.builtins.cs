//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/build/builtins")]
        Outcome BuildBuiltIns(CmdArgs args)
            => ProjectSvc.BuildScoped(Project(), "build-builtins", "builtins");
    }
}