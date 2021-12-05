//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
       [CmdOp("repo/build/exe")]
        Outcome LLvmBuildTargets(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Exe));

    }
}