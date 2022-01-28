//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public class AsmSigRuleExpr : RuleExpr
    {
        public AsmMnemonic Mnemonic {get;}

        public Index<IRuleExpr> Operands {get;}

        public AsmSigRuleExpr(AsmMnemonic mnemonic, byte opcount)
        {
            Mnemonic = mnemonic;
            Operands = alloc<IRuleExpr>(opcount);
        }

        public AsmSigRuleExpr WithOperand(byte index, IRuleExpr operand)
        {
            Operands[index] = operand;
            return this;
        }

        public bool IsValid
        {
            get
            {
                var count = Operands.Count;
                for(var i=0; i<count; i++)
                {
                    if(Operands[i] == null)
                        return false;
                }
                return true;
            }
        }

        public override bool IsTerminal
        {
            get
            {
                if(!IsValid)
                {
                    Errors.Throw(string.Format("Invalid rule for {0}", Mnemonic));
                }

                var result = true;
                var count = Operands.Count;
                for(byte i=0; i<count; i++)
                    result &= Operands[i].IsTerminal;
                return result;
            }
        }

        public Index<AsmSigRuleExpr> Terminate()
        {
            var dst = list<AsmSigRuleExpr>();
            Terminate(this, dst);
            return dst.Array();
        }

        void Terminate(AsmSigRuleExpr src, List<AsmSigRuleExpr> dst)
        {
            if(src.IsTerminal)
            {
                dst.Add(src);
                return;
            }

            var count = (byte)src.Operands.Count;
            var rule = new AsmSigRuleExpr(Mnemonic,count);
            for(byte i=0; i<count; i++)
            {
                var op = src.Operands[i];
                if(op is IChoiceRule choice)
                {
                    var terms = choice.Terms;
                    foreach(var t in terms)
                    {
                        var selected= new AsmSigRuleExpr(Mnemonic, count);
                        for(byte j=0; j<count; j++)
                        {
                            if(j != i)
                                selected.Operands[j] = t;
                            else
                                selected.Operands[j] = op;
                        }

                        if(selected.IsTerminal)
                            dst.Add(selected);
                        else
                            Terminate(selected, dst);
                    }
                }
                else if(op is IOptionRule option)
                {
                    var with = new AsmSigRuleExpr(Mnemonic, count);
                    for(byte j=0; j<count; j++)
                    {
                        if(j != i)
                            with.Operands[j] = src.Operands[j];
                        else
                            with.Operands[j] = option.Potential;
                    }
                    if(with.IsTerminal)
                        dst.Add(with);
                    else
                        Terminate(with,dst);

                    var without = new AsmSigRuleExpr(Mnemonic,(byte)(count-1));
                    for(byte j = 0; j<count-1; j++)
                    {
                        if(j == i)
                            continue;

                        without.Operands[j] = op;
                    }
                    if(without.IsTerminal)
                        dst.Add(without);
                    else
                        Terminate(without,dst);
                }
                else
                {
                    rule.Operands[i] = Rules.value(op,true);
                }

                if(rule.IsTerminal)
                    dst.Add(rule);
                else
                    Terminate(rule,dst);
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Mnemonic.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Mnemonic.IsNonEmpty;
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

        public static AsmSigRuleExpr Empty => new AsmSigRuleExpr(AsmMnemonic.Empty, 0);
    }
}