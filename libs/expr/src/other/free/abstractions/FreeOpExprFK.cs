//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class FreeExpr
    {
        public abstract class FreeOpExpr<F,K> : IFreeExpr<F>, ITextual, IKinded<K>, IKinded
            where F : FreeOpExpr<F, K>
            where K : unmanaged
        {
            public virtual Identifier OpName => typeof(F).Name;

            public abstract string Format();

            public abstract K Kind {get;}

            public abstract uint Size {get;}

            public override string ToString()
                => Format();
        }
    }
}