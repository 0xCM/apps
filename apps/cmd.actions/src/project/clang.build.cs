//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("clang/build/c")]
        Outcome BuildC(CmdArgs args)
            => Clang.CBuild(Project());

        [CmdOp("clang/build/cpp")]
        Outcome BuildCpp(CmdArgs args)
            => Clang.CppBuild(Project());

        [CmdOp("clang/build+run/cpp")]
        Outcome BuildRunCpp(CmdArgs args)
            => Clang.CppBuild(Project(), true);

        [CmdOp("clang/build+run/c")]
        Outcome BuildRunC(CmdArgs args)
            => Clang.CBuild(Project(), true);
    }
}