//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public AsmSigRuleExpr SymbolizeExpression(in AsmSigExpr sig)
        {
            var opcount = sig.OperandCount;
            var operands = sig.Operands();
            var expr = new AsmSigRuleExpr(sig.Mnemonic, opcount);
            for(byte i=0; i<opcount; i++)
            {
                ref readonly var op = ref skip(operands,i);
                var key = op.Text;
                if(SigDecompRules.Find(key, out var production))
                    expr.WithOperand(i, production.Consequent);
                else
                    expr.WithOperand(i, Rules.value(op.Text));
            }

            Require.invariant(expr.IsValid, () => expr.Mnemonic.Format());
            return expr;
        }
    }
}