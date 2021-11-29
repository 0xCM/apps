//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines the content of a row
    /// </summary>
    /// <typeparam name="T">The record type</typeparam>
    public struct DynamicRow<T> : IDynamicRow<T>
        where T : struct
    {
        /// <summary>
        /// An extrinsic index/key
        /// </summary>
        public uint RowIndex {get;}

        /// <summary>
        /// The source value
        /// </summary>
        public T Source {get;}

        /// <summary>
        /// The cell values
        /// </summary>
        public dynamic[] Cells {get;}

        [MethodImpl(Inline)]
        public DynamicRow(uint index, in T src, dynamic[] cells)
        {
            RowIndex = index;
            Source = src;
            Cells = cells;
        }

        [MethodImpl(Inline)]
        public DynamicRow<T> UpdateSource(uint index, in T src)
            => new DynamicRow<T>(index, src, Cells);

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Cells.Length;
        }

        public Span<dynamic> Edit
        {
            [MethodImpl(Inline)]
            get => Cells;
        }

        public ReadOnlySpan<dynamic> View
        {
            [MethodImpl(Inline)]
            get => Cells;
        }

        public ref dynamic this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Cells[index];
        }

        public ref dynamic this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Cells[index];
        }
    }
}