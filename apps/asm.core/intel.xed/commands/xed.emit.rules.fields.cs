//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedCmdProvider
    {
        // [CmdOp("xed/emit/rules/fields")]
        // Outcome EmitRuleFields(CmdArgs args)
        // {
        //     var cells = CalcRuleCells();
        //     var tables = cells.Tables;
        //     var dst = text.buffer();
        //     var counter = 0;
        //     for(var i=0; i<tables.Count; i++)
        //     {
        //         ref readonly var table = ref tables[i];
        //         for(var j=0; j<table.RowCount; j++)
        //         {
        //             ref readonly var row = ref table[j];
        //             var fields = RuleGrids.cells(row);
        //             dst.AppendFormat("{0,-32} | ", table.Sig);
        //             dst.AppendFormat("{0:D3}", row.RowIndex);

        //             for(var k=0; k<fields.Count; k++)
        //             {
        //                 ref readonly var field = ref fields[k];
        //                 dst.AppendFormat(" | {0,-4}", (uint)field.Size.Aligned.Size.Bits);
        //                 dst.AppendFormat(" | {0,-4}", (uint)field.Size.Packed);
        //                 dst.AppendFormat(" | {0,-26}", field.Field);
        //             }
        //             dst.AppendLine();

        //             counter++;
        //         }
        //     }

        //     FileEmit(dst.Emit(), counter, XedPaths.RuleTarget("tables.fields", FS.Txt));

        //     return true;
        // }
    }
}