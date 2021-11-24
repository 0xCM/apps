//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class ExprFormatter : ITextFormatter
    {
        public abstract string Format(IExpr src);

        public string Format(object src)
            => Format((IExpr)src);
    }

    public abstract class ExprFormatter<T> : ExprFormatter, ITextFormatter<T>
        where T : IExpr
    {
        public abstract string Format(T src);

        public override string Format(IExpr src)
            => Format((T)src);
    }
}