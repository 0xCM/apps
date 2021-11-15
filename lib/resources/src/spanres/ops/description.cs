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

    partial struct SpanRes
    {
        [MethodImpl(Inline), Op]
        public static unsafe ReadOnlySpan<byte> description(SpanResAccessor src, byte size = 29)
            => cover<byte>(Resources.jit(src.Member), size);
    }
}