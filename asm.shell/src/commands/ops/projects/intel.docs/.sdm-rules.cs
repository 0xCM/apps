//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static SdmModels;

    partial class AsmCmdService
    {
        [CmdOp(".sdm-rules")]
        Outcome SdmRules(CmdArgs args)
        {
            var tables = Sdm.LoadInstructionSourceTables();
            var count = tables.Length;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var table = ref skip(tables,i);
                var kind = (SdmTableKind)table.Kind;
                var name = table.Source;
                if(kind == SdmTableKind.EncodingRule)
                {
                    var rows = table.Rows;
                    var rCount = rows.Length;
                    for(var j=0; j<rCount; j++)
                    {
                        ref readonly var row = ref skip(rows,j);
                        var cells = row.Cells;
                        var cCount = cells.Length;

                        buffer.AppendFormat("{0,-24}" + RP.SpacedPipe, name);
                        for(var k=0; k<cCount; k++)
                        {
                            ref readonly var cell = ref skip(cells,k);
                            buffer.AppendFormat("{0,-24}", cell.Format());
                            if(k != cCount - 1)
                                buffer.Append(RP.SpacedPipe);
                        }
                        Write(buffer.Emit());
                    }
                }
            }
            return true;
        }
    }
}