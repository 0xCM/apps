//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct num
    {
        [MethodImpl(Inline), Op]
        public static uint render8x8(ReadOnlySpan<num4> src, Span<char> dst, char sep = Chars.Space)
        {
            var k=0u;
            var m=z8;
            seek(dst,k++) = (char)skip(src,m++);
            seek(dst,k++) = (char)skip(src,m++);

            seek(dst,k++) = sep;
            seek(dst,k++) = (char)skip(src,m++);
            seek(dst,k++) = (char)skip(src,m++);

            seek(dst,k++) = sep;
            seek(dst,k++) = (char)skip(src,m++);
            seek(dst,k++) = (char)skip(src,m++);

            seek(dst,k++) = sep;
            seek(dst,k++) = (char)skip(src,m++);
            seek(dst,k++) = (char)skip(src,m++);

            return k;
        }
    }
}