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

    partial struct Rules
    {
        public static IProduction production(string src, string dst)
        {
            if(text.fenced(dst, RenderFence.Bracketed))
            {
                var content = text.unfence(dst, RenderFence.Bracketed);
                var terms = map(text.trim(text.split(content,Chars.Comma)), x => RuleText.value(x));
                return new ListProduction(RuleText.value(text.trim(src)), new SeqExpr(terms));
            }
            else
            {
                return new Production(RuleText.value(text.trim(src)), RuleText.value(text.trim(dst)));
            }
        }
    }
}