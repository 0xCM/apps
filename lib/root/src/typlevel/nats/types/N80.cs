//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct N80 : INativeNatural, INatSeq<N80,N8,N0>
    {
        public const ulong Value = 80;

        [MethodImpl(Inline)]
        public static implicit operator int(N80 src)
            => (int)Value;

        public ulong NatValue => Value;

        public override string ToString()
            => Value.ToString();
    }
}