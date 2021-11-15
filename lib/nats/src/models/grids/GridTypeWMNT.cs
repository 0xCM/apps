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

    /// <summary>
    /// Charcterizes a W/T grid of natural dimensions MxN
    /// </summary>
    /// <typeparam name="W">The total grid width</typeparam>
    /// <typeparam name="M">The row count type</typeparam>
    /// <typeparam name="N">The column count type</typeparam>
    /// <typeparam name="T">The storage cell type</typeparam>
    public readonly struct GridType<W,M,N,T>
        where W : unmanaged, IDataWidth
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        /// <summary>
        /// The grid bit-widht
        /// </summary>
        public BitWidth GridWidth
        {
            [MethodImpl(Inline)]
            get => (uint)default(W).DataWidth;
        }

        /// <summary>
        /// The grid size in bytes
        /// </summary>
        public ByteSize GridSize
        {
            [MethodImpl(Inline)]
            get => (ByteSize)GridWidth;
        }

        /// <summary>
        /// Specifies the number of cells covered by a T-block
        /// </summary>
        public uint BlockLength
        {
            [MethodImpl(Inline)]
            get => (uint)CellCalcs.blocklength<W,T>();
        }

        /// <summary>
        /// Specifies the M-identified number of rows in the grid
        /// </summary>
        public uint RowCount
        {
            [MethodImpl(Inline)]
            get=> (uint)default(M).NatValue;
        }

        /// <summary>
        /// Specifies the number of N-columns in the grid
        /// </summary>
        public uint ColCount
        {
            [MethodImpl(Inline)]
            get => (uint)default(N).NatValue;
        }

        /// <summary>
        /// Specifies the bit width of a T-cell
        /// </summary>
        public uint CellWidth
        {
            [MethodImpl(Inline)]
            get => width<T>();
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)CellCalcs.cells<W,T>();
        }
    }
}