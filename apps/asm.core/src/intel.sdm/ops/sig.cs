//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class IntelSdm
    {
        [Op]
        public static AsmSigExpr sig(in SdmOpCodeDetail detail)
        {
            var dst = AsmSigExpr.Empty;
            var sig = detail.Sig.Format().Trim();
            var mnemonic = detail.Mnemonic.Format(MnemonicCase.Lowercase);
            var j = text.index(sig,Chars.Space);
            if(j > 0)
            {
                var operands = text.right(sig,j);
                if(text.contains(sig,Chars.Comma))
                    dst = AsmSigs.expression(mnemonic, text.trim(text.split(operands, Chars.Comma)));
                else
                    dst = AsmSigs.expression(mnemonic, operands);
            }
            else
            {
                dst = AsmSigs.expression(mnemonic);
            }
            return dst;
        }
    }
}