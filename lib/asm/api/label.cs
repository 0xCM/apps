//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmOffsetLabel label(byte width, ulong value)
            => AsmDocBuilder.label(width,value);

        [MethodImpl(Inline), Op]
        public static AsmLabel label(Identifier name)
            => AsmDocBuilder.label(name);
    }
}