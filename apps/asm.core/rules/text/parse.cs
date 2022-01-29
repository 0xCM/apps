//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct RuleText
    {
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
                    dst = new Production(value(left), expr);
            }
            return result;
        }

        public static Outcome parse(string src, out IRuleExpr dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(IsChoice(src))
            {
                result = parse(src, out IChoiceRule choice);
                if(result)
                    dst = choice;
            }
            else if(IsOption(src))
            {
                result = parse(src, out IOptionRule option);
                if(result)
                    dst = option;
            }
            else
            {
                dst = value(src);
            }
            return result;
        }

        static Outcome parse(string src, out IChoiceRule dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(IsChoice(src))
            {
                var termSrc = text.trim(text.split(text.unfence(src, ChoiceFence), ChoiceSep));
                var count = termSrc.Length;
                var terms = map(termSrc,value);
                dst = new ChoiceRule(terms);
            }
            else
            {
                result = (false,string.Format("{0} fence not found", ChoiceFence));
            }
            return result;
        }

        static Outcome parse(string src, out IOptionRule dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(IsOption(src))
            {
                var content = text.unfence(src, OptionFence);
                if(text.contains(content, ChoiceSep))
                {
                    var inner = text.trim(text.split(content, ChoiceSep));
                    var count = inner.Length;
                    var terms = alloc<IRuleExpr>(count);
                    for(var i=0; i<count; i++)
                    {
                        result = parse(skip(inner,i),  out seek(terms,i));
                        if(result.Fail)
                            break;
                    }

                }
                else
                    dst = new OptionRule(RuleText.value(content));
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