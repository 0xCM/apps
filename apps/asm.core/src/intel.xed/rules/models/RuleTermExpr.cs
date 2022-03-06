//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleTermExpr
        {
            public RuleFormKind Kind;

            public Index<RuleTerm> Premise;

            public Index<RuleTerm> Consequent;

            [MethodImpl(Inline)]
            public RuleTermExpr(RuleFormKind kind, Index<RuleTerm> premise, Index<RuleTerm> consequent)
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