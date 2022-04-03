//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        // static Index<RuleTableRow> CalcTableRows(in RuleTable src)
        // {
        //     var dst = list<RuleTableRow>();
        //     var q = 0u;
        //     for(var i=0u; i<src.Body.Count; i++)
        //     {
        //         ref readonly var expr = ref src.Body[i];
        //         if(expr.IsEmpty || expr.IsVacuous)
        //             continue;

        //         var m = z8;
        //         var row = RuleTableRow.Empty;
        //         row.Kind = src.TableKind;
        //         row.TableName = src.Sig.ShortName;
        //         row.Row = q++;

        //         for(var k=0; k<expr.Premise.Count; k++)
        //         {
        //             row[m] = new RuleTableCell(true, m, src.TableKind, expr.Premise[k]);
        //             m++;
        //         }

        //         m = RuleTableRow.CellCount/2;

        //         for(var k=0; k<expr.Consequent.Count; k++, m++)
        //             row[m] = new RuleTableCell(false, m, src.TableKind, expr.Consequent[k]);

        //         dst.Add(row);
        //     }
        //     return dst.ToArray();
        // }
    }
}