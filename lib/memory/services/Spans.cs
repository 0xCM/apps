//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

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

        [MethodImpl(Inline)]
        public static bool equal<T,C>(ReadOnlySpan<T> src, ReadOnlySpan<T> dst, C comparer)
            where C : IEqualityComparer<T>
        {
            var count = src.Length;
            if(count != dst.Length)
                return false;

            if(count == 0)
                return true;

            ref readonly var a = ref first(src);
            ref readonly var b = ref first(dst);
            for(var i=0; i<count; i++)
                if(!comparer.Equals(skip(a,i),skip(b,i)))
                    return false;

            return true;
        }
    }
}