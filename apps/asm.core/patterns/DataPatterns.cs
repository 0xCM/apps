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

    public readonly struct DataPatterns
    {
        [MethodImpl(Inline), Op]
        public static BitPattern bit(bit state, MatchKind kind = MatchKind.Enabled)
            => new BitPattern(kind,state);

        [MethodImpl(Inline), Op]
        public static BytePattern bits(params BitPattern[] src)
        {
            var dst = BytePattern.Empty;
            var count = (byte)min(src.Length, 8);
            for(byte i=0; i<count; i++)
                dst[i] = skip(src,i);
            return dst;
        }
    }
}