//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("project/build/builtins")]
        Outcome BuildBuiltIns(CmdArgs args)
            => Projects.BuildScoped(Project(), "build-builtins", "builtins");
    }
}