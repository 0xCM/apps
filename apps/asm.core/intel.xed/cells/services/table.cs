//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XedRules
    {
        public static Index<CellTable> tables(ConcurrentDictionary<RuleSig,Index<RuleCell>> src)
            => src.Keys.Array().Select(sig => table(src,sig)).Index().Sort();

        static CellTable table(ConcurrentDictionary<RuleSig,Index<RuleCell>> src, RuleSig rule)
        {
            var dst = CellTable.Empty;
            if(src.TryGetValue(rule, out var cells))
            {
                var tix = z16;
                if(cells.Count !=0)
                {
                    tix = cells.First.TableIndex;
                    var rows = cells.GroupBy(x => x.RowIndex).Select(x => (new CellRow(rule, tix, x.Key, x.ToIndex()))).ToIndex();
                    dst = new CellTable(rule, tix, rows);
                }
            }
            return dst;
        }
    }
}