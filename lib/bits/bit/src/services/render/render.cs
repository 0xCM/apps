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

    partial struct BitRender
    {
        [Op]
        public static uint render(byte src, ref uint i, uint n, Span<char> dst)
        {
            var i0 = i;
            switch(n)
            {
                case 1:
                    render1(src, ref i, dst);
                break;
                case 2:
                    render2(src, ref i, dst);
                break;
                case 3:
                    render3(src, ref i, dst);
                break;
                case 4:
                    render4(src, ref i, dst);
                break;
                case 5:
                    render5(src, ref i, dst);
                break;
                case 6:
                    render6(src, ref i, dst);
                break;
                case 7:
                    render7(src, ref i, dst);
                break;
                case 8:
                    render8(src, ref i, dst);
                break;
            }
            return i - i0;
        }

        public static uint render(ReadOnlySpan<byte> src, uint maxbits, Span<char> dst)
        {
            var n = (uint)min(src.Length*8, maxbits);
            var q = n/8u;
            var r = n%8;
            var m = maxbits % 8;
            var count = q + (r != 0 ? 1 : 0);
            var k=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                var last = i == count -1;
                if(last && r != 0)
                    render(input, ref k, m, dst);
                else
                    render8(input, ref k, dst);
            }
            return k;
        }

        [Op]
        public static Span<char> render(ReadOnlySpan<byte> src, uint maxbits = uint.MaxValue)
        {
            var dst = span<char>(src.Length*8);
            var count = render(src,maxbits,dst);
            return slice(dst,0,count);
        }
    }
}