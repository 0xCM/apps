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
            [MethodImpl(Inline)]
            public static FieldConstraint from(in InstDefField src)
                => new FieldConstraint((FieldKind)src[0], src[1], (ConstraintKind)src[2], (FieldLiteralKind)src[3]);

            public readonly FieldKind Field;

            public readonly byte Value;

            public readonly ConstraintKind Kind;

            public readonly FieldLiteralKind LiteralKind;

            [MethodImpl(Inline)]
            public FieldConstraint(FieldKind field, byte value, ConstraintKind op, FieldLiteralKind vk)
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

            public static FieldConstraint Empty => new FieldConstraint(FieldKind.INVALID,0,ConstraintKind.None,FieldLiteralKind.None);
        }
    }
}