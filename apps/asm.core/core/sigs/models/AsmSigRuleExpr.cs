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
        public static Identifier identify(AsmSigRuleExpr target)
        {
            var operands = target.Operands;
            var opcount = operands.Count;
            var buffer = text.buffer();
            buffer.Append(target.Mnemonic.Format(MnemonicCase.Lowercase));
            for(var j=0; j<opcount; j++)
            {
                buffer.Append(Chars.Underscore);

                AsmSigOpExpr op = operands[j].Format().Replace(":", "x").Replace("&", "a");
                if(op.Modified(out var t, out var m))
                    buffer.AppendFormat("{0}_{1}", t, m);
                else
                    buffer.Append(op.Format());
            }
            var name = buffer.Emit().Replace("lock", "@lock");
            return name;
        }

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
                    return false;

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

        void Replace(AsmSigRuleExpr src, ReadOnlySpan<IRuleExpr> ops, byte j, List<AsmSigRuleExpr> dst)
        {
            var sources = src.Operands;
            var srcCount = (byte)sources.Count;
            var opCount = ops.Length;
            for(var i=0; i<opCount; i++)
            {
                var expr = new AsmSigRuleExpr(src.Mnemonic, srcCount);
                for(byte k=0; k<srcCount; k++)
                {
                    if(k == j)
                        expr.WithOperand(k, skip(ops,i));
                    else
                        expr.WithOperand(k, sources[k]);
                }
                Terminate(expr,dst);
            }
        }

        void Replace(AsmSigRuleExpr src, IRuleExpr op, byte j, List<AsmSigRuleExpr> dst)
        {
            var ops = src.Operands;
            var srcCount = (byte)ops.Count;
            var expr = new AsmSigRuleExpr(src.Mnemonic,srcCount);
            for(byte k=0; k<srcCount; k++)
            {
                if(k != j)
                    expr.WithOperand(k, ops[k]);
                else
                    expr.WithOperand(k, op);
            }
            Terminate(expr,dst);
        }

        void Remove(AsmSigRuleExpr src, byte j, List<AsmSigRuleExpr> dst)
        {
            var ops = src.Operands;
            var count = (byte)ops.Count;
            var expr = new AsmSigRuleExpr(src.Mnemonic, (byte)(count - 1));
            var k = z8;
            for(byte i=0; i<count; i++)
            {
                if(i != j)
                    expr.WithOperand(k++, ops[i]);
            }
            Terminate(expr,dst);
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
            var counter = 0u;
            for(byte i=0; i<count; i++)
            {
                var op = src.Operands[i];
                if(op is IChoiceRule choice)
                {
                    Replace(src, choice.Terms, i, dst);
                }
                else if(op is IOptionRule option)
                {
                    Replace(src, option.Potential, i, dst);
                    Remove(src, i, dst);
                }
                else
                {
                    rule.WithOperand(i, Rules.value(op.Format(), true));
                    counter++;
                }
            }

            if(counter == count)
                Terminate(rule, dst);
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