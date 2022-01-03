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

    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static Span<bit> extract(in BitSpan src, uint offset, uint count)
            => core.slice(src.Storage, offset, count);
    }
}