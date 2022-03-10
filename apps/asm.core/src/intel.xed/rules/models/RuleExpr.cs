//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleExpr
        {
            public Index<RuleCriterion> Premise;

            public Index<RuleCriterion> Consequent;

            [MethodImpl(Inline)]
            public RuleExpr(Index<RuleCriterion> premise, Index<RuleCriterion> consequent)
            {
                Premise = premise;
                Consequent = consequent;
            }

            public bool IsNonterminal
            {
                [MethodImpl(Inline)]
                get => Consequent.Any(x => x.IsNonterminal);
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();
        }
    }
}