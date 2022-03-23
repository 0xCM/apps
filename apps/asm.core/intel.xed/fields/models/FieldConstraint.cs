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

            public readonly ConstraintKind Kind;

            public readonly byte Value;

            public readonly FieldLiteralKind LiteralKind;

            [MethodImpl(Inline)]
            public FieldConstraint(FieldKind field, ConstraintKind op, byte value, FieldLiteralKind vk)
            {
                Field = field;
                Kind = op;
                Value = value;
                LiteralKind = vk;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static FieldConstraint Empty => new FieldConstraint(0,0,0,0);
        }
    }
}