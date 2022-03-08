//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static bit;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render4x4(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var size = src.Length;
            var j=size-1;
            var k=0u;
            for(var i=0; i<size; i++)
            {
                ref readonly var b = ref skip(src,j--);
                if(i != 0)
                    k+= separate(k,dst);
                render4(hi(b), ref k, dst);
                k+= separate(k,dst);
                render4(lo(b), ref k, dst);
            }
            return k;
        }
        // {
        //     var size = src.Length;
        //     var j = 0u;
        //     for(var i=size-1; i >= 0; i--)
        //     {
        //         ref readonly var input = ref skip(src,i);
        //         render4(hi(input), ref j, dst);
        //         j+= separate(j, dst);
        //         render4(lo(input), ref j, dst);
        //         if(i != 0)
        //             j += separate(j, dst);
        //     }
        //     return j - 1;
        // }
    }
}