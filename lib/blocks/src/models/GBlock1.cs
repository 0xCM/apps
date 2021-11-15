//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines storage for a T-cell
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock1<T> : IDataBlock<GBlock1<T>>, ICellBlock<GBlock1<T>,T>
        where T : unmanaged
    {
        public const uint CellCount = 1;

        T Data;

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<GBlock1<T>,T>(this, CellCount);
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref first(Cells);
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First, index);
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public ByteSize Size
            => CellCount*size<T>();

        public static GBlock1<T> Empty => default;

    }
}