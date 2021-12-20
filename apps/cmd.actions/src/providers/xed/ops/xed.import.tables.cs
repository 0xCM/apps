//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    partial class XedCmdProvider
    {
        Outcome Validate(XedInstTable src)
        {
            var instcount = src.InstCount;
            var opcount = src.OperandCount;
            var counter = 0u;
            var j=0u;
            for(var i=z16; i<instcount; i++)
            {
                ref readonly var inst = ref src.Instruction(i);
                for(var k=0; k<inst.OpCount && j<opcount; k++,j++)
                {
                    ref readonly var op = ref src.Operand(j);
                    if(op.InstIndex != inst.Index)
                        return (false, "Mismatch");
                    counter++;
                }
            }
            return counter == opcount;
        }

        [CmdOp("xed/import/tables")]
        Outcome ImportTables(CmdArgs args)
        {
            var table = Xed.ParseInstTable();

            var result = Validate(table);
            if(result.Fail)
                return result;

            var count = table.InstCount;
            var opcount = table.OperandCount;
            var counter = 0u;

            var instFormatter = Tables.formatter<XedInstTable.InstInfo>(XedInstTable.InstInfo.RenderWidths);
            var opFormatter = Tables.formatter<XedInstTable.InstOperand>();

            var j=0u;
            for(var i=z16; i<count; i++)
            {
                ref readonly var inst = ref table.Instruction(i);
                Write(instFormatter.Format(inst));
                //Write(string.Format("{0:D4} {1:D2} {2}", inst.Index, inst.OperandCount, inst.Form));

                for(var k=0; k<inst.OpCount && j<opcount; k++,j++)
                {
                    ref readonly var op = ref table.Operand(j);
                    //Write(string.Format("  {0:D2} {1}", op.OperandIndex, op.Kind));
                }
            }

            return true;
        }
    }
}