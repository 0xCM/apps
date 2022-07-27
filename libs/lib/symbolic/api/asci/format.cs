//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial struct Asci
    {
        [Op]
        public static string format(ReadOnlySpan<AsciCode> src, Span<char> buffer)
        {
            var count = decode(src, buffer);
            return sys.@string(Spans.slice(buffer,0, count));
        }

        [Op]
        public static string format(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var len = src.Length;
            for(var i=0u; i<len; i++)
                seek(dst, i) = (char)skip(src,i);
            return sys.@string(slice(dst,0,len));
        }

        [Op]
        public static string format(AsciSeq seq)
            => format(seq.Codes);

        [Op]
        public static string format(ReadOnlySpan<byte> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<AsciCode> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<AsciSymbol> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }
    }
}