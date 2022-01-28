//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct RuleText
    {
        public static Outcome parse(string src, out IProduction dst)
        {
            var result = Outcome.Success;
            var i = text.index(src, YieldsSymbol);
            dst = default;
            if(i == NotFound)
                result = (false, string.Format("Yield symbol '{0}' not found", YieldsSymbol));
            else
                dst = new Production(text.trim(text.left(src,i)), text.trim(text.right(src, i+ YieldsSymbol.Length)));
            return result;
        }

        public static Outcome parse(string src, out IChoiceRule dst)
        {
            if(IsChoice(src))
            {
                var terms = map(text.trim(text.split(text.unfence(src, ChoiceFence), ChoiceSep)), x => value(x));
                dst = new ChoiceRule(terms);
                return true;
            }
            else
            {
                dst = default;
                return (false,string.Format("{0} fence not found", ChoiceFence));
            }
        }

        public static Outcome parse(string src, out IOptionRule dst)
        {
            if(IsOption(src))
            {
                var content = text.unfence(src, OptionFence);
                dst = new OptionRule(content);
                return true;
            }
            else
            {
                dst = default;
                return (false,string.Format("{0} fence not found", OptionFence));
            }
        }

        static Fence<char> OptionFence => RenderFence.Bracketed;

        static Fence<char> ChoiceFence => RenderFence.Angled;

        const string YieldsSymbol = "->";

        const char ChoiceSep = Chars.Pipe;
    }
}