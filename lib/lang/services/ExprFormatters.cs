//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using XF = ExprPatterns;

    using Expr;

    using static Root;

    readonly struct ExprFormatters
    {
        public static string format<T>(Literal<T> src)
            => string.Format("{0} = {1}", src.Name, src.Value.Format());

        public static string format<T>(SeqRange<T> src)
            where T : IComparable<T>,IEquatable<T>
                => string.Format(XF.InclusiveRange, src.Min, src.Max);

        [Op]
        public static string format(IExprVar var, char assign)
            => string.Format("{0}{1}{2}", format(var.Name), assign, var.Value);

        [Formatter]
        public static string format(IExprVar var)
            => format(var, Chars.Eq);

        [Op]
        public static string format(VarContextKind vck, IExprVar var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.Name), assign, var.Value);

        [Op]
        public static string format(VarContextKind vck, IExprVar var)
            => format(vck,var, Chars.Eq);

        public static string format<T>(LiteralSeq<T> src)
            where T : IEquatable<T>, IComparable<T>
        {
            var dst = text.buffer();
            var w = core.width<T>();
            var count = src.Count;
            var margin = 0u;
            dst.AppendLineFormat("{1}:seq<uint{0}> = {{", w, src.Name);
            margin +=4;
            for(var i=0; i<count; i++)
                dst.IndentLine(margin, src[i].Format());
            margin -=4;
            dst.IndentLine(margin, "}");
            return dst.Emit();
        }

        public static string format<T>(Constant<T> src)
        {
            var pattern = EmptyString;
            if(typeof(T) == typeof(string))
                pattern = "\"{0}\"";
            else if(typeof(T) == typeof(char))
                pattern = "'{0}'";
            else if(typeof(T) == typeof(uint))
                pattern = "{0}u";
            else if(typeof(T) == typeof(ulong))
                pattern = "{0}ul";
            else if(typeof(T) == typeof(long))
                pattern = "{0}L";
            else
                pattern = "{0}";

            return string.Format(pattern, src.Value);
        }

        [Formatter]
        internal static string format(VarSymbol src)
            => format(VarContextKind.Workflow, src);

        [Op]
        internal static string format(VarContextKind vck, VarSymbol src)
            => string.Format(RP.pattern(vck), src.Name);

        [Formatter]
        internal static string format(ExprScope src)
            => src.IsRoot ? src.Name : string.Format(XF.SourceToTarget, src.Name, src.Parent);

        internal static string format(in Var src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.UntypedVar, src);

        internal static string format<T>(in Var<T> src, bool bind = true)
            => bind ? src.Value.Format() : string.Format(XF.TypedVar, src);

        [Formatter]
        internal static string format(in BoundVar src)
            => string.Format(XF.Binding, src.Var.Name, src.Value);

        [Formatter]
        internal static string format(in SeqRange src)
            => string.Format(XF.InclusiveRange, src.Min, src.Max);
    }
}