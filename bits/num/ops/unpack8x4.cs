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
        public static void unpack8x4(uint src, Span<num4> dst)
        {
            var data = bytes(src);
            var i=z8;
            var j=7;
            var a = num4.Zero;
            var b = num4.Zero;
            num.split(skip(data,i++), out a, out b);
            seek(dst,j--) = a;
            seek(dst,j--) = b;

            num.split(skip(data,i++), out a, out b);
            seek(dst,j--) = a;
            seek(dst,j--) = b;

            num.split(skip(data,i++), out a, out b);
            seek(dst,j--) = a;
            seek(dst,j--) = b;

            num.split(skip(data,i++), out a, out b);
            seek(dst,j--) = a;
            seek(dst,j--) = b;
        }
    }
}