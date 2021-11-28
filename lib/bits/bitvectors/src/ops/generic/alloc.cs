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
        /// Allocates a natural bitvector
        /// </summary>
        /// <param name="n">The number of bits to store</param>
        /// <typeparam name="T">The primal storage type</typeparam>
        [MethodImpl(Inline), Alloc]
        public static BitVector<N,T> alloc<N,T>(N n = default, T fill = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => new BitVector<N,T>(fill);

        /// <summary>
        /// Allocates a generic bitvector
        /// </summary>
        /// <param name="n">The number of bits to store</param>
        /// <typeparam name="T">The primal storage type</typeparam>
        [MethodImpl(Inline), Alloc, Closures(Closure)]
        public static BitVector<T> alloc<T>(T fill = default)
            where T : unmanaged
                => load(fill);
    }
}