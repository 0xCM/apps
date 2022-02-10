//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public void SymbolizeExpression(in AsmSigExpr sig, List<AsmSigRuleExpr> dst)
        {
            var opcount = sig.OpCount;
            var operands = sig.Operands();
            var optext = CharBlock64.Empty;
            sig.OperandText(ref optext);
            if(text.contains(optext, Chars.LBrace))
            {
                var sig1 = new AsmSigRuleExpr(sig.Mnemonic, opcount);
                var sig2 = new AsmSigRuleExpr(sig.Mnemonic, opcount);
                for(byte j=0; j<opcount; j++)
                {
                    ref readonly var op = ref skip(operands,j);
                    var key = text.trim(op.Text);
                    var k = text.index(key, Chars.LBrace);
                    if(k >= 0)
                    {
                        if(SigDecompRules.Find(key, out var production)  && (production.Consequent is IChoiceRule choice) && choice.Terms.Count == 2)
                        {
                            sig1.WithOperand(j,choice.Terms[0]);
                            sig2.WithOperand(j,choice.Terms[1]);
                        }
                        else
                        {
                            sig1.WithOperand(j, Rules.value(key));
                            sig2.WithOperand(j, Rules.value(key));
                            //Errors.Throw(key);
                        }
                    }
                    else
                    {
                        if(SigDecompRules.Find(key, out var production))
                        {
                            sig1.WithOperand(j, production.Consequent);
                            sig2.WithOperand(j, production.Consequent);
                        }
                        else
                        {
                            sig1.WithOperand(j, Rules.value(key));
                            sig2.WithOperand(j, Rules.value(key));

                        }
                    }
                }

                dst.Add(sig1);
                dst.Add(sig2);

            }
            else
            {
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

                dst.Add(expr);

                Require.invariant(expr.IsValid, () => expr.Mnemonic.Format());
            }
        }

        void BranchOpMask(in AsmSigExpr sig, List<AsmSigRuleExpr> dst)
        {
            var opcount = sig.OpCount;
            var operands = sig.Operands();
            var optext = CharBlock64.Empty;
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
                dst.Add(sig1);
                dst.Add(sig2);
            }
            else
            {
                var sig1 = new AsmSigRuleExpr(sig.Mnemonic, opcount);
                for(byte j=0; j<opcount; j++)
                    sig1.WithOperand(j, Rules.value(skip(operands,j).Text));
                dst.Add(sig1);
            }

        }
    }
}