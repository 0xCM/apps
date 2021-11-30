//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVector
    {
        /// <summary>
        /// Computes the bitwise ternary select for bitvector operands
        /// </summary>
        /// <param name="x">The pivot/mask vector</param>
        /// <param name="y">The primary choice</param>
        /// <param name="z">The alternative choice</param>
        [MethodImpl(Inline), Select, Closures(Closure)]
        public static ScalarBits<T> select<T>(ScalarBits<T> x, ScalarBits<T> y, ScalarBits<T> z)
            where T : unmanaged
                => gbits.select(x.State, y.State, z.State);
    }
}