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

    public readonly ref struct SpanHeap<T>
    {
        internal readonly Span<T> Segments;

        internal readonly Index<uint> Offsets;

        internal readonly uint LastSegment;

        [MethodImpl(Inline)]
        internal SpanHeap(Span<T> segs, uint[] offsets)
        {
            Segments = segs;
            Offsets = offsets;
            LastSegment = (uint)offsets.Length - 1;
        }

        [MethodImpl(Inline)]
        public Span<T> Segment(uint index)
            => api.segment(this, index);

        public ReadOnlySpan<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => Segment(index);
        }

        public uint SegCount
        {
            [MethodImpl(Inline)]
            get => (uint)Segments.Length;
        }
    }
}