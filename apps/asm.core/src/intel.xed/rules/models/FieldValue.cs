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

            public readonly FieldDataType Type;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, FieldDataType type, ulong value)
            {
                Kind = kind;
                Type = type;
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

            public static FieldValue Empty => default;
        }
    }
}