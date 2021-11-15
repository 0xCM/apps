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

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static uint charpack(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var j = 0u;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
            {
                ref readonly var b = ref skip(src,i);
                seek(dst,j++) = hexchar(LowerCase, b, 1);
                seek(dst,j++) = hexchar(LowerCase, b, 0);
            }
            return j;
        }
    }
}