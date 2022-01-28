//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SeqProduction<S,T> : Production<Value<S>, SeqExpr<T>>
        where T : IRuleExpr
    {
        public SeqProduction(S src, T[] dst)
            : base(src,dst)
        {


        }
    }
}