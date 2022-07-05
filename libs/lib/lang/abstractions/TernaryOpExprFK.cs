//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class TernaryOpExpr<F,K> : OpExpr<F,K>
        where F : TernaryOpExpr<F,K>
        where K : unmanaged
    {
        public IExprDeprecated A {get;}

        public IExprDeprecated B {get;}

        public IExprDeprecated C {get;}

        [MethodImpl(Inline)]
        protected TernaryOpExpr(IExprDeprecated a, IExprDeprecated b, IExprDeprecated c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override string Format()
            => string.Format("{0}({1},{2})", OpName, A.Format(), B.Format(), C.Format());
    }
}