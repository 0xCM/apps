//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp("api/emit/asm/blocks")]
        Outcome EmitApiAsm(CmdArgs args)
        {
            var result = Outcome.Success;
            var records = AsmTables.LoadHostAsmRows(ApiPackArchive.HostAsm());
            var blocks = AsmTables.DistillBlocks(records);
            AsmTables.EmitBlocks(blocks, ProjectDb.TablePath<AsmDataBlock>("api/asm"));
            return result;
        }
    }
}