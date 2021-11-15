//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XBv
    {
        /// <summary>
        /// Converts the source bitvector to an equivalent natural bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector<N4,byte> ToNatural(this BitVector4 src)
            => BitVector.inject(src.Data,n4);

        /// <summary>
        /// Converts the source bitvector to an equivalent natural bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector<N8,byte> ToNatural(this BitVector8 src)
            => BitVector.inject(src.Data,n8);

        /// <summary>
        /// Converts the source bitvector to an equivalent natural/generic bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector<N32,uint> ToNatural(this BitVector32 src)
            => BitVector.inject(src.Data,n32);

        /// <summary>
        /// Converts the source bitvector to an equivalent natural/generic bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector<N64,ulong> ToNatural(this BitVector64 src)
            => BitVector.inject(src.Data,n64);

        /// <summary>
        /// Converts a generic bitvector to natural bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="N">The natural type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector<N,T> ToNatural<N,T>(this BitVector<T> src, N n = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitVector.natural<N,T>(src.State);
    }
}