//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IExpr<K> : IExpr, IKinded<K>
        where K : unmanaged
    {
        ulong IExpr.Kind
            => core.bw64((this as IKinded<K>).Kind);
    }

    public abstract class Expr<F,K> : IExpr<K>
        where F : Expr<F,K>
        where K : unmanaged
    {
        public abstract K Kind {get;}

        public abstract string Format();

        public override string ToString()
            => Format();
    }
}