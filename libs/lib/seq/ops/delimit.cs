//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedSpan<T> delimit<T>(char delimiter, int pad, Span<T> src)
            => new DelimitedSpan<T>(src, delimiter, pad);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedSpan<T> delimit<T>(char delimiter, int pad, ReadOnlySpan<T> src)
            => new DelimitedSpan<T>(src, delimiter, pad);
    }
}