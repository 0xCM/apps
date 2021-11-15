//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    partial struct core
    {
        [Op]
        public static void addresses(ReadOnlySpan<MemorySeg> src, Span<MemoryAddress> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var segment = ref skip(src,i);
                var length = segment.Length;
                var data = segment.Load();
                if(data.Length == length)
                {
                    for(var j = 0u; j<length; j++)
                    {
                        ref readonly var cell = ref skip(data,j);
                        if(j == 0)
                        {
                            var a = address(cell);
                            if(segment.BaseAddress == a)
                                seek(dst,i) = a;
                        }
                    }
                }
            }
        }
    }
}