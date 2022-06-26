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
        /// Allocates and populates a new array by filtering the source array with a specified predicate
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="f">The predicate</param>
        /// <typeparam name="T">The array element type</typeparam>
        [Op, Closures(Closure)]
        public static Span<T> where<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        {
            var count = Arrays.count(src,f);
            Span<T> dst = alloc<T>(count);
            var k = 0;
            for(var i=0; i<src.Length; i++)
            {
                if(f(skip(src,i)))
                    seek(dst,k++) = skip(src,i);
            }
            return slice(dst,0,k);
        }

        /// <summary>
        /// Declares a span to be sorted
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SortedReadOnlySpan<T> sorted<T>(ReadOnlySpan<T> src)
            => new SortedReadOnlySpan<T>(src);

        [MethodImpl(Inline)]
        public static bool equal<T,C>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, C comparer)
            where C : IEqualityComparer<T>
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            if(count == 0)
                return true;

            for(var i=0; i<count; i++)
                if(!comparer.Equals(skip(a,i), skip(b,i)))
                    return false;

            return true;
        }
    }
}