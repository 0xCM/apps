//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct Seg
        {
            public readonly FieldKind Field;

            public readonly asci8 Value;

            [MethodImpl(Inline)]
            internal Seg(FieldKind field, asci8 value)
            {
                Field = field;
                Value = value;
            }

            [MethodImpl(Inline)]
            internal Seg(FieldKind field, byte width, asci8 value)
            {
                Field = field;
                Value = value;
            }

            public bool IsSymbolic
            {
                [MethodImpl(Inline)]
                get => !numeric(Value);
            }

            public bool HasValue
            {
                [MethodImpl(Inline)]
                get => numeric(Value);
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

            public static Seg Empty => default;
        }
    }
}