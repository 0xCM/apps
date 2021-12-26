//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct AsmParser
    {
        [Parser]
        public static Outcome siginfo(string src, out AsmSigInfo dst)
        {
            dst = default;

            if(text.empty(src))
                return true;

            var trimmed = src.Trim();
            var i = text.index(trimmed, Chars.Space);
            if(i == NotFound)
                dst = asm.siginfo(new AsmMnemonic(src), src);
            else
            {
                var mnemonic = new AsmMnemonic(text.slice(trimmed,0,i));
                var operands = text.slice(trimmed, i + 1);
                dst = asm.siginfo(mnemonic, trimmed);
            }
            return true;
        }

    }
}