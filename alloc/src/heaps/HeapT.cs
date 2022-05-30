//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Heaps;

    public class Heap<T>
    {
        readonly Index<T> Data;

        readonly Index<uint> Offsets;

        //internal readonly uint LastSegment;

        public readonly uint SegCount;

        [MethodImpl(Inline)]
        public Heap(Index<T> src, uint[] offsets)
        {
            Data = src;
            Offsets = offsets;
            //LastSegment = (uint)offsets.Length - 1;
            SegCount = (uint)Require.equal(src.Length, offsets.Length);
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public ref uint Offset(uint index)
            => ref Offsets[index];

        [MethodImpl(Inline)]
        public Span<T> Segment(uint index)
            => api.segment(this, index);

        public Span<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => Segment(index);
        }
    }
}