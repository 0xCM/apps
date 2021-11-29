//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct StringHasher
    {
        [MethodImpl(Inline)]
        public uint Compute(string src)
            => alg.hash.marvin(bytes(src));

        [MethodImpl(Inline)]
        public static uint compute(ReadOnlySpan<char> src)
            => alg.hash.marvin(bytes(src));
    }
}