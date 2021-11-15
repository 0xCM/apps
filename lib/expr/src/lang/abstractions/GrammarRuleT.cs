//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public abstract class GrammarRule<T> : GrammarRule
        where T : IExpr
    {
        protected GrammarRule(Grammar g)
            : base(g)
        {

        }

        public abstract T Term {get;}
    }
}