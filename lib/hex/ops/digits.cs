//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Hex
    {

        [MethodImpl(Inline), Op]
        public static void digits(ReadOnlySpan<HexLowerSym> src, Span<HexDigitValue> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = Hex.digit(skip(src,i));
        }

        [MethodImpl(Inline), Op]
        public static void digits(ReadOnlySpan<HexUpperSym> src, Span<HexDigitValue> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = Hex.digit(skip(src,i));
        }

        [Op]
        public static Outcome<uint> digits(ReadOnlySpan<char> src, Span<HexDigitValue> dst)
        {
            var j=0u;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<src.Length; i++)
            {
                if(!parse(skip(src,i), out seek(dst,i)))
                    return false;
            }
            return j;
        }

    }
}