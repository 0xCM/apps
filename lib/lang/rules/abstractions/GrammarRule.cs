//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public abstract class GrammarRule: IProduction
    {
        public Label Name {get;}

        public Grammar Grammar {get;}

        protected GrammarRule(Grammar g)
        {
            Grammar = g;
        }

        public string Format()
        {
            return string.Empty;
        }
    }
}