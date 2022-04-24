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
        public readonly struct CellTables
        {
            public static CellTables allocate(KeyedCells src)
            {
                var sigs = src.Keys;
                var buffer = alloc<CellTable>(src.TableCount);
                var kCellTotal = 0u;
                var tix = z16;
                for(var i=z16; i<src.TableCount; i++)
                {
                    ref var table = ref seek(buffer,i);
                    ref readonly var sig = ref skip(sigs,i);
                    var cells = src[skip(sigs,i)];

                    var kRows = 0u;
                    var kRowCells = dict<ushort,byte>();
                    var rix = z16;
                    var counter = z8;
                    for(var j=z16; j<cells.Count; j++, counter++)
                    {
                        ref readonly var cell = ref cells[j];
                        if(cell.RowIndex != rix)
                        {
                            kRowCells[rix] = counter;
                            counter = 0;
                            rix = cell.RowIndex;
                            kRows++;
                        }

                        if(j == cells.Count - 1)
                        {
                            kRowCells[rix] = counter;
                            counter = 0;
                            kRows++;
                        }
                    }

                    if(kRows == 0)
                        table = new (sig, tix++, sys.empty<CellRow>());
                    else
                    {
                        table = new (sig, tix++, alloc<CellRow>(kRows));
                        Require.equal(table.RowCount, (uint)(kRowCells.Count));
                        for(var j=z16; j<kRows; j++)
                        {
                            ref var row = ref table[j];
                            var cellcount = kRowCells[j];
                            row = new CellRow(sig, i, j, alloc<KeyedCell>(cellcount));
                            Require.equal(row.CellCount, cellcount);
                            kCellTotal += cellcount;
                        }
                    }
                }

                var dst = new CellTables(buffer);
                Require.equal(dst.CellCount(), kCellTotal);
                //Require.equal(dst.CellCount(), src.CellCount);
                return buffer;
            }

            readonly Index<CellTable> Data;

            [MethodImpl(Inline)]
            public CellTables(CellTable[] src)
            {
                Data = src;
            }

            public Span<CellTable> Edit
            {
                [MethodImpl(Inline)]
                get => Data.Edit;
            }

            public ReadOnlySpan<CellTable> View
            {
                [MethodImpl(Inline)]
                get => Data.Edit;
            }

            public CellTable[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public ref CellTable this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref CellTable this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public uint TableCount
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public uint RowCount()
                => Data.Select(x => x.RowCount).Storage.Sum();

            public uint CellCount()
                => Data.Select(x => x.CellCount()).Storage.Sum();

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public string Format()
                => CellRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator CellTables(CellTable[] src)
                => new CellTables(src);

            [MethodImpl(Inline)]
            public static implicit operator CellTable[](CellTables src)
                => src.Data;

            public static CellTables Empty => new CellTables(sys.empty<CellTable>());
        }
    }
}