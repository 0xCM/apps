//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/repo/build/headers")]
        Outcome LLvmBuildHeaders(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.H));
    }
}