//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/files/td")]
        void LlvmTableDefs(CmdArgs args)
            => Query.Emit(Repo.Files(FS.Td), "llvm.files.td");
    }
}