//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/list/libs")]
        void LLvmBuildLibs()
            => Flow(LlvmRepo.BuildOutput(FS.Lib));
    }
}