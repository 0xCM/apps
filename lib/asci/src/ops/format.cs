//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using F = AsciFormatter;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static string format(in asci2 src)
            => F.format(src);

        [MethodImpl(Inline), Op]
        public static string format(in asci4 src)
            => F.format(src);

        [MethodImpl(Inline), Op]
        public static string format(in asci8 src)
            => F.format(src);

        [MethodImpl(Inline), Op]
        public static string format(in asci16 src)
            => F.format(src);

        [MethodImpl(Inline), Op]
        public static string format(in asci32 src)
            => F.format(src);

        [MethodImpl(Inline), Op]
        public static string format(in asci64 src)
            => F.format(src);

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
    }
}