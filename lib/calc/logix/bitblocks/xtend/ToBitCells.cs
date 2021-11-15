//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XBitBlocks
    {
        /// <summary>
        /// Loads a <see cref='BitBlock{T}'/> from a <see cref='Span{T}'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="len">The bitvector length, if specified</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitBlock<T> ToBitBLock<T>(this Span<T> src, int len)
            where T : unmanaged
                => BitBlocks.load(src,len);

        [MethodImpl(Inline)]
        public static BitBlock<N,T> ToBitBlock<N,T>(this BitVector128<N,T> src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitBlocks.load(src.State.ToSpan(),n);
    }
}