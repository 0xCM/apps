//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        public static Grid<T> grid<T>(Dim2<uint> shape)
            => new Grid<T>(new RowGrid<T>(shape),new ColGrid<T>(shape));

        public readonly struct Grids
        {
            [MethodImpl(Inline)]
            public static void CalcRowOffsets<S,T>(Dim2<S> shape, Index<T> dst)
                where S : unmanaged
                where T : unmanaged
            {
                var m = bw64(shape.I);
                var n = bw64(shape.J);
                for(var i=0ul; i<m; i++)
                    dst[i] = @as<T>(i*n);
            }

            [MethodImpl(Inline)]
            public static void CalcColOffsets<S,T>(Dim2<S> shape, Index<T> dst)
                where S : unmanaged
                where T : unmanaged
            {
                var m = bw64(shape.I);
                var n = bw64(shape.J);
                for(var i=0ul; i<n; i++)
                    dst[i] = @as<T>(i*m);
            }

            public static Index<T> CalcRowOffsets<S,T>(Dim2<S> shape, T t = default)
                where S : unmanaged
                where T : unmanaged
            {
                var dst = alloc<T>(bw64(shape.I));
                CalcRowOffsets(shape,dst.Index());
                return dst;
            }

            public static Index<T> CalcRowOffsets<T>(Dim2<T> shape)
                where T : unmanaged
            {
                var dst = alloc<T>(bw64(shape.I));
                CalcRowOffsets(shape,dst.Index());
                return dst;
            }

            public static Index<T> CalcColOffsets<S,T>(Dim2<S> shape, T t = default)
                where S : unmanaged
                where T : unmanaged
            {
                var dst = alloc<T>(bw64(shape.I));
                CalcColOffsets(shape,dst.Index());
                return dst;
            }

            public static Index<T> CalcColOffsets<T>(Dim2<T> shape)
                where T : unmanaged
            {
                var dst = alloc<T>(bw64(shape.I));
                CalcColOffsets(shape,dst.Index());
                return dst;
            }

            // [MethodImpl(Inline)]
            // public static void CalcRowOffsets(Dim2<uint> shape, Index<uint> dst)
            // {
            //     for(uint i=0; i<shape.I; i++)
            //         dst[i] = i*shape.J;
            // }

            // public static Index<uint> CalcRowOffsets(Dim2<uint> shape)
            // {
            //     var dst = alloc<uint>(shape.I);
            //     CalcRowOffsets(shape,dst);
            //     return dst;
            // }

            // [MethodImpl(Inline)]
            // public static void CalcColOffsets(Dim2<uint> shape, Index<uint> dst)
            // {
            //     for(uint i=0; i<shape.J; i++)
            //         dst[i] = i*shape.I;
            // }

            // public static Index<uint> CalcColOffsets(Dim2<uint> shape)
            // {
            //     var dst = alloc<uint>(shape.I);
            //     CalcColOffsets(shape,dst);
            //     return dst;
            // }
        }

        public class RowGrid<T>
        {
            readonly Index<T> Data;

            readonly Index<uint> _Offsets;

            public readonly uint CellCount;

            public readonly uint RowCount;

            public readonly uint ColCount;

            public RowGrid(Dim2<uint> shape)
            {
                RowCount = shape.I;
                ColCount = shape.J;
                CellCount = shape.I*shape.J;
                Data = alloc<T>(CellCount);
                _Offsets = Grids.CalcRowOffsets(shape);
            }

            public Span<T> Cells
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public ref readonly Index<uint> Offsets
            {
                [MethodImpl(Inline)]
                get => ref _Offsets;
            }

            [MethodImpl(Inline)]
            public Span<T> Row(uint row)
                =>  slice(Data.Edit, Offsets[row], ColCount);

            [MethodImpl(Inline)]
            public ref T Cell(uint row, uint col)
                => ref seek(Row(row), col);

            [MethodImpl(Inline)]
            uint index(uint row, uint col)
                => row == 0 ? col : row*ColCount + col;

            public ref T this[uint row, uint col]
            {
                [MethodImpl(Inline)]
                get => ref Data[index(row,col)];
            }

            public ColGrid<T> Columns()
                => new ColGrid<T>(this);
        }

        public class ColGrid<T>
        {
            readonly Index<T> Data;

            readonly Index<uint> _Offsets;

            public readonly uint CellCount;

            public readonly uint RowCount;

            public readonly uint ColCount;

            public ColGrid(RowGrid<T> src)
            {
                CellCount = src.CellCount;
                RowCount = src.RowCount;
                ColCount = src.ColCount;
                Data = alloc<T>(CellCount);
                _Offsets = Grids.CalcColOffsets(new Dim2<uint>(src.RowCount,src.ColCount));
                for(var j=0u; j<RowCount; j++)
                    for(var i=0u; i<ColCount; i++)
                        this[j,i] = src[i,j];
            }

            public ColGrid(Dim2<uint> shape)
            {
                RowCount = shape.I;
                ColCount = shape.J;
                CellCount = shape.I*shape.J;
                Data = alloc<T>(CellCount);
                _Offsets = Grids.CalcColOffsets(shape);
            }

            public ref readonly Index<uint> Offsets
            {
                [MethodImpl(Inline)]
                get => ref _Offsets;
            }

            public Span<T> Cells
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            [MethodImpl(Inline)]
            public Span<T> Col(uint col)
                =>  slice(Data.Edit, Offsets[col], RowCount);

            [MethodImpl(Inline)]
            public ref T Cell(uint row, uint col)
                => ref seek(Col(col), row);

            public ref T this[uint row, uint col]
            {
                [MethodImpl(Inline)]
                get => ref Cell(row,col);
            }
        }

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