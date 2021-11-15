//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Arrays
    {
        /// <summary>
        /// Allocates and populates a new array by filtering the source array with a specified predicate
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="f">The predicate</param>
        /// <typeparam name="T">The array element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] where<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        {
            var length = src.Length;
            Span<T> dst = new T[length];
            var count = 0;
            for(var i=0; i<length; i++)
            {
                ref readonly var test = ref src[i];
                if(f(test))
                    dst[count++] = test;
            }
            return dst.Slice(0, (int)count).ToArray();
        }
   }
}