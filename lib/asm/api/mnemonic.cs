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
        public static AsmMnemonic mnemonic(string src)
            => new AsmMnemonic(src);

        [Op]
        public static AsmMnemonic mnemonic(ReadOnlySpan<char> src)
            => new AsmMnemonic(text.format(src));
    }
}