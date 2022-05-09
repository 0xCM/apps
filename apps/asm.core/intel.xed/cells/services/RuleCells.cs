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
            public readonly Index<RuleSig> Sigs;

            public readonly Index<CellTable> CellTables;

            public readonly Index<RuleCellRecord> Records;

            public readonly string Description;

            public readonly Pairings<RuleSig,Index<RuleCell>> TableCells;

            public readonly Index<RuleCell> Values;

            public readonly uint RowCount;

            readonly ConstLookup<RuleSig,CellTable> TableLookup;

            internal RuleCells(Pairings<RuleSig,Index<RuleCell>> cells, CellTable[] tables, RuleCellRecord[] records, string desc)
            {
                Values = RuleTables.linearize(cells);
                TableCells = cells;
                Sigs = tables.Select(x => x.Sig).Sort();
                CellTables = tables;
                Description = desc;
                Records = records;
                RowCount = tables.Select(t => t.RowCount).Sum();
                TableLookup = RuleTables.lookup(tables);
            }

            RuleCells()
            {
                Values = sys.empty<RuleCell>();
                TableCells = new();
                Sigs = sys.empty<RuleSig>();
                CellTables = sys.empty<CellTable>();
                Description = EmptyString;
                Records = sys.empty<RuleCellRecord>();
                RowCount = 0;
                TableLookup = dict<RuleSig,CellTable>();
            }

            public ReadOnlySpan<CellTable> Tables(params RuleSig[] src)
            {
                var count = src.Length;
                var dst = span<CellTable>(count);
                var k=0;
                for(var i=0; i<src.Length; i++)
                    if(TableLookup.Find(skip(src,i), out seek(dst,k)))
                        k++;
                return slice(dst,0,k);
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => Values.Count;
            }

            public uint TableCount
            {
                [MethodImpl(Inline)]
                get => CellTables.Count;
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