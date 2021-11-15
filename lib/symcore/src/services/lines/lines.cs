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

    partial struct Lines
    {
        [MethodImpl(Inline), Op]
        public static uint lines(ReadOnlySpan<string> src, Span<TextLine> dst)
        {
            var count = (uint)src.Length;
            var counter = 1u;
            for(var i=0; i<count; i++)
                seek(dst,i) = new TextLine(counter++, skip(src,i));
            return count;
        }
    }
}