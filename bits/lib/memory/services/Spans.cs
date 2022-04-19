//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Spans
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Declares a span to be sorted
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SortedReadOnlySpan<T> sorted<T>(ReadOnlySpan<T> src)
            => new SortedReadOnlySpan<T>(src);
    }
}