//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render32x8(char sep, uint src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var cells = bytes(src);
            render8(skip(cells,3), ref i, dst);
            seek(dst,i++) = sep;

            render8(skip(cells,2), ref i, dst);
            seek(dst,i++) = sep;

            render8(skip(cells,1), ref i, dst);
            seek(dst,i++) = sep;

            render8(skip(cells,0), ref i, dst);

            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render32x8(uint src, ref uint i, Span<char> dst)
            => render32x8(Chars.Space, src, ref i, dst);

        [MethodImpl(Inline), Op]
        public static uint render32x8(char sep, uint src, Span<char> dst)
        {
            var i = 0u;
            return render32x8(sep, src, ref i, dst);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render32x8(char sep, uint src)
        {
            var buffer = CharBlock64.Null.Data;
            var i=0u;
            var count = render32x8(sep, src, ref i, buffer);
            return slice(buffer,0,count);
        }
    }
}