//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using api = memory;

    public readonly struct Heap<K,T>
        where K : unmanaged
    {
        internal readonly Index<T> Segments;

        internal readonly Index<K,uint> Offsets;

        internal readonly uint LastSegment;

        [MethodImpl(Inline)]
        internal Heap(Index<T> segs, Index<K,uint> offsets)
        {
            Segments = segs;
            Offsets = offsets;
            LastSegment = (uint)offsets.Length - 1;
        }

        [MethodImpl(Inline)]
        public Span<T> Segment(K index)
            => api.segment(this, index);

        public Span<T> this[K index]
        {
            [MethodImpl(Inline)]
            get => Segment(index);
        }

        public uint SegCount
        {
            [MethodImpl(Inline)]
            get => Segments.Count;
        }
    }
}