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
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> rotr<N,T>(ScalarBits<N,T> src, byte count)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.rotr(src.State, count, (byte)src.Width);

        /// <summary>
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector128<T> rotr<T>(in BitVector128<T> src, byte count)
            where T : unmanaged
                => gcpu.vrotrx(src.State, count);

    }
}