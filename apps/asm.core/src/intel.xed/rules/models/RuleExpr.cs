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
            public RuleFormKind Kind;

            public Index<RuleCriterion> Premise;

            public Index<RuleCriterion> Consequent;

            [MethodImpl(Inline)]
            public RuleExpr(RuleFormKind kind, Index<RuleCriterion> left, Index<RuleCriterion> rigth)
            {
                Kind = kind;
                Premise = left;
                Consequent = rigth;
            }

            public bool IsVacant
            {
                [MethodImpl(Inline)]
                get => Premise.Count == 1 && (Premise.First.IsDefault || Premise.First.IsVacant) &&
                    Consequent.Count == 1 && (Consequent.First.IsVacant || Consequent.First.IsDefault);
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}