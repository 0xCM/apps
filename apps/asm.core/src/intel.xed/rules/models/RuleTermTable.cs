//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleTermTable
        {
            public Identifier Name;

            public Identifier ReturnType;

            public Index<RuleTermExpr> Expressions;

            public RuleSig Sig
                => sig(this);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleTermTable Empty
            {
                get
                {
                    var dst = default(RuleTermTable);
                    dst.Name = Identifier.Empty;
                    dst.ReturnType = Identifier.Empty;
                    dst.Expressions = sys.empty<RuleTermExpr>();
                    return dst;
                }
            }
        }
    }
}