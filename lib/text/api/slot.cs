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

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> slot(ReadOnlySpan<byte> widths, byte index)
            => RP.slot(index, (sbyte)(-(sbyte)skip(widths, index)));

        [Op]
        public static uint slot(ReadOnlySpan<byte> widths, char sep, Span<char> dst)
        {
            var k = 0u;
            var count = widths.Length;
            var last = count - 1;
            for(byte i=0; i<count; i++)
            {
                var s = slot(widths, i);
                var len = s.Length;

                for(var j=0; j<len; j++)
                    seek(dst,k++) = skip(s,j);

                if(i != last)
                {
                    seek(dst, k++) = Chars.Space;
                    seek(dst, k++) = sep;
                    seek(dst, k++) = Chars.Space;
                }
            }

            return k;
        }
    }
}