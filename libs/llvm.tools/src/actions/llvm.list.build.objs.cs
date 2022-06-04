//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/list/build/objs")]
        void LLvmBuildObj()
            => Files(Repo.BuildOutput(FS.Obj));
    }
}