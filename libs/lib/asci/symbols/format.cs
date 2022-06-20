//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct AsciSymbols
    {
        [Op]
        public static string format(in AsciSeq seq)
            => format(seq.Storage.ToReadOnlySpan());

        [Op]
        public static string format(ReadOnlySpan<byte> src, Span<char> buffer)
        {
            var len = src.Length;
            for(var i=0u; i<len; i++)
                seek(buffer, i) = (char)skip(src,i);
            return text.format(slice(buffer,0,len));
        }

        [Op]
        public static string format(ReadOnlySpan<byte> src)
        {
            var len = src.Length;
            var dst = span(alloc<char>(len));
            return format(src, dst);
        }
    }
}