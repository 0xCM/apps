//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes z := x << s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline), Sll, Closures(Closure)]
        public static ScalarBits<T> sll<T>(ScalarBits<T> x, byte offset)
            where T : unmanaged
                => gmath.sll(x.State,offset);

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
        [MethodImpl(Inline), Sll, Closures(Closure)]
        public static BitVector128<T> sll<T>(in BitVector128<T> x, byte offset)
            where T : unmanaged
                => gcpu.vsllx(x.State,offset);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline), Sll, Closures(Closure)]
        public static BitVector256<T> sll<T>(in BitVector256<T> x, byte offset)
            where T : unmanaged
                => gcpu.vsllx(x.State,offset);
    }
}