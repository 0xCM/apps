//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class OpExpr2<T,E,K> : OpExpr<T,K>
        where T : OpExpr2<T,E,K>
        where E : IExpr
        where K : unmanaged
    {
        public E A {get;}

        public E B {get;}

        [MethodImpl(Inline)]
        protected OpExpr2(E a, E b)
        {
            A = a;
            B = b;
        }

        public override string Format()
            => string.Format("{0}({1},{2})", OpName, A.Format(), B.Format());

        public abstract T Create(E a, E b);

    }
}