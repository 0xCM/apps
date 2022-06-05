//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/build/c")]
        Outcome BuildC(CmdArgs args)
            => ProjectSvc.BuildC(Project());

        [CmdOp("project/build/cpp")]
        Outcome BuildCpp(CmdArgs args)
            => ProjectSvc.BuildCpp(Project());

        [CmdOp("project/build+run/cpp")]
        Outcome BuildRunCpp(CmdArgs args)
            => ProjectSvc.BuildCpp(Project(), true);

        [CmdOp("project/build+run/c")]
        Outcome BuildRunC(CmdArgs args)
            => ProjectSvc.BuildC(Project(), true);
    }
}