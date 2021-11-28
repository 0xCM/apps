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
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline)]
        public static BitVector<N,T> gather<N,T>(BitVector<N,T> src, BitVector<N,T> spec)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.gather(src.State, spec.State);
    }
}