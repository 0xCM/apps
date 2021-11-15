//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    using static Root;

    partial struct core
    {
        /// <summary>
        /// Atomically increments a value in-place
        /// </summary>
        /// <param name="src">The value to increment in-place</param>
        [MethodImpl(Inline), Op]
        public static long inc(ref long src)
            => Interlocked.Increment(ref src);

        /// <summary>
        /// Atomically increments a value in-place
        /// </summary>
        /// <param name="src">The value to increment in-place</param>
        [MethodImpl(Inline), Op]
        public static int inc(ref int src)
            => Interlocked.Increment(ref src);
    }
}