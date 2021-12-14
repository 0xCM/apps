//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using XF = ExprPatterns;

    using Expr;

    using static Root;

    readonly struct ExprFormatters
    {
        [Op]
        public static string format(IRuleVar var, char assign)
            => string.Format("{0}{1}{2}", format(var.Symbol), assign, var.Value);

        [Op]
        public static string format(IRuleVar var)
            => format(var, Chars.Eq);

        [Op]
        public static string format(VarContextKind vck, IRuleVar var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.Symbol), assign, var.Value);

        [Op]
        public static string format(VarContextKind vck, IRuleVar var)
            => format(vck,var, Chars.Eq);

        [Op]
        internal static string format(VarSymbol src)
            => format(VarContextKind.Workflow, src);

        [Op]
        internal static string format(VarContextKind vck, VarSymbol src)
            => string.Format(VarContextKinds.FormatPattern(vck), src.Name);

        internal static string format(ExprScope src)
            => src.IsRoot ? src.Name : string.Format(XF.SourceToTarget, src.Name, src.Parent);

        internal static string format(in Var src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.UntypedVar, src);

        internal static string format<T>(in Var<T> src, bool bind = true)
            => bind ? src.Value.Format() : string.Format(XF.TypedVar, src);

        internal static string format(in BoundVar src)
            => string.Format(XF.Binding, src.Var.Name, src.Value);

        internal static string format(in SeqRange src)
            => string.Format(XF.InclusiveRange, src.Min, src.Max);

        public static IFormatter<SeqRange<T>> SeqRange<T>()
            => default(SeqRangeFormatter<T>);

        public static IFormatter<LiteralSeq<T>> LiteralSeq<T>()
            => default(LiteralSeqFormatter<T>);

        public static IFormatter<Literal<T>> Literal<T>()
            => default(LiteralFormatter<T>);

        public static IFormatter<Constant<T>> Constant<T>()
            => default(ConstantFormatter<T>);

        readonly struct SeqRangeFormatter<T> : IFormatter<SeqRange<T>>
        {
            public string Format(SeqRange<T> src)
                => string.Format(XF.InclusiveRange, src.Min, src.Max);
        }

        readonly struct LiteralFormatter<T> : IFormatter<Literal<T>>
        {
            public string Format(Literal<T> src)
                => string.Format("{0} = {1}", src.Name, src.Value.Format());
        }

        readonly struct ConstantFormatter<T> : IFormatter<Constant<T>>
        {
            public string Format(Constant<T> src)
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
        }

        readonly struct LiteralSeqFormatter<T> : IFormatter<LiteralSeq<T>>
        {
            public string Format(LiteralSeq<T> src)
            {
                var dst = text.buffer();
                var lf = Literal<T>();
                var w = core.width<T>();
                var count = src.Count;
                var margin = 0u;
                dst.AppendLineFormat("{1}:seq<uint{0}> = {{", w, src.Name);
                margin +=4;
                for(var i=0; i<count; i++)
                    dst.IndentLine(margin, lf.Format(src[i]));
                margin -=4;
                dst.IndentLine(margin, "}");
                return dst.Emit();
            }
        }
    }
}
