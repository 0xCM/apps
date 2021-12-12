//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct gcalc
    {
        /// <summary>
        /// Presents an index-identifeid histogram bucket as an interval
        /// </summary>
        /// <param name="src">The histogram to search</param>
        /// <param name="index">THe bucket index</param>
        /// <typeparam name="T">The point domain</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ClosedInterval<T> segment<T>(in Histogram<T> src, uint index)
            where T : unmanaged, IComparable<T>
                => (point(src, index-1), point(src, index));
    }
}