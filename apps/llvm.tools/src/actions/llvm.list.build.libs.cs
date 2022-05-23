//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/list/build/libs")]
        void LLvmBuildLibs()
            => Files(Repo.BuildOutput(FS.Lib));
    }
}