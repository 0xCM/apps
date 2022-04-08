//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;
    using static core;

    using DT = XedRules.FieldDataType;

    partial class XedRules
    {
        public struct Field
        {
            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, bit value)
            {
                var dst = ByteBlock4.Empty;
                dst.First = value;
                dst[KindIndex] = (byte)kind;
                dst[TypeIndex]= (byte)FieldDataType.Bit;
                return new Field(dst);
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, byte value)
            {
                var dst = ByteBlock4.Empty;
                dst.First = value;
                dst[KindIndex] = (byte)kind;
                dst[TypeIndex]= (byte)FieldDataType.Byte;
                return new Field(dst);
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, ushort value)
            {
                var dst = ByteBlock4.Empty;
                @as<ushort>(dst.First) = value;
                dst[KindIndex] = (byte)kind;
                dst[TypeIndex]= (byte)FieldDataType.Word;
                return new Field(dst);
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, Register value)
            {
                var dst = ByteBlock4.Empty;
                @as<Register>(dst.First) = value;
                dst[KindIndex] = (byte)kind;
                dst[TypeIndex]= (byte)FieldDataType.Reg;
                return new Field(dst);
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, ChipCode value)
            {
                var dst = ByteBlock4.Empty;
                @as<ChipCode>(dst.First) = value;
                dst[KindIndex] = (byte)kind;
                dst[TypeIndex]= (byte)FieldDataType.Chip;
                return new Field(dst);
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, BCastKind value)
            {
                var dst = ByteBlock4.Empty;
                @as<BCastKind>(dst.First) = value;
                dst[KindIndex] = (byte)kind;
                dst[TypeIndex]= (byte)FieldDataType.BCast;
                return new Field(dst);
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, InstClass value)
            {
                var dst = ByteBlock4.Empty;
                @as<InstClass>(dst.First) = value;
                dst[KindIndex] = (byte)kind;
                dst[TypeIndex]= (byte)FieldDataType.InstClass;
                return new Field(dst);
            }

            ByteBlock4 Storage;

            const byte ContentIndex = 0;

            const byte KindIndex = 2;

            const byte TypeIndex = 3;

            [MethodImpl(Inline)]
            Field(ByteBlock4 data)
            {
                Storage = data;
            }

            public ushort Content
            {
                [MethodImpl(Inline)]
                get => @as<ushort>(Storage[ContentIndex]);
                [MethodImpl(Inline)]
                set => @as<ushort>(Storage[ContentIndex]) = value;
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
            public static implicit operator XedRegId(Field src)
                => src.Reg;

            [MethodImpl(Inline)]
            public static implicit operator IClass(Field src)
                => src.Inst;

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
            public static implicit operator Hex8(Field src)
                => src.Byte;

            [MethodImpl(Inline)]
            public static implicit operator ushort(Field src)
                => src.Word;

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
            public static implicit operator Field(Paired<FieldKind,bit> src)
                => init(src.Left, src.Right);

            [MethodImpl(Inline)]
            public static implicit operator Field(Paired<FieldKind,byte> src)
                => init(src.Left, src.Right);

            [MethodImpl(Inline)]
            public static implicit operator Field((FieldKind kind, ushort data) src)
                => init(src.kind, src.data);

            public static Field Empty => default;
        }
    }
}