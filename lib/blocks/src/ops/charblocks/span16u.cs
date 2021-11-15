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

    readonly partial struct CharBlocks
    {
        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock2 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock3 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock4 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock5 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock6 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock7 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock8 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock9 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock10 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock11 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock12 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock13 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock14 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock15 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock16 src)
            => recover<ushort>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ushort> span16u(in CharBlock32 src)
            => recover<ushort>(bytes(src));
    }
}