//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct XedRuleExpr
        {
            public RuleFormKind Kind;

            public Index<RuleCriterion> Premise;

            public Index<RuleCriterion> Consequent;

            [MethodImpl(Inline)]
            public XedRuleExpr(RuleFormKind kind, Index<RuleCriterion> left, Index<RuleCriterion> rigth)
            {
                Kind = kind;
                Premise = left;
                Consequent = rigth;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}