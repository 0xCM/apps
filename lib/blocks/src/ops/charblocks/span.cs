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

    partial struct CharBlocks
    {
        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock2 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock3 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock4 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock5 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock6 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock7 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock8 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock9 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock10 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock11 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock12 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock13 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock14 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock15 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock16 src)
            => recover<char>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<char> span(in CharBlock32 src)
            => recover<char>(bytes(src));
    }
}