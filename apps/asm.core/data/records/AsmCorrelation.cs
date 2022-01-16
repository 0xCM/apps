//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Asm;

    using static Root;

    public readonly struct AsmCorrelation
    {
        [MethodImpl(Inline)]
        public static CorrelationToken token(uint docid, Address32 ip)
            => math.or(math.sll(docid, 24),  (uint)ip);
    }
}