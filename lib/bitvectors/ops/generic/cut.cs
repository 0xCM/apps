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
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff, Closures(UnsignedInts)]
        public static ScalarBits<T> cut<T>(ScalarBits<T> src, byte pos)
            where T : unmanaged
                => gbits.cut(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> cut<N,T>(ScalarBits<N,T> src, byte pos)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.cut(src.State, pos);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="s">The shift amount</param>
        [MethodImpl(Inline)]
        public static BitVector128<T> cut<T>(in BitVector128<T> x)
            where T : unmanaged
                => gcpu.vzerohi(x.State);
    }
}