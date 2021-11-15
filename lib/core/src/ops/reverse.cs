//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
        [MethodImpl(Inline), Op]
        public static void reverse(ReadOnlySpan<byte> src, Span<byte> dst)
        {
            var count = src.Length;
            var j=0;
            for(var i=count-1; i>= 0; i--,j++)
                seek(dst,j) = skip(src,i);
        }
    }
}