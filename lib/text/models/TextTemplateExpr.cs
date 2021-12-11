//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public class TextTemplateExpr : TextExpr<TextTemplateVar.VarKind>
    {
        [MethodImpl(Inline), Op]
        public static TextTemplateExpr init(string body)
            => new TextTemplateExpr(body);

        readonly Dictionary<string,TextTemplateVar> _Vars;

        readonly Index<string> _VarNames;

        public TextTemplateExpr(string body)
            : base(body)
        {
            _Vars = new();
            _Vars = ParseFencedVars(body, TextTemplateVar.Kind, name => new TextTemplateVar(name));
            _VarNames = _Vars.Keys.Array();
        }

        public TextTemplateVar this[string var]
        {
            [MethodImpl(Inline)]
            get => _Vars[var];

            [MethodImpl(Inline)]
            set => _Vars[var] = value;
        }

        public TextTemplateVar[] Vars
        {
            [MethodImpl(Inline)]
            get => _Vars.Values.Array();
        }

        public override string Eval()
            => EvalFencedVarExpr(Body, @readonly(Vars), TextTemplateVar.Kind);
    }
}