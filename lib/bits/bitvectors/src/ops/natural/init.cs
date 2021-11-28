//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial class BitVector
    {
        /// <summary>
        /// Initializes a natural bitvector over a primal type
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector<W,T> init<W,T>(T src, W w = default)
            where T : unmanaged
            where W : unmanaged, ITypeNat
                => new BitVector<W,T>(src);

        /// <summary>
        /// Initializes a full-width 128-bit bitvector
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector128<N128,T> init<T>(Vector128<T> src)
            where T : unmanaged
                => new BitVector128<N128,T>(src);

        /// <summary>
        /// Initializes a 128-bit bitvector with effective width determined by the parametric natural type that must not exeed 128
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector128<N,T> init<N,T>(Vector128<T> src, N w = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => new BitVector128<N,T>(src);
    }
}