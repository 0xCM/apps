//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleTerm
        {
            public readonly CriterionKind Kind;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly string Value;

            readonly NameResolver Resolver;

            [MethodImpl(Inline)]
            public RuleTerm(CriterionKind kind, FieldKind field, RuleOperator @op, string value)
            {
                Kind = kind;
                Field = field;
                Operator = @op;
                Value = value;
                Resolver = NameResolver.Empty;
            }

            [MethodImpl(Inline)]
            public RuleTerm(CriterionKind kind, FieldKind field, NameResolver resolver)
            {
                Kind = kind;
                Field = field;
                Resolver = resolver;
                Value = string.Format("{0}()", resolver.Name);
                Operator = 0;
            }


            [MethodImpl(Inline)]
            public RuleTerm WithValue(string value)
                => new RuleTerm(Kind, Field, Operator, value);

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();

            public static RuleTerm Empty => new RuleTerm(0,0,0,EmptyString);
        }
    }
}