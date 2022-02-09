//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class RuleParser
    {
        public static bool IsChoice(string src)
            => text.fenced(src,ChoiceFence);

        public static bool IsOption(string src)
            => text.fenced(src, OptionFence);

        public static bool IsProduction(string src)
            => text.split(src,YieldsSymbol).Length == 2;

        public static Outcome production(string src, out IProduction dst)
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
                result = expression(right, out IRuleExpr expr);
                if(result)
                    dst = new Production(RuleText.value(left), expr);
            }
            return result;
        }

        public static Outcome expression(string src, out IRuleExpr dst)
        {
            var result = Outcome.Success;
            dst = default;

            if(IsOption(src))
            {
                result = option(src, out var r);
                if(result)
                    dst = r;
            }
            else if(IsChoice(src))
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
            if(IsChoice(src))
            {
                var termSrc = text.trim(text.split(text.unfence(src, ChoiceFence), ChoiceSep));
                var count = termSrc.Length;
                var terms = alloc<IRuleExpr>(count);
                for(var i=0; i<count; i++)
                {
                    result = expression(skip(termSrc, i), out seek(terms,i));
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
            if(IsOption(src))
            {
                result = expression(text.unfence(src, OptionFence), out IRuleExpr expr);
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
    }
}