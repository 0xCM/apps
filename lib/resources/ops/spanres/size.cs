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
        public static ByteSize size(ReadOnlySpan<ByteSpanSpec> src)
        {
            var size = ByteSize.Zero;
            var count = src.Length;
            for(var i=0; i<count; i++)
                size += skip(src,i).DataSize;
            return size;
        }
    }
}