//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    using static AsciSymbols;
    using static AsciChars;

    using C = AsciCode;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static uint render(AsciSeq src, uint length, Span<char> dst)
        {
            var size = min(src.Capacity,length);
            var data = slice(src.Data.View,0,size);
            for(var i=0u; i<size; i++)
                seek(dst, i) = src[i];
            return size;
        }
    }
}