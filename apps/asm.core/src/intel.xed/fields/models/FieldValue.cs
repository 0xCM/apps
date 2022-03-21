//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    using Asm;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct FieldValue : IEquatable<FieldValue>
        {
            public readonly FieldKind Field;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, bit data)
            {
                Field = kind;
                Data = (byte)data;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, byte data)
            {
                Field = kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, ushort data)
            {
                Field = kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public FieldValue(BitfieldSeg data)
            {
                Field = data.Field;
                Data = (ulong)data.Pattern;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, ImmFieldSpec data)
            {
                Field = kind;
                Data = @as<ImmFieldSpec,ushort>(data);
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, ulong data)
            {
                Field = kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, Disp64 data)
            {
                Field = kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, XedRegId data)
            {
                Field = kind;
                Data = (ulong)data;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, Nonterminal data)
            {
                Field = kind;
                Data = @as<Nonterminal,uint>(data);
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, DispFieldSpec data)
            {
                Field = kind;
                Data = @as<DispFieldSpec,uint>(data);
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, BCastKind data)
            {
                Field = kind;
                Data = (uint)data;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, IClass data)
            {
                Field = kind;
                Data = (uint)data;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, ChipCode data)
            {
                Field = kind;
                Data = (uint)data;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, EASZ data)
            {
                Field = kind;
                Data = (uint)data;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, EOSZ data)
            {
                Field = kind;
                Data = (uint)data;
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
            public bool Equals(FieldValue src)
                => Field == src.Field && Data == src.Data;

            public override bool Equals(object src)
                => src is FieldValue x && Equals(x);

            public uint Hash
            {
                [MethodImpl(Inline)]
                get => (uint)((ulong)Field << 24 | (Data & 0xFFFFFF));
            }

            public override int GetHashCode()
                => (int)Hash;

            public string Format()
                => XedRender.format(this);

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