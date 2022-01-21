//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigs
    {
        [Parser]
        public static Outcome parse(string src, out AsmSigExpr dst)
        {
            var result = Outcome.Success;
            var sig = text.trim(src);
            var j = text.index(text.trim(sig), Chars.Space);
            var mnemonic = AsmMnemonic.Empty;
            dst = AsmSigExpr.Empty;
            if(j>0)
            {
                mnemonic = text.left(sig,j);
                var operands = text.right(sig,j);
                if(text.contains(sig, Chars.Comma))
                    dst = expression(mnemonic, text.trim(text.split(operands, Chars.Comma)));
                else
                    dst = expression(mnemonic, operands);
            }
            else
            {
                mnemonic = sig;
                dst = expression(mnemonic);
            }

            return result;
        }
    }
}