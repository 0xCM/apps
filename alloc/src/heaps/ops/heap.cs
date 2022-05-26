//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Heaps
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Heap<T> heap<T>(T[] segments, uint[] offsets)
            => new Heap<T>(segments, offsets);

        [MethodImpl(Inline)]
        public static Heap<K,T> heap<K,T>(T[] segments, Index<K,uint> offsets)
            where K : unmanaged
                => new Heap<K,T>(segments, offsets);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanHeap<T> heap<T>(Span<T> segments, uint[] offsets)
            => new SpanHeap<T>(segments, offsets);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlyHeap<T> heap<T>(ReadOnlySpan<T> segments, uint[] offsets)
            => new ReadOnlyHeap<T>(segments, offsets);
    }
}