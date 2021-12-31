//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System.Runtime.CompilerServices;

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
            => string.Format("{0}({1},{2})", OpName, A.Format(), B.Format());

        public abstract T Create(IExpr a0, IExpr a1);
    }
}