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
            var dst = ProjectDb.ApiTablePath<AsmDataBlock>();
            var hostasm = HostAsm();
            var blocks = AsmTables.DistillBlocks(hostasm);
            AsmTables.EmitBlocks(blocks, dst);
            return result;
        }
    }
}