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
        [MethodImpl(Inline), Op]
        public static AsmSigInfo sigxpr(AsmMnemonic mnemonic, string content)
            => new AsmSigInfo(mnemonic, content);

        [Op]
        public static Outcome sigxpr(string src, out AsmSigInfo dst)
        {
            dst = default;

            if(text.empty(src))
                return true;

            var trimmed = src.Trim();
            var i = text.index(trimmed, Chars.Space);
            if(i == NotFound)
                dst = sigxpr(new AsmMnemonic(src), src);
            else
            {
                var mnemonic = new AsmMnemonic(text.slice(trimmed,0,i));
                var operands = text.slice(trimmed, i + 1);
                dst = sigxpr(mnemonic, trimmed);
            }
            return true;
        }
    }
}
