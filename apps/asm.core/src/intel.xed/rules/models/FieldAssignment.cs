//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct FieldAssignment
        {
            public readonly FieldKind Field;

            public readonly ulong Value;

            [MethodImpl(Inline)]
            public FieldAssignment(FieldKind field, ulong data)
            {
                Field = field;
                Value = data;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static FieldAssignment Empty => new FieldAssignment(FieldKind.INVALID,0);
        }
    }
}