//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Negate, Closures(Closure)]
        public static ScalarBits<T> negate<T>(ScalarBits<T> x)
            where T : unmanaged
                => gmath.negate(x.State);

        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> negate<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.negate(x.State);

        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector128<T> negate<T>(in BitVector128<T> x)
            where T : unmanaged
                => gcpu.vnegate(x.State);

        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector256<T> negate<T>(in BitVector256<T> x)
            where T : unmanaged
                => gcpu.vnegate(x.State);
    }
}