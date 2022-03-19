//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public static Index<RuleTableRow> rows(in RuleTable src)
        {
            const byte ColCount = RuleTableRow.ColCount;

            var dst = list<RuleTableRow>();
            var q = 0u;
            for(var i=0u; i<src.Body.Count; i++)
            {
                ref readonly var expr = ref src.Body[i];
                if(expr.IsEmpty || expr.IsVacuous || expr.IsNull || expr.IsError)
                    continue;

                var m = z8;
                var row = RuleTableRow.Empty;
                row.TableKind = src.TableKind;
                row.TableName = src.Sig.Name;
                row.RowIndex = q++;

                for(var k=0; k<expr.Premise.Count; k++)
                {
                    row[m] = new RuleTableCell(src.TableKind, m, expr.Premise[k]);
                    m++;
                }

                m = ColCount/2;

                for(var k=0; k<expr.Consequent.Count; k++, m++)
                    row[m] = new RuleTableCell(src.TableKind, m, expr.Consequent[k]);

                dst.Add(row);
            }
            return dst.ToArray();
        }
    }
}