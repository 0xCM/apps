//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class RuleCells
        {
            public readonly Index<RuleSig> Sigs;

            public readonly Index<CellTable> Tables;

            public readonly CellMetrics Metrics;

            public readonly Index<RuleCellRecord> Records;

            public readonly string Description;

            public readonly Pairings<RuleSig,Index<RuleCell>> TableCells;

            public readonly Index<RuleCell> Values;

            public readonly uint RowCount;

            internal RuleCells(Pairings<RuleSig,Index<RuleCell>> cells, CellTable[] tables, CellMetrics metrics, RuleCellRecord[] records, string desc)
            {
                Values = RuleTables.flat(cells);
                TableCells = cells;
                Sigs = tables.Select(x => x.Sig).Sort();
                Tables = tables;
                Metrics = metrics;
                Description = desc;
                Records = records;
                RowCount = tables.Select(t => t.RowCount).Sum();
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => Values.Count;
            }

            public uint TableCount
            {
                [MethodImpl(Inline)]
                get => Tables.Count;
            }

            public ref readonly CellTable this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Tables[i];
            }

            public ref readonly CellTable this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Tables[i];
            }

            public string Format()
                => Description;

            public override string ToString()
                => Format();
        }
   }
}