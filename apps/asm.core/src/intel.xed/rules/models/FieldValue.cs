//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using Asm;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct FieldValue
        {
            public readonly FieldKind Kind;

            public readonly FormatCode FormatCode;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, FormatCode code, ulong value)
            {
                Kind = kind;
                FormatCode = code;
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
            public static implicit operator XedRegId(FieldValue src)
                => (XedRegId)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator IClass(FieldValue src)
                => (IClass)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator ChipCode(FieldValue src)
                => (ChipCode)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator byte(FieldValue src)
                => (byte)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint2(FieldValue src)
                => (uint2)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint3(FieldValue src)
                => (uint3)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint4(FieldValue src)
                => (uint4)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Hex4(FieldValue src)
                => (Hex4)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Disp64(FieldValue src)
                => (Disp64)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator imm64(FieldValue src)
                => (imm64)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Hex8(FieldValue src)
                => (Hex8)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator ushort(FieldValue src)
                => (ushort)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator long(FieldValue src)
                => (long)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator BCastKind(FieldValue src)
                => (BCastKind)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator bit(FieldValue src)
                => (bit)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator EASZ(FieldValue src)
                => (EASZ)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator imm8(FieldValue src)
                => (imm8)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator EOSZ(FieldValue src)
                => (EOSZ)src.Data;

            public static FieldValue Empty => default;
        }
    }
}