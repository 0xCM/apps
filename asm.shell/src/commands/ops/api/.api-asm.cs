//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".api-asm")]
        Outcome ApiAsm(CmdArgs args)
        {
            var result = Outcome.Success;
            var dst = Ws.Gen().Subdir("csv") + Tables.filename<AsmDataBlock>();
            var records = AsmEtl.LoadHostAsmRows(ApiArchive.HostAsm());
            var blocks = AsmEtl.DistillBlocks(records);
            AsmEtl.EmitBlocks(blocks, dst);
            return result;
        }
    }
}