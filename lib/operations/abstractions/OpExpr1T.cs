//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
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
            => string.Format("{0}({1})", OpName, A.Format());

        public abstract F Create(IExpr src);
    }
}