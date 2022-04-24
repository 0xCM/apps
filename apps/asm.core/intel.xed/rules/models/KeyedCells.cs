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
            public static KeyedCells create(ConcurrentDictionary<RuleSig,Index<KeyedCell>> src, string desc)
                => new KeyedCells(src,desc);

            public static KeyedCells create(Dictionary<RuleSig,Index<KeyedCell>> src, string desc)
                => new KeyedCells(src.ToConcurrentDictionary(),desc);

            public readonly uint CellCount;

            public readonly string Description;

            public readonly uint TableCount;

            public readonly Index<CellTable> Tables;

            public KeyedCells(ConcurrentDictionary<RuleSig,Index<KeyedCell>> src, string desc)
                : base(src)
            {
                Description = desc;
                TableCount = (uint)src.Count;
                CellCount = src.Values.Map(x => x.Count).Sum();
                Tables = tables(src);
                //Tables = src.Keys.ToArray().Map(x => Table(x)).Index().Sort();
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

            // CellTable Table(RuleSig sig)
            // {
            //     var dst = CellTable.Empty;
            //     if(Find(sig, out var cells))
            //     {
            //         var tix = z16;
            //         if(cells.Count !=0)
            //         {
            //             tix = cells.First.TableId;
            //             var rows = cells.GroupBy(x => x.RowIndex).Select(x => (new CellRow(sig, tix, x.Key, x.ToIndex()))).ToIndex();
            //             dst = new CellTable(sig, tix, rows);
            //         }
            //     }
            //     return dst;
            // }

            public Index<KeyedCell> Flatten()
                => flatten(this);
        }
   }
}