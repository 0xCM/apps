//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2029
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N62 : INativeNatural, INatSeq<N62,N6,N2>
    {
        public const ulong Value = 62;

        [MethodImpl(Inline)]
        public static implicit operator int(N62 src) => 62;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}