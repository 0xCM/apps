//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct gcalc
    {
        /// <summary>
        /// Findes the number of items in an index-identified bucket
        /// </summary>
        /// <param name="src">The histogram to query</param>
        /// <param name="index">THe bucket index</param>
        /// <typeparam name="T">The point domain</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(in Histogram<T> src, uint index)
            where T : unmanaged, IComparable<T>
                => (uint)src.Counts[index-1];

        /// <summary>
        /// Computes the total number of elements produced by a supplied factory operating over a supplied source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="f">The factory operator</param>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op]
        public static uint count<S,T>(ReadOnlySpan<S> src, IReadOnlySpanFactory<S,T> f)
        {
            var total = 0u;
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                var output = f.Invoke(input);
                count += (uint)output.Length;
            }
            return total;
        }

    }
}