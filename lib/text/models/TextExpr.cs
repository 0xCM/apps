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
        [MethodImpl(Inline), Op]
        public static TextExpr init(string body)
            => new TextExpr(body);

        public static Dictionary<string,TextVar> vars(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var dst = dict<string,TextVar>();
            var name = EmptyString;
            var parsing = false;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);

                if(!parsing)
                {
                    if(c == TextVar.LeftDelimiter)
                    {
                        name = EmptyString;
                        parsing = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if(nonempty(name) && c == TextVar.RightDelimiter)
                    {
                        dst.TryAdd(name,new TextVar(name));
                        name = EmptyString;
                        parsing = false;
                    }
                    else
                    {
                        name += c;
                    }
                }
            }

            if(nonempty(name))
                dst.TryAdd(name,new TextVar(name));
            return dst;
        }

        readonly Dictionary<string,TextVar> _Vars;

        readonly Index<string> _VarNames;

        public string Body {get;}

        public TextExpr(string body)
        {
            Body = body;
            _Vars = vars(body);
            _VarNames = _Vars.Keys.Array();
        }

        public TextVar this[string var]
        {
            [MethodImpl(Inline)]
            get => _Vars[var];

            [MethodImpl(Inline)]
            set => _Vars[var] = value;
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
                if(v.IsNonEmpty)
                    result = text.replace(result, string.Format("{0}{1}{2}", TextVar.LeftDelimiter, v.Name, TextVar.RightDelimiter), v.Value);
            }
            return result;
        }
    }
}