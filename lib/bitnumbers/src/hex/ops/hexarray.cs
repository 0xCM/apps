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
        public static HexArray hexarray(byte[] src)
            => new HexArray(src);

        [MethodImpl(Inline), Op]
        public static uint hexarray(ReadOnlySpan<byte> src, Span<char> dst, bool brackets = false)
        {
            var j = 0u;
            var count = src.Length;
            var max = dst.Length;
            if(brackets)
                seek(dst,j++) = Chars.LBracket;

            for(var i=0; i<count && j<max; i++)
            {
                ref readonly var b = ref skip(src,i);
                seek(dst,j++) = Chars.D0;
                seek(dst,j++) = Chars.x;
                seek(dst,j++) = hexchar(LowerCase, b, 1);
                seek(dst,j++) = hexchar(LowerCase, b, 0);
                if(i != count-1)
                    seek(dst,j++) = Chars.Comma;
            }

            if(brackets)
                seek(dst,j++) = Chars.RBracket;
            return j;
        }

        public static Outcome hexarray(string src, out HexArray dst)
        {
            dst = HexArray.Empty;
            var l = text.index(src, Chars.LBracket);
            var r = text.index(src, Chars.RBracket);
            var i0 = 0;
            var i1 = 0;
            if(l < 0 || r < 0 || r <= l)
            {
                i0 = 0;
                i1 = src.Length - 1;
            }
            else
            {
                i0 = l + 1;
                i1 = r - 1;
            }

            var data =  text.segment(src, i0, i1);
            var cells = data.SplitClean(Chars.Comma).ToReadOnlySpan();
            var count = cells.Length;
            var buffer = alloc<byte>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref skip(cells,i);
                if(!Hex.parse8u(cell, out seek(target,i)))
                    return (false, cell);
            }
            dst = buffer;
            return true;
        }
    }
}