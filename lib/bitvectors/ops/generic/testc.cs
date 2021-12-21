//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVectors
    {
        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit testc<T>(ScalarBits<T> src)
            where T : unmanaged
                => gmath.eq(gmath.and(Limits.maxval<T>(), src.State), Limits.maxval<T>());

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline),TestC]
        public static bit testc<N,T>(ScalarBits<N,T> src, N n = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.eq(gmath.and(Limits.maxval<T>(), src.State), Limits.maxval<T>());

        [MethodImpl(Inline),TestC]
        public static bit testc<T>(BitVector128<T> src)
            where T : unmanaged
                => gcpu.vtestc(src.State);
    }
}