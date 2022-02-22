//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("project/build/c")]
        Outcome BuildC(CmdArgs args)
            => Projects.BuildC(Project());

        [CmdOp("project/build/cpp")]
        Outcome BuildCpp(CmdArgs args)
            => Projects.BuildCpp(Project());

        [CmdOp("project/build+run/cpp")]
        Outcome BuildRunCpp(CmdArgs args)
            => Projects.BuildCpp(Project(), true);

        [CmdOp("project/build+run/c")]
        Outcome BuildRunC(CmdArgs args)
            => Projects.BuildC(Project(), true);
    }
}