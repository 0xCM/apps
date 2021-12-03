//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N1024 :
        INativeNatural,
        INatSeq<N1024>,
        INatPow<N1024,N2,N10>,
        INatPow2<N10>,
        INatDivisible<N1024,N4>,
        INatDivisible<N1024,N8>,
        INatDivisible<N1024,N16>,
        INatDivisible<N1024,N32>,
        INatDivisible<N1024,N64>,
        INatDivisible<N1024,N128>,
        INatDivisible<N1024,N512>,
        INatDivisible<N1024,N256>
    {
        public const ulong Value = 1ul << 10;

        [MethodImpl(Inline)]
        public static implicit operator int(N1024 src) => 1024;

        [MethodImpl(Inline)]
        public static implicit operator W1024(N1024 src) => default(W1024);

        [MethodImpl(Inline)]
        public static implicit operator N1024(W1024 src) => default(N1024);

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}