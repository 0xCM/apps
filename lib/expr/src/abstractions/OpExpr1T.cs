//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Expr;


    public abstract class OpExpr1<F,K> : OpExpr<F,K>
        where F : OpExpr1<F,K>
        where K : unmanaged
    {
        public IExpr A {get;}

        protected OpExpr1(IExpr a)
        {
            A = a;
        }

        public override string Format()
            => expr.format(this);

        public abstract F Make(IExpr src);
    }
}