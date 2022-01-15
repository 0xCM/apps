//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/asmblocks")]
        Outcome EmitApiAsmBlocks(CmdArgs args)
        {
            var result = Outcome.Success;
            var dst = ProjectDb.Subdir("asm") + Tables.filename<AsmDataBlock>();
            var blocks = AsmTables.DistillBlocks(HostAsm());
            AsmTables.EmitBlocks(blocks, dst);
            return result;
        }
    }
}