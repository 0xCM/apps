//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public sealed class TableCollector : RuleTraverser
        {
            ConcurrentDictionary<RuleSig,Index<RuleTermExpr>> RuleExpressions;

            ConcurrentDictionary<RuleSig, ConcurrentBag<RuleCriterion>> Premise;

            ConcurrentDictionary<RuleSig, ConcurrentBag<RuleCriterion>> Consequent;

            ConcurrentDictionary<RuleSig, RuleTable> TableLookup;

            public ConstLookup<RuleSig,RuleTable> Tables
                => TableLookup;

            public TableCollector(Action<string> errors, bool pll = true)
                : base(errors,pll)
            {

            }

            protected override void Traversing()
            {
                RuleExpressions = new();
                Premise = new();
                Consequent = new();
                TableLookup = new();
            }

            protected override void Traversing(in RuleTermTable src)
            {
                Premise.TryAdd(src.Sig, new());
                RuleExpressions.TryAdd(src.Sig, src.Expressions);
                TableLookup.TryAdd(src.Sig, RuleTables.table(src));
            }

            protected override void Traversing(in RuleSig table, in RuleCriterion src)
            {
                if(src.IsPremise)
                {
                    if(Premise.TryGetValue(table, out var dst))
                        dst.Add(src);
                }
                else if(src.IsConsequent)
                {
                    if(Consequent.TryGetValue(table, out var dst))
                        dst.Add(src);
                }
            }

            protected override void Traversing(in RulePattern src)
            {

            }

            protected override void Traversing(uint pattern, in RuleToken token)
            {
            }
        }

    }
}