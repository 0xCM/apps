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

            public Index<CriterionSpec> Premise;

            public Index<CriterionSpec> Consequent;

            [MethodImpl(Inline)]
            public RuleExpr(RuleFormKind kind, Index<CriterionSpec> premise, Index<CriterionSpec> consequent)
            {
                Kind = kind;
                Premise = premise;
                Consequent = consequent;
            }

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();
        }
    }
}