//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public abstract class TextExpr : ITextExpr
    {
        public string Body {get;}

        public ITextVarKind VarKind {get;}

        public ITextVar this[string var]
        {
            [MethodImpl(Inline)]
            get => VarLookup[var];

            [MethodImpl(Inline)]
            set => VarLookup[var] = value;
        }

        public ITextVar[] Vars
        {
            [MethodImpl(Inline)]
            get => VarLookup.Values.Array();
        }

        protected Dictionary<string,ITextVar> VarLookup;

        public virtual string Eval()
        {
            switch(VarKind.Class)
            {
                case TextVarClass.PrefixedFence:
                    return EvalPrefixFencedVarExpr(Body, Vars, VarKind);
                case TextVarClass.Fenced:
                    return EvalFencedVarExpr(Body, Vars, VarKind);
                case TextVarClass.Prefixed:
                    return EvalPrefixedVarExpr(Body, Vars, VarKind);
            }
            return EmptyString;
        }

        protected TextExpr(string body, ITextVarKind kind)
        {
            Body = body;
            VarKind = kind;
        }

        public static TextVarClass VarClass(ITextVarKind kind)
        {
            if(kind.IsPrefixedFence)
                return TextVarClass.PrefixedFence;
            else if(kind.IsFenced)
                return TextVarClass.Fenced;
            else if(kind.IsPrefixed)
                return TextVarClass.Prefixed;
            else
                return 0;
        }

        public static string FormatVariable(ITextVar src)
        {
            var kind = src.VarKind;
            var @class = VarClass(kind);
            if(src.IsNonEmpty)
                return src.Value;

            switch(@class)
            {
                case TextVarClass.PrefixedFence:
                    return string.Format("{0}{1}{2}{3}", kind.Prefix, kind.Fence.Left, src.Name, kind.Fence.Right);
                case TextVarClass.Fenced:
                    return string.Format("{0}{1}{2}", kind.Fence.Left, src.Name, kind.Fence.Right);
                case TextVarClass.Prefixed:
                    return string.Format("{0}{1}", kind.Prefix, src.Name);
            }
            return EmptyString;
        }

        public static string EvalFencedVarExpr(string expr, ReadOnlySpan<ITextVar> vars, ITextVarKind kind)
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

        public static string EvalPrefixFencedVarExpr(string expr, ReadOnlySpan<ITextVar> vars, ITextVarKind kind)
        {
            var result = expr;
            var LD = kind.Fence.Left;
            var RD = kind.Fence.Right;
            var prefix = kind.Prefix;
            foreach(var v in vars)
            {
                if(v.IsNonEmpty)
                    result = text.replace(result, string.Format("{0}{1}{2}{3}", prefix, LD, v.Name, RD), v.Value);
            }
            return result;
        }

        public static string EvalPrefixedVarExpr(string expr, ReadOnlySpan<ITextVar> vars, ITextVarKind kind)
        {
            var result = expr;
            var prefix = kind.Prefix;
            foreach(var v in vars)
            {
                if(v.IsNonEmpty)
                    result = text.replace(result, string.Format("{0}{1}", prefix, v.Name), v.Value);
            }
            return result;
        }

        public static Dictionary<string,ITextVar> ParseFencedVars(ReadOnlySpan<char> src, ITextVarKind kind, Func<string,ITextVar> vf)
        {
            var count = src.Length;
            var dst = dict<string,ITextVar>();
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

        public static Dictionary<string,ITextVar> ParsePrefixedVars(ReadOnlySpan<char> src, ITextVarKind kind, Func<string,ITextVar> vf)
        {
            var count = src.Length;
            var dst = dict<string,ITextVar>();
            var name = EmptyString;
            var parsing = false;
            var prefix = kind.Prefix;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);

                if(!parsing)
                {
                    if(c == prefix)
                    {
                        name = EmptyString;
                        parsing = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if(c == Chars.Space)
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

        public static Dictionary<string,ITextVar> ParsePrefixedFencedVars(ReadOnlySpan<char> src, ITextVarKind kind, Func<string,ITextVar> vf)
        {
            var count = src.Length;
            var dst = dict<string,ITextVar>();
            var name = EmptyString;
            var parsing = false;
            var LD = kind.Fence.Left;
            var RD = kind.Fence.Right;
            var prefix = kind.Prefix;

            for(var i=0; i<count-1; i++)
            {
                ref readonly var c0 = ref skip(src,i);
                ref readonly var c1 = ref skip(src,i+1);

                if(!parsing)
                {
                    if(c0 == prefix && c1 == LD)
                    {
                        name = EmptyString;
                        parsing = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if(nonempty(name) && c1 == RD)
                    {
                        dst.TryAdd(name,vf(name));
                        name = EmptyString;
                        parsing = false;
                    }
                    else
                    {
                        name += c1;
                    }
                }
            }

            if(nonempty(name))
                dst.TryAdd(name, vf(name));
            return dst;
        }
    }
}