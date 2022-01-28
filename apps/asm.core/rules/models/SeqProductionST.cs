//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SeqProduction<S,T> : Production<RuleValue<S>, SeqRule<T>>
        where T : IRuleExpr
    {
        public SeqProduction(S src, T[] dst)
            : base(src,dst)
        {


        }
    }
}