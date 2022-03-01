//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public struct RuleTable
        {
            public Identifier Name;

            public Identifier ReturnType;

            public Index<XedRuleExpr> Expressions;

            public RuleSig Sig
                => sig(this);

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static RuleTable Empty
            {
                get
                {
                    var dst = default(RuleTable);
                    dst.Name = Identifier.Empty;
                    dst.ReturnType = Identifier.Empty;
                    dst.Expressions = sys.empty<XedRuleExpr>();
                    return dst;
                }
            }
        }
    }
}