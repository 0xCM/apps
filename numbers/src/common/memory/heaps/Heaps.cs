//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost, Free]
    public class Heaps
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> segment<T>(in Heap<T> src,uint index)
        {
            if(index > src.LastSegment + 1)
                return Span<T>.Empty;
            var start = src.Offsets[index];
            if(index < src.LastSegment)
                return slice(src.Segments.Edit, start, src.Offsets[index + 1] - start);
            else
                return slice(src.Segments.Edit, start);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> segment<T>(in SpanHeap<T> src, uint index)
        {
            if(index > src.LastSegment + 1)
                return Span<T>.Empty;
            var start = src.Offsets[index];
            if(index < src.LastSegment)
                return slice(src.Segments, start, src.Offsets[index + 1] - start);
            else
                return slice(src.Segments, start);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> segment<T>(in ReadOnlyHeap<T> src, uint index)
        {
            if(index > src.LastSegment + 1)
                return ReadOnlySpan<T>.Empty;
            var start = src.Offsets[index];
            if(index < src.LastSegment)
                return slice(src.Segments, start, src.Offsets[index + 1] - start);
            else
                return slice(src.Segments, start);
        }

        [MethodImpl(Inline)]
        public static Span<T> segment<K,T>(Heap<K,T> src, K index)
            where K : unmanaged
        {
            var _index = bw32(index);
            var _next = @as<uint,K>(_index + 1);
            if(_index > src.LastSegment + 1)
                return Span<T>.Empty;
            var start = src.Offsets[index];
            if(_index < src.LastSegment)
                return slice(src.Segments.Edit, start, src.Offsets[_next] - start);
            else
                return slice(src.Segments.Edit, start);
        }

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