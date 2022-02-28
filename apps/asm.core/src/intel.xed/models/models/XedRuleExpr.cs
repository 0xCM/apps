//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct XedModels
    {
        public struct XedRuleExpr
        {
            public XedRuleExprKind Kind;

            public TextBlock Premise;

            public TextBlock Consequent;

            public Index<RuleCriterion> LeftCriteria {get;}

            public Index<RuleCriterion> RightCriteria {get;}

            [MethodImpl(Inline)]
            public XedRuleExpr(XedRuleExprKind kind, string premise, string consequent, Index<RuleCriterion> left, Index<RuleCriterion> rigth)
            {
                Kind = kind;
                Premise = premise;
                Consequent = consequent;
                LeftCriteria = left;
                RightCriteria = rigth;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}