//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SortedSpans
    {
        [MethodImpl(Inline)]
        public static SortedSpan<T> define<T>(T[] src)
            => new SortedSpan<T>(src);

        [MethodImpl(Inline)]
        public static SortedSpan<T> define<T>(Span<T> src)
            => new SortedSpan<T>(src);

    }
    public readonly ref struct SortedSpan<T>
    {
        readonly Span<T> Data;

        public SortedSpan(T[] src)
        {
            Data = src;
        }

        public SortedSpan(Span<T> src)
        {
            Data = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Data.IsEmpty;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref readonly T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref skip(Data,index);
        }

        public ref readonly T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref skip(Data,index);
        }

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(SortedSpan<T> src)
            => src.View;
    }
}