//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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
            Span<S> source = src;
            var count = source.Length;
            var buffer = new T[count];
            Span<T> target = buffer;
            for(var i=0; i<count; i++)
                target[i] = f(source[i]);
            return buffer;
        }

        public static Span<T> Select<S,T>(this ReadOnlySpan<S> src, Func<S,T> f)
        {
            var count = src.Length;
            var buffer = new T[count];
            Span<T> target = buffer;
            for(var i=0; i<count; i++)
                target[i] = f(src[i]);
            return target;
        }
    }
}