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
        /// Creates a bin over a closed interval partitioned into a specified number of segments
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="count">The partition count</param>
        /// <typeparam name="T">The interval domain</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Bin<T> bin<T>(in ClosedInterval<T> src, uint count)
            where T : unmanaged, IComparable<T>
                => new Bin<T>(src, count);
    }
}