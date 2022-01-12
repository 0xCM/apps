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
            var records = AsmTables.LoadHostAsmRows(ApiPackArchive.HostAsm());
            var blocks = AsmTables.DistillBlocks(records);
            AsmTables.EmitBlocks(blocks, dst);
            return result;
        }
    }
}