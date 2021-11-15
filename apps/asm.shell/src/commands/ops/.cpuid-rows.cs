//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".cpuid-rows")]
        Outcome LoadCpuidRows(CmdArgs args)
        {
            var result = Outcome.Success;
            result = AsmTables.LoadCpuIdImports(Ws.Tables(), out var rows);
            if(result.Fail)
                return result;

            Write(rows, CpuIdRow.RenderWidths);
            return result;
        }
    }
}