//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static string format(AsciSymbol src)
            => src.Text;

        [Op]
        public static string format(ReadOnlySpan<byte> src)
        {
            var dst = span<char>(src.Length);
            AsciSymbols.decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<AsciCode> src)
        {
            var dst = span<char>(src.Length);
            AsciSymbols.decode(src, dst);
            return new string(dst);
        }
    }
}