//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/repo/build/inc")]
        Outcome LLvmBuildInc(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Inc));
    }
}