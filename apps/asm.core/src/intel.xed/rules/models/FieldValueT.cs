//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct FieldValue<T>
            where T : unmanaged
        {
            public readonly FieldKind Kind;

            public readonly FormatCode FormatCode;

            public readonly T Data;

            [MethodImpl(Inline)]
            public FieldValue(FieldKind field, FormatCode fcode, T value)
            {
                Kind = field;
                FormatCode = fcode;
                Data = value;
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
                => RuleTables.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator FieldValue(FieldValue<T> src)
                => new FieldValue(src.Kind, src.FormatCode, core.bw64(src.Data));
        }
    }
}