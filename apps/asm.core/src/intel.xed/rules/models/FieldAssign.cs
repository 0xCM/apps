//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct FieldAssign
        {
            public readonly FieldKind Field;

            public readonly ulong Value;

            [MethodImpl(Inline)]
            public FieldAssign(FieldKind field, ulong data)
            {
                Field = field;
                Value = data;
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

            public string Format()
                => RuleTables.format(this);

            public override string ToString()
                => Format();

            public static FieldAssign Empty => new FieldAssign(FieldKind.INVALID,0);
        }
    }
}