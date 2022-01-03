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

    partial struct rules
    {
        public static IProduction production(string src, string dst)
        {
            if(text.fenced(dst, RenderFence.Bracketed))
            {
                var content = text.unfence(dst, RenderFence.Bracketed);
                var terms = map(text.trim(text.split(content,Chars.Comma)),x => (IExpr)expr.value(x));
                return new SeqProduction(text.trim(src), new SeqExpr(terms));
            }
            else
            {
                return new ValueProduction(text.trim(src), text.trim(dst));
            }
        }
    }
}