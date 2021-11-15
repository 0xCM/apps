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

    partial struct bit
    {
        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<char> src, Span<bit> dst)
        {
            var count = (uint)min(src.Length,dst.Length);
            var lastix = count - 1;
            for(var i=0; i<= lastix; i++)
               seek(dst, lastix - i) = skip(src,i) == bit.Zero ? bit.Off : bit.On;
            return count;
        }
    }
}