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
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string format<T>(BitVector<T> x, BitFormat? fmt = null)
            where T : unmanaged
                => bitstring(x).Format(fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline)]
        public static string format<N,T>(in BitVector128<N,T> x, BitFormat? fmt = null)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => bitstring(x).Format(fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline)]
        public static string format<N,T>(BitVector<N,T> x, BitFormat? fmt = null)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => bitstring(x).Format(fmt);
    }
}