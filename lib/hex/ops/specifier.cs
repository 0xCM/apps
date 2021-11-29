//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static bit specifier(AsciCode c)
            => c == AsciCode.X || c == AsciCode.x || c == AsciCode.h;

        [MethodImpl(Inline), Op]
        public static bit specifier(char c)
            => specifier((AsciCode)c);
    }
}