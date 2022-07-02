//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineMap<T>
    {
        readonly Index<LineInterval<T>> Data;

        [MethodImpl(Inline)]
        public LineMap(LineInterval<T>[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<LineInterval<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public uint IntervalCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public uint CountLines()
        {
            var k = 0u;
            for(var i=0; i<Data.Count; i++)
                k += this[i].LineCount;
            return k;
        }

        public ref LineInterval<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref LineInterval<T> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
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

        public static LineMap<T> Empty => new LineMap<T>(sys.empty<LineInterval<T>>());
    }
}