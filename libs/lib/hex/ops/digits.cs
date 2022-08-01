//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
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