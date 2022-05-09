//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class CellTables
        {
            public static CellTables calc(CellTable[] src)
            {
                var kTables = (uint)src.Length;
                var kRows = src.Select(x => x.RowCount).Sum();
                var kCells = src.Select(x => x.CellCount()).Sum();
                var dst = new CellTables(kTables, kRows, kCells);
                dst._Tables = src.Sort();
                dst._Cells = src.SelectMany(x => x.Rows.SelectMany(x => x.Cells)).Sort();
                dst._Sigs = src.Select(x => x.Sig).Sort();
                return dst;
            }

            Index<CellTable> _Tables;

            Index<RuleCell> _Cells;

            Index<RuleSig> _Sigs;

            /// <summary>
            /// Specifies the number of defined tables
            /// </summary>
            public readonly uint TableCount;

            /// <summary>
            /// Specifies the aggregate number of table-defind rows
            /// </summary>
            public readonly uint RowCount;

            /// <summary>
            /// Specifies the aggregate number of row-defind cells
            /// </summary>
            public readonly uint CellCount;

            [MethodImpl(Inline)]
            CellTables(uint tables, uint rows, uint cells)
            {
                TableCount = tables;
                RowCount = rows;
                CellCount = cells;
            }

            public ReadOnlySpan<CellTable> View
            {
                [MethodImpl(Inline)]
                get => _Tables.Edit;
            }

            public ref readonly CellTable this[int i]
            {
                [MethodImpl(Inline)]
                get => ref _Tables[i];
            }

            public ref readonly CellTable this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref _Tables[i];
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => _Tables.Count;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => _Tables.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => _Tables.IsNonEmpty;
            }

            /// <summary>
            /// Specifies the <see cref='RuleSig'/> for each defined table
            /// </summary>
            public ref readonly Index<RuleSig> Sigs
            {
                [MethodImpl(Inline)]
                get => ref _Sigs;
            }

            /// <summary>
            /// Returns the defined <cref='RuleCell'/> values
            /// </summary>
            [MethodImpl(Inline)]
            public ref readonly Index<RuleCell> Cells()
                => ref _Cells;

            /// <summary>
            /// Returns the see <cref='RuleSig'/> that is a logical identifier for an index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            [MethodImpl(Inline)]
            public ref readonly RuleSig Sig(int table)
                => ref _Tables[table].Sig;

            /// <summary>
            /// Returns the see <cref='RuleSig'/> that is a logical identifier for an index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            [MethodImpl(Inline)]
            public ref readonly RuleSig Sig(uint table)
                => ref _Tables[table].Sig;

            /// <summary>
            /// Returns the rows defined by an index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            [MethodImpl(Inline)]
            public ref readonly Index<CellRow> Rows(int table)
                => ref _Tables[table].Rows;

            /// <summary>
            /// Returns the rows defined by an index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            [MethodImpl(Inline)]
            public ref readonly Index<CellRow> Rows(uint table)
                => ref _Tables[table].Rows;

            /// <summary>
            ///  Returns the index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            /// <param name="row">The table-relative row index</param>
            [MethodImpl(Inline)]
            public ref readonly CellRow Row(int table, int row)
                => ref _Tables[table].Rows[row];

            /// <summary>
            ///  Returns the index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            /// <param name="row">The table-relative row index</param>
            [MethodImpl(Inline)]
            public ref readonly CellRow Row(uint table, uint row)
                => ref _Tables[table].Rows[row];

            /// <summary>
            /// Returns the <see cref='RuleCell'/> values defined by an index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            /// <param name="row">The table-relative row index</param>
            [MethodImpl(Inline)]
            public ref readonly Index<RuleCell> Cells(int table, int row)
                => ref _Tables[table].Rows[row].Cells;

            /// <summary>
            /// Returns the <see cref='RuleCell'/> values defined by an index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            /// <param name="row">The table-relative row index</param>
            [MethodImpl(Inline)]
            public ref readonly Index<RuleCell> Cells(uint table, uint row)
                => ref _Tables[table].Rows[row].Cells;

            /// <summary>
            /// Returns the index-identified <see cref='RuleCell'/> defined by an index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            /// <param name="row">The table-relative row index</param>
            /// <param name="cell">The row-relative cell index</param>
            [MethodImpl(Inline)]
            public ref readonly RuleCell Cell(uint table, uint row, uint cell)
                => ref _Tables[table].Rows[row].Cells[cell];

            /// <summary>
            /// Returns the index-identified <see cref='RuleCell'/> defined by an index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
            /// </summary>
            /// <param name="table">The table index</param>
            /// <param name="row">The table-relative row index</param>
            /// <param name="cell">The row-relative cell index</param>
            [MethodImpl(Inline)]
            public ref readonly RuleCell Cell(int table, int row, int cell)
                => ref _Tables[table].Rows[row].Cells[cell];

            public string Format()
                => CellRender.Tables.format(this);

            public override string ToString()
                => Format();
        }
    }
}