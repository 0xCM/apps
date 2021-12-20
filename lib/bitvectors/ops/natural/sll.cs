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
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> sll<N,T>(ScalarBits<N,T> x, byte offset)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.sll(x.State,offset);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline)]
        public static BitVector128<T> sll<T>(in BitVector128<T> x, byte offset)
            where T : unmanaged
                => gcpu.vsllx(x.State,offset);
    }
}