//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct bit
    {
        /// <summary>
        /// Computes c = a ^ b
        /// </summary>
        /// <param name="a">The left bit</param>
        /// <param name="b">The right bit</param>
        [MethodImpl(Inline), Xor]
        public static bit xor(bit a, bit b)
            => new bit(a.State ^ b.State);
    }
}