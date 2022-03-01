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
        public struct RuleCriterion
        {
            public FieldKind Kind;

            public RuleOperator Operator;

            public string Value;

            [MethodImpl(Inline)]
            public RuleCriterion(FieldKind kind, RuleOperator @op, string value)
            {
                Kind = kind;
                Operator = @op;
                Value = value;
            }

            public string Format()
            {
                if(Operator == RuleOperator.Call)
                    return string.Format("{0}()", Value);
                else if(Operator != 0)
                    return string.Format("{0}{1}{2}", Symbols.expr(Kind), Symbols.expr(Operator), Value);
                else
                    return string.Format("{0}", Value);
            }

            public override string ToString()
                => Format();
        }
    }
}