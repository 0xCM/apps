//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string format<T>(ScalarBits<T> x, BitFormat? fmt = null)
            where T : unmanaged
                => bitstring(x).Format(fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline)]
        public static string format<T>(in BitVector128<T> src, BitFormat? fmt = null)
            where T : unmanaged
                => bitstring(src).Format(fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline)]
        public static string format<T>(in BitVector256<T> src, BitFormat? fmt = null)
            where T : unmanaged
                => bitstring(src).Format(fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline)]
        public static string format<T>(in BitVector<T> src, BitFormat? fmt = null)
            where T : unmanaged, IEquatable<T>
                => bitstring(src).Format(fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline)]
        public static string format<N,T>(ScalarBits<N,T> x, BitFormat? fmt = null)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => bitstring(x).Format(fmt);
    }
}