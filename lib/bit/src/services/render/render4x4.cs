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
    using static bit;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render4x4(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var size = src.Length;
            var j = 0u;
            var w = w4;
            for(var i=size-1; i >= 0; i--)
            {
                ref readonly var input = ref skip(src,i);
                render4(hi(input), ref j, dst);
                j+= separate(j, dst);
                render4(lo(input), ref j, dst);
                if(i != 0)
                    j += separate(j, dst);
            }
            return j - 1;
        }
    }
}