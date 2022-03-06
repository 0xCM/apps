//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleCriterion<T>
            where T : unmanaged
        {
            public readonly bool IsPremise;

            public readonly CriterionKind Kind;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly T Value;

            [MethodImpl(Inline)]
            public RuleCriterion(CriterionKind kind, FieldKind field, RuleOperator op, T value)
            {
                IsPremise = kind == CriterionKind.Premise;
                Field = field;
                Operator = op;
                Value = value;
                Kind = kind;
            }

            [MethodImpl(Inline)]
            public RuleCriterion(bool premise, CriterionKind kind, FieldKind field, RuleOperator op, T value)
            {
                IsPremise = premise;
                Field = field;
                Operator = op;
                Value = value;
                Kind = kind;
            }

            [MethodImpl(Inline)]
            public RuleCriterion<T> WithValue(T value)
                => new RuleCriterion<T>(Kind, Field,Operator,value);
        }
    }
}