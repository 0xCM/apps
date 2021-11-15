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
        [MethodImpl(Inline), Op]
        public static uint render32x8(uint src, ref uint i, Span<char> dst, char sep = Chars.Space)
        {
            var i0 = i;
            var cells = bytes(src);
            render8(skip(cells,3), ref i, dst);
            i += separate(sep, dst);
            render8(skip(cells,2), ref i, dst);
            i+= separate(sep, dst);
            render8(skip(cells,1), ref i, dst);
            i+= separate(sep, dst);
            render8(skip(cells,0), ref i, dst);

            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render32x8(uint src, Span<char> dst, char sep = Chars.Space)
        {
            var i = 0u;
            return render32x8(src, ref i, dst, sep);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render32x8(uint src, char sep = Chars.Space)
        {
            var buffer = CharBlock64.Null.Data;
            var i=0u;
            var count = render32x8(src, ref i, buffer, sep);
            return slice(buffer,0,count);
        }
    }
}