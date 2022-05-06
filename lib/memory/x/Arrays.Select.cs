//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XArray
    {
        /// <summary>
        /// Defines an array-specific select operator
        /// </summary>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        /// <param name="src">The source sequence</param>
        /// <param name="f">The mapping function</param>
        public static T[] Select<S,T>(this S[] src, Func<S,T> f)
        {
            var count = src.Length;
            var dst = new T[count];
            for(var i=0; i<count; i++)
                seek(dst,i) = f(skip(src,i));
            return dst;

            // Span<S> source = src;
            // var count = source.Length;
            // var buffer = new T[count];
            // Span<T> target = buffer;
            // for(var i=0; i<count; i++)
            //     target[i] = f(source[i]);
            // return buffer;
        }

        public static T[] Select<S,T>(this ReadOnlySpan<S> src, Func<S,T> f)
        {
            var count = src.Length;
            var dst = new T[count];
            for(var i=0; i<count; i++)
                seek(dst,i) = f(skip(src,i));
            return dst;
        }
    }
}