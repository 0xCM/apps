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
        /// Computes c := ~ (a | b)
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Logical_biconditional</remarks>
        [MethodImpl(Inline), Nor]
        public static bit nor(bit a, bit b)
            => new bit(!(a.State | b.State));
    }
}