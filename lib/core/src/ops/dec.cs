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
        /// Atomically decrements a value in-place
        /// </summary>
        /// <param name="src">The value to increment in-place</param>
        [MethodImpl(Inline), Op]
        public static long dec(ref long src)
            => Interlocked.Decrement(ref src);

        /// <summary>
        /// Atomically decrements a value in-place
        /// </summary>
        /// <param name="src">The value to increment in-place</param>
        [MethodImpl(Inline), Op]
        public static long dec(ref int src)
            => Interlocked.Decrement(ref src);
    }
}