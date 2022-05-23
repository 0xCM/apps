//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/list/objs")]
        void LLvmBuildObj()
            => Flow(LlvmRepo.BuildOutput(FS.Obj));
    }
}