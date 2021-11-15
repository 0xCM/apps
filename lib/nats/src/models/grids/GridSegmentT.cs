//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static CharText;

    public readonly struct GridSegment<T> : IDataType<T>
        where T : unmanaged
    {
        /// <summary>
        /// The grid dimension
        /// </summary>
        public GridDim Dim {get;}

        /// <summary>
        /// The bit-width of a grid cell
        /// </summary>
        public uint CellWidth {get;}

        /// <summary>
        /// The bit-width of a segment that covers one or more cells
        /// </summary>
        public uint SegWidth {get;}

        [MethodImpl(Inline)]
        public GridSegment(GridDim dim, uint segwidth)
        {
            Dim = dim;
            SegWidth = segwidth;
            CellWidth = width<T>();
        }

        /// <summary>
        /// Returns a dimension expression of the form {RowCount}x{ColCount}x{CellWidth}{[SegWidth]} where
        /// R := row count
        /// C := column count
        /// W := cell width
        /// </summary>
        public string Format()
            => $"{Dim}x{CellWidth}[{SegWidth}]";

        public override string ToString()
            => Format();

        public static RenderTemplate RT
            => fLT + nameof(Dim) + fRT + x
             + fLT + nameof(CellWidth) + fRT + x
             + fLT + fRB + nameof(SegWidth) + fRT + fRB
             ;
    }
}