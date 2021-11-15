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
        public static Span<uint> span32u(in CharBlock2 src)
            => recover<uint>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<uint> span32u(in CharBlock4 src)
            => recover<uint>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<uint> span32u(in CharBlock6 src)
            => recover<uint>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<uint> span32u(in CharBlock8 src)
            => recover<uint>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<uint> span32u(in CharBlock10 src)
            => recover<uint>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<uint> span32u(in CharBlock12 src)
            => recover<uint>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<uint> span32u(in CharBlock14 src)
            => recover<uint>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<uint> span32u(in CharBlock16 src)
            => recover<uint>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<uint> span32u(in CharBlock32 src)
            => recover<uint>(bytes(src));
    }
}