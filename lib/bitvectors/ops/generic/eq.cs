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
        [MethodImpl(Inline)]
        public static bit eq<N,T>(in ScalarBits<N,T> x, in ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.eq(x.State, y.State);

        [MethodImpl(Inline)]
        public static bit eq<T>(in BitVector128<T> x, in BitVector128<T> y)
            where T : unmanaged
                => gcpu.vsame(x.State, y.State);
    }
}