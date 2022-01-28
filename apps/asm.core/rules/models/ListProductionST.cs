//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListProduction<S,T> : Production<S,ListExpr<T>>
        where S : IRuleExpr
        where T : IRuleExpr
    {
        public ListProduction(S src, T[] dst)
            : base(src, Rules.list(dst))
        {

        }
    }
}