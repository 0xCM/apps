//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/files/td")]
        void LlvmTableDefs(CmdArgs args)
            => Query.Emit(WsArchive.Files(FileKind.Td), "llvm.files.td");
    }
}