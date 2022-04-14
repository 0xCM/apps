//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using DT = XedRules.FieldDataKind;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct Field
        {
            public static Field numeric(FieldKind kind, string data)
            {
                var field = Field.Empty;
                if(XedParsers.IsHexLiteral(data))
                {
                    if(XedParsers.parse(data, out Hex8 x8))
                        field = Field.init(kind, x8);
                    else if(XedParsers.parse(data, out Hex16 x16))
                        field = Field.init(kind, x16);
                }
                else if(XedParsers.IsBinaryLiteral(data))
                {
                    if(XedParsers.parse(data, out uint8b b))
                        field = Field.init(kind, b);
                }
                else if(XedParsers.IsIntLiteral(data))
                {
                    if(XedParsers.parse(data, out byte n8))
                        field = Field.init(kind, n8);
                    else if(XedParsers.parse(data, out ushort n16))
                        field = Field.init(kind, n16);
                }
                return field;
            }

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, bit value)
                => new Field((ushort)value, kind, FieldDataKind.Bit);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, byte value)
                => new Field((ushort)value, kind, FieldDataKind.Byte);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, ushort value)
                => new Field((ushort)value, kind, FieldDataKind.Word);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, Register value)
                => new Field((ushort)value, kind, FieldDataKind.Reg);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, ChipCode value)
                => new Field((ushort)value, kind, FieldDataKind.Chip);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, InstClass value)
                => new Field((ushort)value, kind, FieldDataKind.InstClass);

            public readonly ushort Content;

            public readonly FieldKind Kind;

            public readonly FieldDataKind Type;

            [MethodImpl(Inline)]
            Field(ushort content, FieldKind kind, FieldDataKind type)
            {
                Content = content;
                Kind = kind;
                Type = type;
            }

            [MethodImpl(Inline)]
            bit Bit()
                => (bit)Content;


            [MethodImpl(Inline)]
            byte Byte()
                => (byte)Content;

            [MethodImpl(Inline)]
            ushort Word()
                => Content;

            [MethodImpl(Inline)]
            Register Reg()
                => (Register)Content;

            [MethodImpl(Inline)]
            ChipCode Chip()
                => (ChipCode)Content;

            [MethodImpl(Inline)]
            InstClass Inst()
                => (InstClass)Content;

            [MethodImpl(Inline)]
            BCastKind BCast()
                => (BCastKind)Content;

            [MethodImpl(Inline)]
            RuleOperator Operator()
                => (OperatorKind)Content;


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
                        dst = Bit().ToString();
                    break;
                    case DT.Byte:
                        dst = Byte().ToString();
                    break;
                    case DT.Word:
                        dst = Word().ToString();
                    break;
                    case DT.Reg:
                        dst = XedRender.format(Reg());
                    break;
                    case DT.Chip:
                        dst = XedRender.format(Chip());
                    break;
                    case DT.InstClass:
                        dst = XedRender.format(Inst());
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Register(Field src)
                => src.Reg();

            [MethodImpl(Inline)]
            public static implicit operator XedRegId(Field src)
                => src.Reg();

            [MethodImpl(Inline)]
            public static implicit operator IClass(Field src)
                => src.Inst();

            [MethodImpl(Inline)]
            public static implicit operator InstClass(Field src)
                => src.Inst();

            [MethodImpl(Inline)]
            public static implicit operator BCastKind(Field src)
                => src.BCast();

            [MethodImpl(Inline)]
            public static implicit operator ChipCode(Field src)
                => src.Chip();

            [MethodImpl(Inline)]
            public static implicit operator bit(Field src)
                => src.Bit();

            [MethodImpl(Inline)]
            public static implicit operator byte(Field src)
                => src.Byte();

            [MethodImpl(Inline)]
            public static implicit operator Hex8(Field src)
                => src.Byte();

            [MethodImpl(Inline)]
            public static implicit operator ushort(Field src)
                => src.Word();

            [MethodImpl(Inline)]
            public static implicit operator Field((FieldKind kind, Register data) src)
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