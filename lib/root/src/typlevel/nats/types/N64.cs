//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N64 :
        INativeNatural,
        INatSeq<N64>,
        INatPow<N64,N2,N6>,
        INatPow2<N6>,
        INatDivisible<N64,N32>,
        INatDivisible<N64,N16>,
        INatDivisible<N64,N8>,
        INatDivisible<N64,N4>
    {
        public const ulong Value = 1ul << 6;

        public static NatSeq<N6,N4> Seq => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N64 src) => 64;

        [MethodImpl(Inline)]
        public static implicit operator W64(N64 src) => default(W64);

        [MethodImpl(Inline)]
        public static implicit operator N64(W64 src) => default(N64);

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}