//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmOps
    {
        [Op]
        public static AsmSigExpr sig(in SdmOpCodeDetail src)
        {
            var dst = AsmSigExpr.Empty;
            var sig = src.Sig.Format().Trim();
            var mnemonic = src.Mnemonic;
            var j = text.index(sig, Chars.Space);
            if(j > 0)
            {
                var operands = text.right(sig, j);
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