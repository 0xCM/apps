//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedFields;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential), DataWidth(88)]
        public readonly struct FieldAssign
        {
            public readonly FieldKind Field;

            public readonly FieldValue Value;

            [MethodImpl(Inline)]
            public FieldAssign(FieldValue value)
            {
                Field = value.Field;
                Value = value;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0;
            }

            [MethodImpl(Inline)]
            public FieldExpr Expression()
                => expr(Field, RuleOperator.Eq, Value);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator FieldAssign(FieldValue src)
                => new FieldAssign(src);

            public static FieldAssign Empty => new FieldAssign(FieldValue.Empty);
        }
    }
}