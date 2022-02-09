//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmSigRuleExpr<T> : AsmSigRuleExpr
        where T : IRuleExpr
    {
        public AsmSigRuleExpr(AsmMnemonic mnemonic, byte opcount)
            : base(mnemonic, opcount)
        {

        }

        public AsmSigRuleExpr<T> WithOperand(byte index, T operand)
        {
            Operands[index] = operand;
            return this;
        }
    }
}