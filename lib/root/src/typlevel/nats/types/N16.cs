//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N16 :
        INativeNatural,
        INatNumber<N16>,
        INatPrior<N16,N15>,
        INatSeq<N16>,
        INatPow<N16,N2,N4>,
        INatPow2<N4>,
        INatDivisible<N16,N8>,
        INatDivisible<N16,N4>
    {
        public const ulong Value = 16;

        public const string Text = "16";

        public ulong NatValue
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator int(N16 src)
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator W16(N16 src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator N16(W16 src)
            => default;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;
    }
}