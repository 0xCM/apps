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
        /// Converts the vector to a bitspan representation
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitSpan32 bitspan32<T>(BitVector<T> src, int? maxbits = null)
            where T : unmanaged
                => BitSpans32.from(src.State, maxbits ?? 0);

        /// <summary>
        /// Converts the vector to a bitspan representation
        /// </summary>
        [MethodImpl(Inline)]
        public static BitSpan32 bitspan32<N,T>(BitVector<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitSpans32.from(x.State, Typed.nat32i<N>());
    }
}