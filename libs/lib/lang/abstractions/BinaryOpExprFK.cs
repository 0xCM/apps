//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    public abstract class BinaryOpExpr<F,K> : OpExpr<F,K>
        where F : BinaryOpExpr<F,K>
        where K : unmanaged
    {
        public IExprDeprecated A {get;}

        public IExprDeprecated B {get;}

        [MethodImpl(Inline)]
        protected BinaryOpExpr(IExprDeprecated a, IExprDeprecated b)
        {
            A = a;
            B = b;
        }

        public override string Format()
            => string.Format("{0}({1},{2})", OpName, A.Format(), B.Format());

        public abstract F Create(IExprDeprecated a0, IExprDeprecated a1);
    }
}