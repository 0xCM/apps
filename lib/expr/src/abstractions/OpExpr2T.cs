//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using Expr;

    using static Root;

    public abstract class OpExpr2<T,K> : OpExpr<T,K>
        where T : OpExpr2<T,K>
        where K : unmanaged
    {
        public IExpr A {get;}

        public IExpr B {get;}

        [MethodImpl(Inline)]
        protected OpExpr2(IExpr a, IExpr b)
        {
            A = a;
            B = b;
        }

        public override string Format()
            => expr.format(this);

        public abstract T Make(IExpr a0, IExpr a1);
    }
}