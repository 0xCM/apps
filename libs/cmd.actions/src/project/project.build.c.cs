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
            => Scripts.BuildC(Project());

        [CmdOp("project/build/cpp")]
        Outcome BuildCpp(CmdArgs args)
            => Scripts.BuildCpp(Project());

        [CmdOp("project/build+run/cpp")]
        Outcome BuildRunCpp(CmdArgs args)
            => Scripts.BuildCpp(Project(), true);

        [CmdOp("project/build+run/c")]
        Outcome BuildRunC(CmdArgs args)
            => Scripts.BuildC(Project(), true);
    }
}