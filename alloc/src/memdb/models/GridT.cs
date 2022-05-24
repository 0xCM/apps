//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        public class Grid<T>
        {
            readonly RowGrid<T> RowData;

            readonly ColGrid<T> ColData;

            [MethodImpl(Inline)]
            public Grid(RowGrid<T> rows, ColGrid<T> cols)
            {
                RowData = rows;
                ColData = cols;
            }

            public ref readonly RowGrid<T> Rows
            {
                [MethodImpl(Inline)]
                get => ref RowData;
            }

            public ref readonly ColGrid<T> Cols
            {
                [MethodImpl(Inline)]
                get => ref ColData;
            }

            [MethodImpl(Inline)]
            public Span<T> Col(uint col)
                => ColData.Col(col);

            [MethodImpl(Inline)]
            public Span<T> Row(uint col)
                => RowData.Row(col);

            [MethodImpl(Inline)]
            public ref T ColCell(uint row, uint col)
                => ref ColData[row,col];

            [MethodImpl(Inline)]
            public ref T ColCell(uint row, uint col, ref T cell)
            {
                cell = ColData[row,col];
                return ref cell;
            }

            [MethodImpl(Inline)]
            public ref T RowCell(uint row, uint col)
                => ref RowData[row,col];

            [MethodImpl(Inline)]
            public ref T RowCell(uint row, uint col, ref T cell)
            {
                cell = RowData[row,col];
                return ref cell;
            }

            [MethodImpl(Inline)]
            public void Store(in T src, uint row, uint col)
            {
                RowCell(row,col) = src;
                ColCell(row,col) = src;
            }
        }
    }
}