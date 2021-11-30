//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using static minicore;

    public readonly struct LineMap<T>
    {
        readonly LineInterval<T>[] _Intervals;

        [MethodImpl(Inline)]
        public LineMap(LineInterval<T>[] src)
        {
            _Intervals = src;
        }

        public Span<LineInterval<T>> Intervals
        {
            [MethodImpl(Inline)]
            get => _Intervals;
        }

        public uint IntervalCount
        {
            [MethodImpl(Inline)]
            get => (uint)(_Intervals?.Length ?? 0);
        }

        public uint LineCount
        {
            get
            {
                var k = 0u;
                var src = Intervals;
                for(var i=0; i<src.Length; i++)
                    k += src[i].LineCount;
                return k;
            }
        }

        public ref LineInterval<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(_Intervals,i);
        }

        public ref LineInterval<T> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(_Intervals,i);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => IntervalCount == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => IntervalCount != 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator LineMap<T>(LineInterval<T>[] src)
            => new LineMap<T>(src);

        public static LineMap<T> Empty
        {
            get => new LineMap<T>(Array.Empty<LineInterval<T>>());
        }
    }
}