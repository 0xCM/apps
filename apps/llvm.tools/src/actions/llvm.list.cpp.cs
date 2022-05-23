//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/list/cpp")]
        void LlvmCppFiles()
            => Files(Repo.Files(FS.Cpp));
    }
}