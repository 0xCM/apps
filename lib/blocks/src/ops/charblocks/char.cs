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
        public static ref char @char(in CharBlock2 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock3 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock4 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock5 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock6 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock7 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock8 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock9 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock10 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock11 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock12 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock13 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock14 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock15 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock16 src)
            => ref c16(src);

        [MethodImpl(Inline), Op]
        public static ref char @char(in CharBlock32 src)
            => ref c16(src);
    }
}