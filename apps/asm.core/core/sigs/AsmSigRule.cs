//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmSigRule : RuleExpr
    {
        public AsmMnemonic Mnemonic {get;}

        public Index<IRuleExpr> Operands {get;}

        public AsmSigRule(AsmMnemonic mnemonic, byte opcount)
        {
            Mnemonic = mnemonic;
            Operands = alloc<IRuleExpr>(opcount);
        }

        public override string Format()
        {
            var dst = text.buffer();
            dst.Append(Mnemonic.Format(MnemonicCase.Lowercase));
            var count = Operands.Count;
            for(var i=0; i<count; i++)
            {
                if(i == 0)
                    dst.Append(Chars.Space);
                else
                    dst.Append(", ");

                dst.Append(Operands[i].ToString());
            }
            return dst.Emit();
        }
    }
}