//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static XedRules;

    public sealed class RuleTraverserX : RuleTraverser
    {
        // [Patterns], [Tables]

        ConcurrentDictionary<RuleSig,Index<RuleTermExpr>> RuleExpressions;

        ConcurrentDictionary<RuleSig, ConcurrentBag<CriterionSpec>> Premise;

        ConcurrentDictionary<RuleSig, ConcurrentBag<CriterionSpec>> Consequent;

        ConcurrentDictionary<RuleSig, RuleTable> Tables2;

        public ConstLookup<RuleSig,Index<RuleTermExpr>> Expressions
            => RuleExpressions;

        public ConstLookup<RuleSig,RuleTable> Tables
            => Tables2;

        readonly Action<string> Errors;

        public RuleTraverserX(Action<string> errors, bool pll = true)
            : base(pll)
        {
            Errors = errors;
        }

        protected override void Traversing(RuleSet src)
        {
            RuleExpressions = new();
            Premise = new();
            Consequent = new();
            Tables2 = new();
        }

        // [RuleExpr]
        protected override void Traversing(in RuleTermTable src)
        {
            Premise.TryAdd(src.Sig, new());
            RuleExpressions.TryAdd(src.Sig, src.Expressions);
            Tables2.TryAdd(src.Sig, RuleTables.table(src));
        }

        // [Premise], [Consequent]
        protected override void Traversing(in RuleSig table, in RuleTermExpr src)
        {
            //F(src.Format());

        }

        protected override void Traversing(in RuleSig table, in RuleTerm src)
        {
            var value = src.Format();
            if(RuleTables.spec(value, src.Kind, out CriterionSpec spec))
            {
                if(spec.IsPremise)
                {
                    if(Premise.TryGetValue(table, out var dst))
                        dst.Add(spec);
                }
                else if(spec.IsConsequent)
                {
                    if(Consequent.TryGetValue(table, out var dst))
                        dst.Add(spec);
                }
                else
                {
                    Errors(string.Format("Unkinded criterion:{0}", value));
                }
            }
            else
            {
                Errors(AppMsg.ParseFailure.Format(nameof(RuleTerm), value));
            }
        }

        // [Tokens]

        protected override void Traversing(in RulePattern src)
        {
            //F(string.Format("{0}", src.Seq, src.Class, src.OcKind, AsmOcValue.format(src.OcValue)));

        }

        protected override void Traversing(uint pattern, in RuleToken token)
        {
            //F(token.Format());
        }
    }

}