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

        internal static string format<F,K>(OpExpr1<F,K> src)
            where F : OpExpr1<F,K>
            where K : unmanaged
                => string.Format("{0}({1})", src.OpName, src.A.Format());

        internal static string format<F,K>(OpExpr2<F,K> src)
            where F : OpExpr2<F,K>
            where K : unmanaged
                => string.Format("{0}({1},{2})", src.OpName, src.A.Format(), src.B.Format());

        internal static string format<F,K>(OpExpr3<F,K> src)
            where F : OpExpr3<F,K>
            where K : unmanaged
                => string.Format("{0}({1},{2})", src.OpName, src.A.Format(), src.B.Format(), src.C.Format());

        internal static string format(in SeqRange src)
            => string.Format(XF.InclusiveRange, src.Min, src.Max);

        internal static string format<T>(in SeqRange<T> src)
            => string.Format(XF.InclusiveRange, src.Min, src.Max);
    }
}