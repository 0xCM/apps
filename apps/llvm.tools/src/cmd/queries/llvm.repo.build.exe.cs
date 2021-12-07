//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string RepoBuildExeQuery = "llvm/repo/build/exe";

        [CmdOp(RepoBuildExeQuery)]
        Outcome LLvmBuildTargets(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Exe));
    }
}