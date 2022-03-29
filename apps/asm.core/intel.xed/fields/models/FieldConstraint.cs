//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1), DataWidth(32)]
        public readonly struct FieldConstraint
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly FieldValue Value;

            [MethodImpl(Inline)]
            public FieldConstraint(FieldKind field, RuleOperator op, FieldValue value)
            {
                Field = field;
                Operator = op;
                Value = value;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Value.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Value.IsNonEmpty;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static FieldConstraint Empty => new FieldConstraint(FieldKind.INVALID,0,FieldValue.Empty);
        }
    }
}