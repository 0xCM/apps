//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    //[ApiHost]
    public readonly struct ArrayUtil
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Allocates and populates a new array by filtering the source array with a specified predicate
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="f">The predicate</param>
        /// <typeparam name="T">The array element type</typeparam>
        [Op, Closures(Closure)]
        public static T[] where<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        {
            var count = src.Length;
            Span<T> dst = new T[count];
            var j = 0;
            for(var i=0; i<count; i++)
            {
                ref readonly var test = ref src[i];
                if(f(test))
                    dst[j++] = test;
            }
            return dst.Slice(0, (int)j).ToArray();
        }

        [Op, Closures(Closure)]
        public static T single<T>(T[] src)
        {
            var count = src.Length;
            if(count != 1)
                throw new Exception($"There are {src.Length} elements where there should be exactly 1");
            else
                return src[0];
        }

        /// <summary>
        /// Applies a function to an input sequence to yield a transformed output sequence
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T[] map<S,T>(S[] src, Func<S,T> f)
        {
            Span<S> source = src;
            var count = source.Length;
            var buffer = new T[count];
            Span<T> target = buffer;
            for(var i=0; i<count; i++)
                target[i] = f(source[i]);
            return buffer;
        }
    }
}