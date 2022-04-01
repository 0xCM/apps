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
        public static Index<RuleTableRow> CalcCells(in RuleTable def, ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> dst)
        {
            var rows = CalcTableRows(def);
            var count = rows.Count;
            var pFields = hashset<RuleCellSpec>();
            var cFields = hashset<RuleCellSpec>();
            for(var j=0; j<count; j++)
            {
                ref readonly var row = ref rows[j];
                CalcCells(row, 'P', pFields);
                CalcCells(row, 'C', cFields);
            }

            var fields = list<RuleCellSpec>();
            fields.AddRange(pFields);
            fields.AddRange(cFields);
            dst[def.Sig] = fields.ToArray().Sort();
            return rows;
        }

        static void CalcCells(in RuleTableRow src, char logic, HashSet<RuleCellSpec> dst)
        {
            var storage = 0ul;
            var count = RuleTableRow.CellCount/2;
            var i = logic == 'P' ? z8 : count;
            var k = z8;
            for(var j=0; j<count; j++, i++)
            {
                var cell = src[i];
                if(cell.IsNonEmpty)
                    dst.Add(new RuleCellSpec(logic=='P', cell.TableKind, cell.Criterion.DataKind, cell.Criterion.Field));
            }
        }
    }
}