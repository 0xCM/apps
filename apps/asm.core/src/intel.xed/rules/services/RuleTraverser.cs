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

            public void Traverse(RuleSet src)
            {
                Traversing();
                Traverse(src.Tables);
                Traverse(src.Patterns);
            }

            public void Traverse(ReadOnlySpan<RuleTermTable> src)
            {
                iter(src,t => Traverse(t), Pll);
            }

            public void Traverse(in RuleTermTable src)
            {
                Traverse(src, src.Expressions);
            }

            public void Traverse(in RuleTermTable table, ReadOnlySpan<RuleTermExpr> src)
            {
                Traversing(table);
                var sig = table.Sig;
                iter(src, e => Traverse(sig, e));
            }

            public void Traverse(RuleSig table, in RuleTermExpr src)
            {
                Traversing(table, src);
                iter(src.Premise, p => Traverse(table,p));
                iter(src.Consequent, c => Traverse(table,c));
            }

            public void Traverse(RuleSig table, in RuleTerm src)
            {
                var value = src.Format();
                if(RuleTables.spec(src.IsPremise, value, out RuleCriterion spec))
                    Traversing(table, spec);
                else
                    Errors(AppMsg.ParseFailure.Format(nameof(RuleTerm), value));
            }

            public void Traverse(ReadOnlySpan<RulePattern> src)
            {
                iter(src, p => Traverse(p), Pll);
            }

            public void Traverse(in RulePattern src)
            {
                Traversing(src);
                var seq = src.Seq;
                iter(src.Tokens, t => Traverse(seq,t));
            }

            public void Traverse(uint pattern, in RuleToken token)
            {
                Traversing(pattern, token);
            }

            protected virtual void Traversing()
            {

            }

            protected virtual void Traversing(in RuleTermTable src)
            {

            }

            protected virtual void Traversing(in RulePattern src)
            {

            }

            protected virtual void Traversing(uint pattern, in RuleToken token)
            {

            }

            protected virtual void Traversing(in RuleSig table, in RuleCriterion src)
            {

            }

            protected virtual void Traversing(in RuleSig table, in RuleTermExpr src)
            {

            }
        }
    }
}