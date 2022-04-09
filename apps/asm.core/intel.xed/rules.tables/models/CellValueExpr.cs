//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct CellValueExpr
        {
            public readonly CellType Type;

            public readonly FieldDataType DataType;

            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            CellValueExpr(CellType type, ByteBlock16 data)
            {
                Type = type;
                Data = data;
                DataType = 0;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(CellType type, Field field)
            {
                var data = ByteBlock16.Empty;
                @as<ushort>(data.First) = field.Content;
                Data = data;
                Type = type;
                DataType = field.Type;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(RuleOperator op)
            {
                var data = ByteBlock16.Empty;
                @as<RuleOperator>(data.First) = op;
                Data = data;
                Type = CellType.@operator(op);
                DataType = FieldDataType.Operator;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(RuleKeyword src)
            {
                var data = ByteBlock16.Empty;
                @as<RuleKeyword>(data.First) = src;
                Data = data;
                Type = CellType.keyword();
                DataType = FieldDataType.Keyword;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, byte src)
            {
                Type = type;
                Data = src;
                DataType = FieldDataType.Byte;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, Nonterminal src)
            {
                var data = ByteBlock16.Empty;
                @as<Nonterminal>(data.First) = src;
                Data = data;
                Type = type;
                DataType = FieldDataType.Nonterminal;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, NontermExpr src)
            {
                var data = ByteBlock16.Empty;
                @as<NontermExpr>(data.First) = src;
                Data = data;
                Type = type;
                DataType = FieldDataType.Nonterminal;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, Seg src)
            {
                var data = ByteBlock16.Empty;
                @as<Seg>(data.First) = src;
                Data = data;
                Type = type;
                DataType = FieldDataType.Seg;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, asci16 src)
            {
                var data = ByteBlock16.Empty;
                @as<asci16>(data.First) = src;
                Data = data;
                Type = type;
                DataType = FieldDataType.Text;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, SegSpec src)
            {
                Type = type;
                var data = ByteBlock16.Empty;
                @as<SegSpec>(data.First) = src;
                Data = data;
                DataType = FieldDataType.SegSpec;
            }

            public RuleCellKind CellKind
            {
                [MethodImpl(Inline)]
                get => Type.Class.Kind;
            }

            [MethodImpl(Inline)]
            public ref readonly asci16 AsAsci()
                => ref @as<asci16>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Seg AsSeg()
                => ref @as<Seg>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Field AsField()
                => ref @as<Field>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly char AsChar()
                => ref @as<char>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly bit AsBit()
                => ref @as<bit>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Hex8 AsHex8()
                => ref @as<Hex8>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly RuleKeyword AsKeyword()
                => ref @as<RuleKeyword>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly RuleOperator AsOperator()
                => ref @as<RuleOperator>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Nonterminal AsNonterm()
                => ref @as<Nonterminal>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly NontermExpr AsNontermExpr()
                => ref @as<NontermExpr>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly SegSpec AsSegSpec()
                => ref @as<SegSpec>(Data.First);

            [MethodImpl(Inline)]
            public byte ToByte()
                => Data[0];

            [MethodImpl(Inline)]
            public ref readonly BCastKind AsBCast()
                => ref @as<BCastKind>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly ChipCode AsChip()
                => ref @as<ChipCode>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly InstClass AsInstClass()
                => ref @as<InstClass>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly ushort AsWord()
                => ref @as<ushort>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Register AsReg()
                => ref @as<Register>(Data.First);

            public FieldKind FieldKind
            {
                [MethodImpl(Inline)]
                get => Type.Field;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Type.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Type.IsNonEmpty;
            }

            public bool Equals(CellValueExpr src)
                => Data == src.Data && Type.Equals(src.Type);

            [MethodImpl(Inline)]
            public string Format()
                => CellRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator byte(CellValueExpr src)
                => src.ToByte();

            [MethodImpl(Inline)]
            public static explicit operator Nonterminal(CellValueExpr src)
                => src.AsNonterm();

            [MethodImpl(Inline)]
            public static explicit operator asci16(CellValueExpr src)
                => src.AsAsci();

            [MethodImpl(Inline)]
            public static explicit operator char(CellValueExpr src)
                => src.AsChar();

            [MethodImpl(Inline)]
            public static explicit operator RuleOperator(CellValueExpr src)
                => src.AsOperator();

            [MethodImpl(Inline)]
            public static explicit operator bit(CellValueExpr src)
                => src.AsBit();

            public static CellValueExpr Empty => new CellValueExpr(CellType.Empty, ByteBlock16.Empty);
        }
    }
}