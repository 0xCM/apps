//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines storage for contiguous sequence of 32 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1), DataType("block<n:64,t:{0}>")]
    public struct GBlock64<T> : IStorageBlock<GBlock64<T>>, ICellBlock<T>
        where T : unmanaged
    {
        public const uint CellCount = 32;

        GBlock32<T> A;

        GBlock32<T> B;

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<GBlock64<T>,T>(this, CellCount);
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

        public ref T this[int index]
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

        public static GBlock32<T> Empty => default;
    }
}