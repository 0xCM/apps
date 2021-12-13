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

    using api = Intervals;

    /// <summary>
    /// Defines a segmented partition over a contiguous buffer
    /// </summary>
    public ref struct ClosedIntervals<T>
        where T : unmanaged
    {
        readonly Index<T> Buffer;

        public Index<ClosedInterval<uint>> Ranges;

        public uint SegCount;

        [MethodImpl(Inline)]
        public ClosedIntervals(Index<T> buffer, uint max)
        {
            Buffer = buffer;
            Ranges = alloc<ClosedInterval<uint>>(max);
            SegCount = 0;
        }

        [MethodImpl(Inline)]
        public ClosedIntervals(Index<T> buffer, Index<ClosedInterval<uint>> ranges)
        {
            Buffer = buffer;
            Ranges = ranges;
            SegCount = 0;
        }

        public uint MaxSegCount
        {
            [MethodImpl(Inline)]
            get => (uint)Ranges.Length;
        }

        [MethodImpl(Inline)]
        public ref ClosedInterval<uint> Range(byte index)
            => ref Ranges[index];

        [MethodImpl(Inline)]
        public ref ClosedInterval<uint> Range(uint index)
            => ref Ranges[index];

        [MethodImpl(Inline)]
        public void Range(uint index, uint i0, uint i1)
            => Range(index) = (i0,i1);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
   }
}