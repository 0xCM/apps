//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using N = N64;
    using W = W64;

    public readonly struct N64 :
        INativeNatural,
        INatSeq<N>,
        INatPow<N,N2,N6>,
        INatPow2<N6>,
        INatDivisible<N,N32>,
        INatDivisible<N,N16>,
        INatDivisible<N,N8>,
        INatDivisible<N,N4>
    {
        public const ulong Value = 1ul << 6;

        public static NatSeq<N6,N4> Seq => default;

        public static N Rep => default;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();

        [MethodImpl(Inline)]
        public static implicit operator int(N64 src) => 64;

        [MethodImpl(Inline)]
        public static implicit operator W64(N src) => default(W);

        [MethodImpl(Inline)]
        public static implicit operator N(W src) => default(N);

    }
}