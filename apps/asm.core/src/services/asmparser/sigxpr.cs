//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    partial struct AsmParser
    {
        [Op]
        public static Outcome sigxpr(string src, out AsmSigInfo dst)
        {
            if(text.empty(src))
                return true;

            var trimmed = src.Trim();
            var i = text.index(trimmed, Chars.Space);
            if(i == NotFound)
                dst = asm.sigxpr(asm.mnemonic(src), src);
            else
            {
                var mnemonic = asm.mnemonic(text.slice(trimmed,0,i));
                var operands = text.slice(trimmed, i + 1);
                dst = asm.sigxpr(mnemonic, trimmed);
            }
            return true;
        }
    }
}
