//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    partial class XedRules
    {
        public class CellDatasets
        {
            public static RuleCells load(Dictionary<RuleSig,Index<RuleCell>> src, string desc)
            {
                return new RuleCells(CellTables.from(CellDatasets.create(src)), desc);
            }

            public static CellDatasets create(Dictionary<RuleSig,Index<RuleCell>> src)
            {
                var dst = new CellDatasets();
                var cdict = src.ToConcurrentDictionary();
                var data = cdict.Keys.Select(sig => table(cdict,sig)).Array();
                dst.TableCount = (ushort)data.Length;
                dst.RowCount = (ushort)data.Select(x => x.RowCount).Sum();
                dst.CellCount = (ushort)data.Select(x => x.CellCount()).Sum();
                dst._Tables = data.Sort();
                dst._Cells = data.SelectMany(x => x.Rows.SelectMany(x => x.Cells)).Sort();
                dst._Sigs = data.Select(x => x.Sig).Sort();
                dst._TableCells = core.pairings(src.Map(x => paired(x.Key,x.Value)));
                return dst;
            }

            static CellTable table(ConcurrentDictionary<RuleSig,Index<RuleCell>> src, RuleSig rule)
            {
                var dst = CellTable.Empty;
                if(src.TryGetValue(rule, out var cells))
                {
                    var i = z16;
                    if(cells.Count !=0)
                    {
                        i = cells.First.TableIndex;
                        var rows = cells.GroupBy(x => x.RowIndex).Select(x => (new CellRow(rule, i, x.Key, x.ToIndex()))).ToIndex();
                        dst = new CellTable(rule, i, rows);
                    }
                }
                return dst;
            }

            CellDatasets()
            {
            }


            Index<CellTable> _Tables;

            Index<RuleCell> _Cells;

            Index<RuleSig> _Sigs;

            Pairings<RuleSig,Index<RuleCell>> _TableCells;

            public ushort TableCount;

            public ushort RowCount;

            public ushort CellCount;

            [MethodImpl(Inline)]
            public ref readonly Index<CellTable> Tables()
                => ref _Tables;

            [MethodImpl(Inline)]
            public ref readonly Index<RuleSig> Sigs()
                => ref _Sigs;

            [MethodImpl(Inline)]
            public ref readonly Index<RuleCell> Cells()
                => ref _Cells;

            [MethodImpl(Inline)]
            public ref readonly Pairings<RuleSig,Index<RuleCell>> TableCells()
                => ref _TableCells;
        }
    }
}