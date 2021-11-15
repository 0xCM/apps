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

    unsafe partial struct memory
    {
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

    }
}