//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RangePattern<T> : IDataPattern<ClosedInterval<T>>
        where T : unmanaged, IComparable<T>
    {
        public readonly T Min;

        public readonly T Max;

        public MatchKind MatchKind => MatchKind.Enabled;

        [MethodImpl(Inline)]
        public RangePattern(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public ClosedInterval<T> State
        {
            [MethodImpl(Inline)]
            get => (Min,Max);
        }

        [MethodImpl(Inline)]
        public static implicit operator RangePattern<T>((T min, T max) src)
            => new RangePattern<T>(src.min, src.max);
    }
}