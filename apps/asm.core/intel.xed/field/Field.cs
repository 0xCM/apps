//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    using DT = XedRules.FieldDataType;

    partial class XedRules
    {
        public struct Field
        {
            [MethodImpl(Inline)]
            public static Field init(uint storage)
            {
                var dst = Empty;
                dst.Storage = storage;
                return dst;
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, bit value)
            {
                var dst = Field.Empty;
                dst.Bit = value;
                dst.Kind = kind;
                dst.Type = FieldDataType.Bit;
                return dst;
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, byte value)
            {
                var dst = Field.Empty;
                dst.Byte = value;
                dst.Kind = kind;
                dst.Type = FieldDataType.Byte;
                return dst;
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, ushort value)
            {
                var dst = Field.Empty;
                dst.Word = value;
                dst.Kind = kind;
                dst.Type = FieldDataType.Word;
                return dst;
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, Register value)
            {
                var dst = Field.Empty;
                dst.Reg = value;
                dst.Kind = kind;
                dst.Type = FieldDataType.Reg;
                return dst;
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, ChipCode value)
            {
                var dst = Field.Empty;
                dst.Chip = value;
                dst.Kind = kind;
                dst.Type = FieldDataType.Chip;
                return dst;
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, BCastKind value)
            {
                var dst = Field.Empty;
                dst.BCast = value;
                dst.Kind = kind;
                dst.Type = FieldDataType.BCast;
                return dst;
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, InstClass value)
            {
                var dst = Field.Empty;
                dst.Inst = value;
                dst.Kind = kind;
                dst.Type = FieldDataType.InstClass;
                return dst;
            }

            ByteBlock4 Storage;

            const byte ContentIndex = 0;

            const byte KindIndex = 2;

            const byte TypeIndex = 3;

            public ushort Content
            {
                [MethodImpl(Inline)]
                get => core.u16(Storage[ContentIndex]);
                [MethodImpl(Inline)]
                set => core.u16(Storage[ContentIndex]) = value;
            }

            public FieldKind Kind
            {
                get => (FieldKind)Storage[KindIndex];
                set => Storage[KindIndex] = (byte)value;
            }

            public FieldDataType Type
            {
                get => (FieldDataType)Storage[TypeIndex];
                set => Storage[TypeIndex] = (byte)value;
            }

            bit Bit
            {
                [MethodImpl(Inline)]
                get => (bit)Content;
                [MethodImpl(Inline)]
                set => Content = (ushort)value;
            }

            byte Byte
            {
                [MethodImpl(Inline)]
                get => (byte)Content;
                [MethodImpl(Inline)]
                set => Content = value;
            }

            ushort Word
            {
                [MethodImpl(Inline)]
                get => Content;
                [MethodImpl(Inline)]
                set => Content = value;
            }

            Register Reg
            {
                [MethodImpl(Inline)]
                get => (Register)Content;
                [MethodImpl(Inline)]
                set => Content = (ushort)value;
            }

            ChipCode Chip
            {
                [MethodImpl(Inline)]
                get => (ChipCode)Content;
                [MethodImpl(Inline)]
                set => Content = (ushort)value;
            }

            InstClass Inst
            {
                [MethodImpl(Inline)]
                get => (InstClass)Content;
                [MethodImpl(Inline)]
                set => Content = (ushort)value;
            }

            BCastKind BCast
            {
                [MethodImpl(Inline)]
                get => (BCastKind)Content;
                [MethodImpl(Inline)]
                set => Content = (ushort)value;
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
            {
                var dst = EmptyString;
                switch(Type)
                {
                    case DT.Bit:
                        dst = Bit.ToString();
                    break;
                    case DT.Byte:
                        dst = Byte.ToString();
                    break;
                    case DT.Chip:
                        dst = XedRender.format(Chip);
                    break;
                    case DT.InstClass:
                        dst = XedRender.format(Inst);
                    break;
                    case DT.Reg:
                        dst = XedRender.format(Reg);
                    break;
                    case DT.Word:
                        dst = Word.ToString();
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Register(Field src)
                => src.Reg;

            [MethodImpl(Inline)]
            public static implicit operator InstClass(Field src)
                => src.Inst;

            [MethodImpl(Inline)]
            public static implicit operator BCastKind(Field src)
                => src.BCast;

            [MethodImpl(Inline)]
            public static implicit operator ChipCode(Field src)
                => src.Chip;

            [MethodImpl(Inline)]
            public static implicit operator bit(Field src)
                => src.Bit;

            [MethodImpl(Inline)]
            public static implicit operator byte(Field src)
                => src.Byte;

            [MethodImpl(Inline)]
            public static implicit operator ushort(Field src)
                => src.Word;

            [MethodImpl(Inline)]
            public static implicit operator uint(Field src)
                => src.Storage;

            [MethodImpl(Inline)]
            public static implicit operator Field(uint src)
                => init(src);

            [MethodImpl(Inline)]
            public static implicit operator Field((FieldKind kind, Register data) src)
                => init(src.kind, src.data);

            [MethodImpl(Inline)]
            public static implicit operator Field((FieldKind kind, BCastKind data) src)
                => init(src.kind, src.data);

            [MethodImpl(Inline)]
            public static implicit operator Field((FieldKind kind, ChipCode data) src)
                => init(src.kind, src.data);

            [MethodImpl(Inline)]
            public static implicit operator Field((FieldKind kind, InstClass data) src)
                => init(src.kind, src.data);

            [MethodImpl(Inline)]
            public static implicit operator Field((FieldKind kind, bit data) src)
                => init(src.kind, src.data);

            [MethodImpl(Inline)]
            public static implicit operator Field((FieldKind kind, byte data) src)
                => init(src.kind, src.data);

            [MethodImpl(Inline)]
            public static implicit operator Field((FieldKind kind, ushort data) src)
                => init(src.kind, src.data);

            public static Field Empty => default;
        }
    }
}