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
        public static BitVector<N,T> rotr<N,T>(BitVector<N,T> src, byte count)
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
        public static BitVector128<N,T> rotr<N,T>(in BitVector128<N,T> src, byte count)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gcpu.vrotrx(src.State, count);
    }
}