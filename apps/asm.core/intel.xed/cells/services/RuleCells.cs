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
        public class RuleCells
        {
            public readonly CellTables CellTables;

            public readonly Index<RuleCellRecord> Records;

            public readonly string Description;

            public readonly Pairings<RuleSig,Index<RuleCell>> TableCells;

            internal RuleCells(Pairings<RuleSig,Index<RuleCell>> cells, CellTables tables, RuleCellRecord[] records, string desc)
            {
                TableCells = cells;
                CellTables = tables;
                Description = desc;
                Records = records;
            }

            RuleCells()
            {
                TableCells = new();
                CellTables = null;
                Description = EmptyString;
                Records = sys.empty<RuleCellRecord>();
            }

            public ref readonly Index<RuleSig> Sigs
            {
                [MethodImpl(Inline)]
                get => ref CellTables.Sigs;
            }

            public ref readonly Index<RuleCell> Values
            {
                [MethodImpl(Inline)]
                get => ref CellTables.Cells();
            }

            // public ReadOnlySpan<CellTable> Tables(params RuleSig[] src)
            // {
            //     var count = src.Length;
            //     var dst = span<CellTable>(count);
            //     var k=0;
            //     for(var i=0; i<src.Length; i++)
            //         if(TableLookup.Find(skip(src,i), out seek(dst,k)))
            //             k++;
            //     return slice(dst,0,k);
            // }

            public uint TableCount
            {
                [MethodImpl(Inline)]
                get => CellTables.TableCount;
            }

            public ref readonly CellTable this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref CellTables[i];
            }

            public ref readonly CellTable this[int i]
            {
                [MethodImpl(Inline)]
                get => ref CellTables[i];
            }

            public string Format()
                => Description;

            public override string ToString()
                => Format();

            public static RuleCells Empty => new();
        }
   }
}