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
        /// Rotates source bits leftward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Rotl, Closures(Closure)]
        public static BitVector<T> rotl<T>(BitVector<T> src, byte count)
            where T : unmanaged
                => gbits.rotl(src.State,count);

        /// <summary>
        /// Rotates source bits leftward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector<N,T> rotl<N,T>(BitVector<N,T> src, byte count)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.rotl(src.State, count, src.Width);

        /// <summary>
        /// Rotates source bits leftward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector128<N,T> rotl<N,T>(in BitVector128<N,T> src, byte count)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gcpu.vrotlx(src.State, count);
    }
}