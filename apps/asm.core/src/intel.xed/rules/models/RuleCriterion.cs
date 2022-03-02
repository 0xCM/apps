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
            public readonly CriterionKind Kind;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly string Value;

            [MethodImpl(Inline)]
            public RuleCriterion(CriterionKind kind, FieldKind field, RuleOperator @op, string value)
            {
                Kind = kind;
                Field = field;
                Operator = @op;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleCriterion WithValue(string value)
                => new RuleCriterion(Kind, Field, Operator, value);

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion Empty => new RuleCriterion(0,0,0,EmptyString);
        }
    }
}