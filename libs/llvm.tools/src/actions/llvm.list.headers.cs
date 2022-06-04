//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/list/headers")]
        void LlvmHeaders()
            => Files(Repo.Files(FS.H));
    }
}