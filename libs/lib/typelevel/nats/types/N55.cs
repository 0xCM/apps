//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 5555
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N55 : INativeNatural, INatSeq<N55,N5,N5>
    {
        public const ulong Value = 55;

        public static N55 Rep => default;


        [MethodImpl(Inline)]
        public static implicit operator int(N55 src) => 55;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}