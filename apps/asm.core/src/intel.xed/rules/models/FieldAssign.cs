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

            readonly FieldValue _Value;

            [MethodImpl(Inline)]
            public FieldAssign(FieldValue value)
            {
                Field = value.Kind;
                _Value = value;
            }

            public readonly ulong Value
            {
                [MethodImpl(Inline)]
                get => _Value.Data;
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
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static FieldAssign Empty => new FieldAssign(FieldValue.Empty);
        }
    }
}