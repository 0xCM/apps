//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static core;
    using static Root;

    using Asm;

    public class Productions2
    {
        public AsmSigRuleExpr Symbolize(in AsmSigExpr sig)
        {
            var opcount = sig.OperandCount;
            var dst = dict<byte,IRuleExpr>();
            var operands = sig.Operands();
            for(byte i=0; i<opcount; i++)
            {
                ref readonly var op = ref skip(operands,i);
                if(Find(op.Text, out var choices))
                {
                    dst[i] = Rules.choices(choices);
                }
                else
                {
                    dst[i] = RuleText.value(op.Text);
                }
            }
            var expr = new AsmSigRuleExpr(sig.Mnemonic, opcount);
            for(byte i=0; i<opcount; i++)
            {
                expr.WithOperand(i,dst[i]);
            }

            return expr;
        }

        public static Productions2 load(FS.FilePath src)
        {
            var dst = dict<string,IProduction>();
            using var reader = src.Utf8LineReader();
            var result = Outcome.Success;
            while(reader.Next(out var line))
            {
                if(line.Trim().IsEmpty)
                    continue;

                result = parse(line.Content, out IProduction prod);
                if(result)
                    dst.TryAdd(prod.Source.Format(), prod);
                else
                    break;
            }
            if(result.Fail)
            {
                Errors.Throw(result.Message);
            }

            return dst;
        }

        public static Outcome parse(string src, out IProduction dst)
        {
            var result = Outcome.Success;
            var i = text.index(src, YieldsSymbol);
            dst = default;
            if(i == NotFound)
                result = (false, string.Format("Yield symbol '{0}' not found in '{1}'", YieldsSymbol, src));
            else
            {
                var left = text.trim(text.left(src,i));
                var right = text.trim(text.right(src, i+ YieldsSymbol.Length));
                result = parse(right, out IRuleExpr expr);
                if(result)
                    dst = new Production(RuleText.value(left), expr);
            }
            return result;
        }

        public static Outcome parse(string src, out IRuleExpr dst)
        {
            var result = Outcome.Success;
            dst = default;

            if(RuleText.IsOption(src))
            {
                result = option(src, out var r);
                if(result)
                    dst = r;
            }
            else if(RuleText.IsChoice(src))
            {
                result = choice(src, out var r);
                if(result)
                    dst = r;
            }
            else
            {
                dst = RuleText.value(src);
            }
            return result;
        }

        static Outcome choice(string src, out IChoiceRule dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(RuleText.IsChoice(src))
            {
                var termSrc = text.trim(text.split(text.unfence(src, ChoiceFence), ChoiceSep));
                var count = termSrc.Length;
                var terms = alloc<IRuleExpr>(count);
                for(var i=0; i<count; i++)
                {
                    result = parse(skip(termSrc, i), out seek(terms,i));
                    if(result.Fail)
                         break;
                }

                if(result)
                    dst = new ChoiceRule<IRuleExpr>(terms);
            }
            else
            {
                result = (false,string.Format("{0} fence not found", ChoiceFence));
            }
            return result;
        }

        static Outcome option(string src, out IOptionRule dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(RuleText.IsOption(src))
            {
                result = parse(text.unfence(src, OptionFence), out IRuleExpr expr);
                if(result)
                    dst = new OptionRule<IRuleExpr>(expr);
            }
            else
            {
                result = (false, string.Format("{0} fence not found", OptionFence));
            }
            return result;
        }

        static Fence<char> OptionFence => RenderFence.Bracketed;

        static Fence<char> ChoiceFence => RenderFence.Angled;

        const string YieldsSymbol = "->";

        const char ChoiceSep = Chars.Pipe;

        ConstLookup<string, IProduction> Data;

        public Productions2(Dictionary<string,IProduction> src)
        {
            Data = src;
        }

        public static implicit operator Productions2(Dictionary<string,IProduction> src)
            => new Productions2(src);

        public bool Find(string src, out IProduction dst)
            => Data.Find(src, out dst);

        public IProduction this[string src]
            => Data[src];

        public ReadOnlySpan<string> Keys
            => Data.Keys;

        public ReadOnlySpan<IProduction> Values
            => Data.Values;
    }
}