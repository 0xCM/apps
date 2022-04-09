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

            public ref ushort Content
            {
                [MethodImpl(Inline)]
                get => ref @as<ushort>(Storage[ContentIndex]);
            }

            public ref FieldKind Kind
            {
                [MethodImpl(Inline)]
                get => ref @as<FieldKind>(Storage[TypeIndex]);
            }

            public ref FieldDataType Type
            {
                [MethodImpl(Inline)]
                get => ref @as<FieldDataType>(Storage[TypeIndex]);
            }

            ref bit Bit
            {
                [MethodImpl(Inline)]
                get => ref @as<bit>(Content);
            }

            ref byte Byte
            {
                [MethodImpl(Inline)]
                get => ref @as<byte>(Content);
            }

            ref ushort Word
            {
                [MethodImpl(Inline)]
                get => ref Content;
            }

            ref Register Reg
            {
                [MethodImpl(Inline)]
                get => ref @as<Register>(Content);
            }

            ref ChipCode Chip
            {
                [MethodImpl(Inline)]
                get => ref @as<ChipCode>(Content);
            }

            ref InstClass Inst
            {
                [MethodImpl(Inline)]
                get => ref @as<InstClass>(Content);
            }

            ref BCastKind BCast
            {
                [MethodImpl(Inline)]
                get => ref @as<BCastKind>(Content);
            }

            ref RuleOperator Operator
            {
                [MethodImpl(Inline)]
                get => ref @as<RuleOperator>(Content);
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
                    case DT.Word:
                        dst = Word.ToString();
                    break;
                    case DT.Reg:
                        dst = XedRender.format(Reg);
                    break;
                    case DT.BCast:
                        dst = XedRender.format(BCast);
                    break;
                    case DT.Chip:
                        dst = XedRender.format(Chip);
                    break;
                    case DT.InstClass:
                        dst = XedRender.format(Inst);
                    break;
                    case DT.Operator:
                        dst = XedRender.format(Operator);
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