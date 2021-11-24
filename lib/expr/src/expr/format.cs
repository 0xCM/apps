//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using XF = ExprPatterns;

    using Expr;

    partial struct expr
    {
        public static string format(ExprScope src)
            => src.IsRoot ? src.Name.Format() : string.Format(XF.SourceToTarget, src.Name, src.Parent);

        internal static string format(in Var src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.UntypedVar, src);

        internal static string format<T>(in Var<T> src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.TypedVar, src);

        internal static string format<T>(in BoundVar<T> src)
            => string.Format(XF.Binding, src.Var, src.Value);

        internal static string format(in BoundVar src)
            => string.Format(XF.Binding, src.Var.Name, src.Value);

        internal static string format(in SeqRange src)
            => string.Format(XF.InclusiveRange, src.Min, src.Max);

        internal static string format<T>(in SeqRange<T> src)
            => string.Format(XF.InclusiveRange, src.Min, src.Max);
    }
}