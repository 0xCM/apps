//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/list/build/inc")]
        void LLvmBuildInc()
            => Files(Repo.BuildOutput(FS.Inc));
    }
}