//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".table-rpt")]
        Outcome EmitTableReport(CmdArgs args)
        {
            var result = Outcome.Success;
            EmitTableReport(Ws.Tables().Root + FS.file("tabledefs", "rpt"));
            return result;
        }
    }
}