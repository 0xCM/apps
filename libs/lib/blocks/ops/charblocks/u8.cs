//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CharBlocks
    {
        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock2 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock3 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock4 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock5 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock6 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock7 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock8 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock9 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock10 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock11 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock12 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock13 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock14 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock15 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock16 src)
            => ref core.u8(src);

        [MethodImpl(Inline), Op]
        public static ref byte u8(in CharBlock32 src)
             => ref core.u8(src);
   }
}