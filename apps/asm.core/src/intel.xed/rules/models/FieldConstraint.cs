//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct FieldConstraint<T>
            where T : unmanaged
        {
            public readonly FieldKind Field;

            public readonly ConstraintKind Kind;

            public readonly T Value;

            [MethodImpl(Inline)]
            public FieldConstraint(FieldKind field, ConstraintKind op, T value)
            {
                Field = field;
                Kind = op;
                Value = value;
            }

            public string Format()
                => string.Format("{0}{1}{2}", format(Field), format(Kind), Value);

            public override string ToString()
                => Format();

            public static FieldConstraint<T> Empty => default;
        }
    }
}