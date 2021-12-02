//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".api-asm")]
        Outcome EmitApiAsm(CmdArgs args)
        {
            var result = Outcome.Success;
            var dst = Ws.Project("gen").Subdir("csv") + Tables.filename<AsmDataBlock>();
            var records = AsmTables.LoadHostAsmRows(ApiPackArchive.HostAsm());
            var blocks = AsmTables.DistillBlocks(records);
            AsmTables.EmitBlocks(blocks, dst);
            return result;
        }
    }
}