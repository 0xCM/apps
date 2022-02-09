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
            var opcount = sig.OpCount;
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

        void BranchOpMask(in AsmSigExpr sig, List<AsmSigRuleExpr> dst)
        {
            var opcount = sig.OpCount;
            var optext = CharBlock64.Empty;
            var operands = sig.Operands();
            sig.OperandText(ref optext);
            if(text.contains(optext, Chars.LBrace))
            {
                var sig1 = new AsmSigRuleExpr(sig.Mnemonic, opcount);
                var sig2 = new AsmSigRuleExpr(sig.Mnemonic, opcount);
                for(byte j=0; j<opcount; j++)
                {
                    ref readonly var op = ref skip(operands,j);
                    var key = op.Text;
                    if(SigOpMaskRules.Find(key, out var production) && (production.Consequent is IChoiceRule choice) && choice.Terms.Count == 2)
                    {
                        sig1.WithOperand(j,choice.Terms[0]);
                        sig2.WithOperand(j,choice.Terms[1]);
                    }
                }
            }
            else
            {
                var sig1 = new AsmSigRuleExpr(sig.Mnemonic, opcount);
                for(byte j=0; j<opcount; j++)
                    sig1.WithOperand(j, Rules.value(skip(operands,j).Text));
            }

        }
    }
}