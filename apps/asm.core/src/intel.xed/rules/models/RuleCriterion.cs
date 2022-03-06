//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleCriterion
        {
            const string DefaultValue = "otherwise";

            const string VacantValue = "nothing";

            public readonly CriterionKind Kind;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly string Value;

            readonly NameResolver Resolver;

            [MethodImpl(Inline)]
            public RuleCriterion(CriterionKind kind, FieldKind field, RuleOperator @op, string value)
            {
                Kind = kind;
                Field = field;
                Operator = @op;
                Value = value;
                Resolver = NameResolver.Empty;
            }

            [MethodImpl(Inline)]
            public RuleCriterion(CriterionKind kind, FieldKind field, NameResolver resolver)
            {
                Kind = kind;
                Field = field;
                Resolver = resolver;
                Value = string.Format("{0}()", resolver.Name);
                Operator = 0;
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

            public bool IsDefault
            {
                [MethodImpl(Inline)]
                get => Value == DefaultValue;
            }

            public bool IsVacant
            {
                [MethodImpl(Inline)]
                get => Value == VacantValue;
            }

            [MethodImpl(Inline)]
            public RuleCriterion WithValue(string value)
                => new RuleCriterion(Kind, Field, Operator, value);

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion Empty => new RuleCriterion(0,0,0,EmptyString);
        }
    }
}