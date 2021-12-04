//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Represents a finite sequence of 8-bit values
    /// </summary>
    public struct vNx8<T> : IVector<T>
        where T : unmanaged
    {
        readonly Index<T> Data;

        [MethodImpl(Inline)]
        internal vNx8(T[] cells)
        {
            Data = cells;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public ref T Cell(uint index)
            => ref Data[index];

        BitWidth ISizedType.StorageWidth
            => Data.Length*width<T>();

        BitWidth ISizedType.ContentWidth
            => Data.Length*8;
    }
}