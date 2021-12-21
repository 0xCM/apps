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

    partial class BitVectors
    {
        /// <summary>
        /// Initializes a generic bitvector with a supplied value
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> init<T>(T src)
            where T : unmanaged
                => new ScalarBits<T>(src);

        /// <summary>
        /// Initializes a natural bitvector over a primal type
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<W,T> init<W,T>(T src, W w = default)
            where T : unmanaged
            where W : unmanaged, ITypeNat
                => new ScalarBits<W,T>(src);

        /// <summary>
        /// Initializes a 128-bit bitvector
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        static BitVector128<T> init<T>(Vector128<T> src)
            where T : unmanaged
                => new BitVector128<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector128<T> init<T>(W128 w, T bcast = default)
            where T : unmanaged
                => init(gcpu.vbroadcast(w,bcast));
    }
}