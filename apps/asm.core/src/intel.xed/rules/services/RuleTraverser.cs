//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public abstract class RuleTraverser
        {
            readonly bool Pll;

            protected readonly Action<string> Errors;

            protected RuleTraverser(Action<string> errors, bool pll = true)
            {
                Errors = errors;
                Pll = pll;
            }

            public void Traverse(Index<RuleTable> src)
            {
                Traversing();
                for(var i=0; i<src.Count; i++)
                    Traverse(src[i]);
            }

            public void Traverse(in RuleTable src)
            {
                Traversing(src);
                Traverse(src, src.Body);
            }

            void Traverse(in RuleTable table, Index<RuleExpr> src)
            {
                for(var i=0; i<src.Count; i++)
                    Traverse(table,src[i]);
            }

            void Traverse(in RuleTable table, in RuleExpr src)
            {
                Traversing(src);
                Traverse(table, src.Premise);
                Traverse(table, src.Consequent);
            }

            void Traverse(in RuleTable table, Index<RuleCriterion> src)
            {
                for(var i=0; i<src.Count; i++)
                    Traverse(table,src[i]);
            }

            void Traverse(in RuleTable table, in RuleCriterion src)
            {
                Traversing(src);
            }

            protected virtual void Traversing(in RuleTable table) {}

            protected virtual void Traversing(in RuleExpr table) {}

            protected virtual void Traversing(in RuleCriterion table) {}

            protected virtual void Traversing() {}
        }
    }
}