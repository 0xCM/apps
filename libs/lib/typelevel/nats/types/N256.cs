//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using N = N256;
    using W = W256;

    public readonly struct N256 :
        INativeNatural,
        INatSeq<N256,N2,N5,N6>,
        INatPow<N256,N2,N8>,
        INatPow2<N8>,
        INatDivisible<N256,N4>,
        INatDivisible<N256,N8>,
        INatDivisible<N256,N16>,
        INatDivisible<N256,N32>,
        INatDivisible<N256,N64>,
        INatDivisible<N256,N128>
    {
        public const ulong Value = 256;

        public const string Text = "256";

        public static N N => default;

        [MethodImpl(Inline)]
        public static implicit operator int(N src)
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator W(N src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator N(W src)
            => default;

        public ulong NatValue
            => Value;

        public override string ToString()
            => Value.ToString();
    }
}