//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleCriterion2
        {
            public readonly CriterionKind Kind;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly ulong Value;

            [MethodImpl(Inline)]
            public RuleCriterion2(CriterionKind kind, FieldKind field, RuleOperator @op, ulong value)
            {
                Kind = kind;
                Field = field;
                Operator = @op;
                Value = value;
            }

            public bool IsPremise
            {
                [MethodImpl(Inline)]
                get => Kind == CriterionKind.Premise;
            }

            public bool IsConsequent
            {
                [MethodImpl(Inline)]
                get => Kind == CriterionKind.Consequent;
            }

            [MethodImpl(Inline)]
            public RuleCriterion2 WithValue(ulong value)
                => new RuleCriterion2(Kind, Field, Operator, value);

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion2 Empty => new RuleCriterion2(0,0,0,0);
        }
    }
}