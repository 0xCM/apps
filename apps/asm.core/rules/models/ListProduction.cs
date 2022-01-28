//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListProduction<S,T> : Rule, IProduction<S,ListExpr<T>>
        where S : IExpr
        where T : IExpr
    {
        public S Source {get;}

        public ListExpr<T> Target {get;}

        public ListProduction(S src, T[] dst)
        {
            Source = src;
            Target = dst;
        }
        public override string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();
    }
}