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

    public abstract class TextExpr : ITextExpr
    {
        public string Body {get;}

        public abstract ITextVarKind VarKind {get;}

        public abstract string Eval();

        protected TextExpr(string body)
        {
            Body = body;
        }

        public static string EvalFencedVarExpr<V,K>(string expr, ReadOnlySpan<V> vars, K kind)
            where V : ITextVar
            where K : ITextVarKind
        {
            var result = expr;
            var LD = kind.Fence.Left;
            var RD = kind.Fence.Right;
            foreach(var v in vars)
            {
                if(v.IsNonEmpty)
                    result = text.replace(result, string.Format("{0}{1}{2}", LD, v.Name, RD), v.Value);
            }
            return result;
        }

        public static Dictionary<string,V> ParseFencedVars<V,K>(ReadOnlySpan<char> src, K kind, Func<string,V> vf)
            where V : ITextVar
            where K : ITextVarKind
        {
            var count = src.Length;
            var dst = dict<string,V>();
            var name = EmptyString;
            var parsing = false;
            var LD = kind.Fence.Left;
            var RD = kind.Fence.Right;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);

                if(!parsing)
                {
                    if(c == LD)
                    {
                        name = EmptyString;
                        parsing = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if(nonempty(name) && c == RD)
                    {
                        dst.TryAdd(name,vf(name));
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
                dst.TryAdd(name,vf(name));
            return dst;
        }
    }

    public abstract class TextExpr<K> : TextExpr, ITextExpr<K>
        where K : TextVarKind<K>,new()
    {
        protected TextExpr(string body)
            : base(body)
        {

        }

        public override ITextVarKind VarKind
            => new K();
    }
}