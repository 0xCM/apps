//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    using static AsciSymbols;
    using static AsciChars;

    using C = AsciCode;

    partial struct Asci
    {
        [Op]
        public static string format(ReadOnlySpan<byte> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            AsciSymbols.decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<AsciCode> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            AsciSymbols.decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<AsciSymbol> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            AsciSymbols.decode(src, dst);
            return new string(dst);
        }
    }
}