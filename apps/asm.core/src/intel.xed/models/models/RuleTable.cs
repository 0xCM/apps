//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public struct RuleTable
        {
            public Identifier Name;

            public RuleTableKind Kind;

            public Identifier ReturnType;

            public DataList<XedRuleExpr> Expressions;

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