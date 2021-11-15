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
        public static Span<byte> span8u(in CharBlock2 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock3 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock4 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock5 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock6 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock7 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock8 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock9 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock10 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock11 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock12 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock13 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock14 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock15 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock16 src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static Span<byte> span8u(in CharBlock32 src)
            => bytes(src);
    }
}