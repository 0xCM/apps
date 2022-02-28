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

            public RuleTableKind Kind;

            public Identifier ReturnType;

            public DataList<XedRuleExpr> Expressions;

            public string Format()
                => XedRules.format(this);

            public override string ToString()
                => Format();

            public static RuleTable Empty
            {
                get
                {
                    var dst = default(RuleTable);
                    dst.Name = Identifier.Empty;
                    dst.Kind = 0;
                    dst.ReturnType = Identifier.Empty;
                    dst.Expressions = new();
                    return dst;
                }
            }
        }
    }
}