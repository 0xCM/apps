//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines storage for contiguous sequence of 5 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1), DataTypeAttributeD("block<n:5,t:{0}>")]
    public struct GBlock5<T> : IStorageBlock<GBlock5<T>>, ICellBlock<GBlock5<T>,T>
        where T : unmanaged
    {
        public const uint CellCount = 5;

        GBlock4<T> A;

        GBlock<T> B;

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<GBlock5<T>,T>(this, CellCount);
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

        public static GBlock5<T> Empty => default;

    }
}