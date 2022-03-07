//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct FieldValue
        {
            public readonly FieldKind Kind;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            public FieldValue(FieldKind field, ulong value)
            {
                Kind = field;
                Data = value;
            }

            public FieldDataType DataType
            {
                [MethodImpl(Inline)]
                get => datatype(Kind);
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

            [MethodImpl(Inline)]
            public static implicit operator FieldValue((FieldKind field, ulong value) src)
                => new FieldValue(src.field, src.value);
        }
    }
}