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
        public class KeyedCells : SortedLookup<RuleSig,Index<KeyedCell>>
        {
            public static KeyedCells create(Dictionary<RuleSig,Index<KeyedCell>> src, string desc)
            {
                var _src = src.ToConcurrentDictionary();
                var data = tables(_src);
                var metrics = new CellMetrics();
                metrics.TableCount = (ushort)src.Count;
                metrics.CellCount = _src.Values.Map(x => x.Count).Sum();
                metrics.RowCounts = data.Select(x => (ushort)x.RowCount);
                metrics.RowCount = data.Select(x => x.RowCount).Storage.Sum();
                return new KeyedCells(_src, data, metrics, desc);
            }

            static Index<CellTable> tables(ConcurrentDictionary<RuleSig,Index<KeyedCell>> src)
                => src.Keys.Array().Select(sig => table(src,sig)).Index().Sort();

            static CellTable table(ConcurrentDictionary<RuleSig,Index<KeyedCell>> src, RuleSig sig)
            {
                var dst = CellTable.Empty;
                if(src.TryGetValue(sig, out var cells))
                {
                    var tix = z16;
                    if(cells.Count !=0)
                    {
                        tix = cells.First.TableIndex;
                        var rows = cells.GroupBy(x => x.RowIndex).Select(x => (new CellRow(sig, tix, x.Key, x.ToIndex()))).ToIndex();
                        dst = new CellTable(sig, tix, rows);
                    }
                }
                return dst;
            }

            /// <summary>
            /// Specifies the indexed tables
            /// </summary>
            public readonly Index<CellTable> Tables;

            /// <summary>
            /// Specifies dataset characteristics
            /// </summary>
            public readonly CellMetrics Metrics;

            /// <summary>
            /// Describes the dataset
            /// </summary>
            public readonly string Description;

            public KeyedCells(ConcurrentDictionary<RuleSig,Index<KeyedCell>> src, Index<CellTable> tables, CellMetrics metrics, string desc)
                : base(src)
            {
                Description = desc;
                Tables = tables;
                Metrics = metrics;
                Description = desc;
            }

            public Index<KeyedCell> Flatten()
                => flatten(this);
        }
   }
}