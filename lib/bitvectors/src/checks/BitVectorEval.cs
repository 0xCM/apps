//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct BitVectorEval
    {
        [MethodImpl(Inline), Op]
        public bool eq(BitVector4 x, BitVector4 y)
            => math.eq(x.State, y.State);

        [MethodImpl(Inline), Op]
        public bool eq(BitVector8 x, BitVector8 y)
            => math.eq(x.State, y.State);

        [MethodImpl(Inline), Op]
        public bool eq(BitVector16 x, BitVector16 y)
            => math.eq(x.State, y.State);

        [MethodImpl(Inline), Op]
        public bool eq(BitVector32 x, BitVector32 y)
            => math.eq(x.State, y.State);

        [MethodImpl(Inline), Op]
        public bool eq(BitVector64 x, BitVector64 y)
            => math.eq(x.State, y.State);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public bool eq<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => gmath.eq(x.State, y.State);

        [MethodImpl(Inline)]
        public bool eq<N,T>(BitVector128<N,T> x, BitVector128<N,T> y)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => x.Equals(y);

        [MethodImpl(Inline)]
        public bool eq<N,T>(BitVector<N,T> x, BitVector<N,T> y)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => x.Equals(y);
    }
}