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

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Premise.IsEmpty && Consequent.IsEmpty;
            }

            public bool IsVacuous
            {
                [MethodImpl(Inline)]
                get => Consequent.IsEmpty;
            }

            public bool IsError
            {
                [MethodImpl(Inline)]
                get => Consequent.Count == 1 && Consequent.First.IsError;
            }

            public bool IsNull
            {
                [MethodImpl(Inline)]
                get => Consequent.Count == 1 && Consequent.First.IsNull;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleExpr Empty => new RuleExpr(sys.empty<RuleCriterion>(), sys.empty<RuleCriterion>());
        }
    }
}