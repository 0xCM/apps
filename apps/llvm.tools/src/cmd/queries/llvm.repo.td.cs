//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string RepoTableDefQuery = "llvm/repo/td";

        [CmdOp(RepoTableDefQuery)]
        Outcome LlvmTableDefs(CmdArgs args)
            => Flow(RepoTableDefQuery, LlvmRepo.Files(FS.Td));
    }
}