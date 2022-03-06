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

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly T Value;

            [MethodImpl(Inline)]
            public RuleCriterion(bool premise, FieldKind field, RuleOperator op, T value)
            {
                IsPremise = premise;
                Field = field;
                Operator = op;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleCriterion<T> WithValue(T value)
                => new RuleCriterion<T>(IsPremise, Field,Operator,value);
        }
    }
}