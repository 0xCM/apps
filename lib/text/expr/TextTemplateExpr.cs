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

    public class TextTemplateExpr : TextExpr
    {
        [MethodImpl(Inline), Op]
        public static TextTemplateExpr init(string body)
            => new TextTemplateExpr(body);

        public TextTemplateExpr(string body)
            : base(body, TextTemplateVar.Kind)
        {
            VarLookup = ParseFencedVars(body, TextTemplateVar.Kind, name => new TextTemplateVar(name));
        }
    }
}