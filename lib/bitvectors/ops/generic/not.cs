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
        /// Computes the bitwise complement z:= ~x of a bitvector x
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Not, Closures(Closure)]
        public static ScalarBits<T> not<T>(ScalarBits<T> x)
            where T : unmanaged
                => gmath.not(x.State);
    }
}