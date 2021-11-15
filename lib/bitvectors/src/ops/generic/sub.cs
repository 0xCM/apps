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
        /// Computes the arithmetic difference z := x - y for generic bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Sub, Closures(Closure)]
        public static BitVector<T> sub<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => gmath.sub(x.State, y.State);

        /// <summary>
        /// Computes the Hamming distance between two generic bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint hamming<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
            => pop(xor(x,y));

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Replicate, Closures(Closure)]
        public static BitVector<T> replicate<T>(BitVector<T> x)
            where T : unmanaged
                => x.State;
    }
}