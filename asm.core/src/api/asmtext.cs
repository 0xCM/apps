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
        public static AsmText asmtext(StringAddress src, AsmTextKind kind = default)
            => new AsmText(src, kind);

        [MethodImpl(Inline), Op]
        public static AsmText asmtext(string src, AsmTextKind kind = default)
            => asmtext(strings.address(src), kind);
    }
}