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
            public readonly FieldKind Field;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, ulong value)
            {
                Field = kind;
                Data = value;
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

            [MethodImpl(Inline)]
            public FieldValue WithValue(Disp64 src)
                => new FieldValue(Field,src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(bit src)
                => new FieldValue(Field, (ulong)src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(byte src)
                => new FieldValue(Field,src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(ushort src)
                => new FieldValue(Field,src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(XedRegId src)
                => new FieldValue(Field,(ulong)src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(Hex8 src)
                => new FieldValue(Field,(ulong)src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(imm8 src)
                => new FieldValue(Field,(ulong)src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(imm64 src)
                => new FieldValue(Field,(ulong)src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(BCastKind src)
                => new FieldValue(Field,(ulong)src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(IClass src)
                => new FieldValue(Field,(ulong)src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(ChipCode src)
                => new FieldValue(Field,(ulong)src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(EASZ src)
                => new FieldValue(Field,(ulong)src);

            [MethodImpl(Inline)]
            public FieldValue WithValue(EOSZ src)
                => new FieldValue(Field,(ulong)src);

            [MethodImpl(Inline)]
            public bool Equals(FieldValue src)
                => Field == src.Field && Data == src.Data;

            public override bool Equals(object src)
                => src is FieldValue x && Equals(x);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => (int)(((uint)Field << 24) | (Data & 0xFFFFFF));

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

            [MethodImpl(Inline)]
            public static bool operator ==(FieldValue a, FieldValue b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(FieldValue a, FieldValue b)
                => !a.Equals(b);

            public static FieldValue Empty => default;
        }
    }
}