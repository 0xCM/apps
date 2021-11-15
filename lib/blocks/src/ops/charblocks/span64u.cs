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
        public static Span<ulong> span64u(in CharBlock4 src)
            => recover<ulong>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ulong> span64u(in CharBlock8 src)
            => recover<ulong>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ulong> span64u(in CharBlock12 src)
            => recover<ulong>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ulong> span64u(in CharBlock16 src)
            => recover<ulong>(bytes(src));

        [MethodImpl(Inline), Op]
        public static Span<ulong> span64u(in CharBlock32 src)
            => recover<ulong>(bytes(src));
    }
}