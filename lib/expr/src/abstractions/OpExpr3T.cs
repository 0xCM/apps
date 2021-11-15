//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using Expr;


    using static Root;

    public abstract class OpExpr3<T,K> : OpExpr<T,K>
        where T : OpExpr3<T,K>
        where K : unmanaged
    {
        public IExpr A {get;}

        public IExpr B {get;}

        public IExpr C {get;}

        [MethodImpl(Inline)]
        protected OpExpr3(IExpr a, IExpr b, IExpr c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override string Format()
            => expr.format(this);
    }
}