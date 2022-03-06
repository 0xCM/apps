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
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly string Value;

            readonly NameResolver Resolver;

            public readonly bool IsPremise;

            [MethodImpl(Inline)]
            public RuleTerm(bool premise, FieldKind field, RuleOperator @op, string value)
            {
                Field = field;
                Operator = @op;
                Value = value;
                Resolver = NameResolver.Empty;
                IsPremise = premise;
            }

            [MethodImpl(Inline)]
            public RuleTerm(bool premise, FieldKind field, NameResolver resolver)
            {
                Field = field;
                Resolver = resolver;
                Value = string.Format("{0}()", resolver.Name);
                Operator = 0;
                IsPremise = premise;
            }

            [MethodImpl(Inline)]
            public RuleTerm WithValue(string value)
                => new RuleTerm(IsPremise, Field, Operator, value);

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();

            public static RuleTerm Empty => new RuleTerm(false,0,0,EmptyString);
        }
    }
}