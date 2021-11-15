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

    partial struct Intervals
    {
        /// <summary>
        /// Determines whether a test point is within an interval defined by inclusive lower/upper bounds
        /// </summary>
        /// <param name="test">The point to test</param>
        /// <param name="min">The inclusive lower bound</param>
        /// <param name="max">The inclusive upper bound</param>
        [MethodImpl(Inline), Op]
        public static bool between(ulong test, ulong min, ulong max)
            => test >= min && test <= max;

        /// <summary>
        /// Determines whether the source interval contains a specified test point
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="x">The point to test</param>
        /// <typeparam name="T">The interval domain</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool contains<T>(in ClosedInterval<T> src, T x)
            where T : unmanaged
                => between(uint64(x), left(src), right(src));
    }
}