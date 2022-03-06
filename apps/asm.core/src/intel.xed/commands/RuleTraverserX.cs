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

        ConcurrentDictionary<RuleSig,Index<RuleExpr>> TableLookup;

        public ConstLookup<RuleSig,Index<RuleExpr>> Tables
            => TableLookup;

        readonly Action<string> F;

        public RuleTraverserX(Action<string> f)
        {
            F = f;
        }

        protected override void Traversing(RuleSet src)
        {
            TableLookup = new();
        }

        // [RuleExpr]
        protected override void Traversing(in RuleTable src)
        {
            TableLookup.TryAdd(src.Sig, src.Expressions);
            //F(src.Sig.Format());
        }

        // [Premise], [Consequent]
        protected override void Traversing(in RuleSig table, in RuleExpr src)
        {
            //F(src.Format());

        }

        protected override void Traversing(in RuleSig table, in RuleCriterion src)
        {
            //F(src.Format());
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