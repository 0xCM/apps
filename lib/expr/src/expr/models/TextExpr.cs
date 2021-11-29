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

    public class TextExpr
    {
        readonly Dictionary<string,TextVar> _Vars;

        readonly Index<string> _VarNames;

        public string Body {get;}

        public TextExpr(string body)
        {
            Body = body;
            _Vars = expr.textvars(body);
            _VarNames = _Vars.Keys.Array();
        }

        public string this[string var]
        {
            [MethodImpl(Inline)]
            get => _Vars[var].Value;

            [MethodImpl(Inline)]
            set => _Vars[var].Value = value;
        }

        public TextVar[] Vars
        {
            [MethodImpl(Inline)]
            get => _Vars.Values.Array();
        }

        public string Eval()
            => Eval(Vars);

        string Eval(ReadOnlySpan<TextVar> vars)
        {
            var result = Body;
            foreach(var v in vars)
            {
                if(nonempty(v.Value))
                    result = text.replace(result, string.Format("$({0})", v.Name), v.Value);
            }
            return result;
        }
    }
}