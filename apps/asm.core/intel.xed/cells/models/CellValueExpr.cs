//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public class CellValueExpr
        {
            public readonly CellType Type;

            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            CellValueExpr(CellType type, ByteBlock16 data)
            {
                Type = type;
                Data = data;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(CellType type, FieldPack data)
            {
                Type = type;
                Data = data.Pack();
            }

            [MethodImpl(Inline)]
            public CellValueExpr(RuleOperator op)
            {
                Type = CellType.@operator(op);
                Require.invariant(Type.IsNonEmpty);
                Data = (byte)op;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(RuleKeyword kw)
            {
                Type = CellType.keyword();
                Require.invariant(Type.IsNonEmpty);
                Data = (byte)kw;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, bit src)
            {
                Type = type;
                Require.invariant(Type.IsNonEmpty);
                Data = (byte)src;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, byte src)
            {
                Type = type;
                Require.invariant(Type.IsNonEmpty);
                Data = src;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, Nonterminal src)
            {
                Type = type;
                Require.invariant(Type.IsNonEmpty);
                Data = (ushort)src;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, string src)
            {
                Type = type;
                Require.invariant(Type.IsNonEmpty);
                Asci.encode(src, out asci16 dst);
                Data = dst.Storage;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(char src)
            {
                Type = CellType.@char();
                Require.invariant(Type.IsNonEmpty);
                Data = (byte)src;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(in CellType type, SegSpec src)
            {
                Type = type;
                Require.invariant(Type.IsNonEmpty);
                Data = src.Pattern.Storage;
            }

            public FieldPack Pack()
                => FieldPack.unpack(core.u32(Data[0]));

            [MethodImpl(Inline)]
            public asci16 ToAsci()
                => new(Data.Bytes);

            [MethodImpl(Inline)]
            public char ToChar()
                => (char)Data[0];

            [MethodImpl(Inline)]
            public bit ToBit()
                => (bit)Data[0];

            [MethodImpl(Inline)]
            public Hex8 ToHex8()
                => Data[0];

            [MethodImpl(Inline)]
            public RuleKeyword ToKeyword()
                => RuleKeyword.from((RuleKeyWordKind)Data[0]);

            [MethodImpl(Inline)]
            public RuleOperator ToOperator()
                => (OperatorKind)Data[0];

            [MethodImpl(Inline)]
            public Nonterminal ToNonterm()
                => (Nonterminal)core.u16(Data[0]);

            [MethodImpl(Inline)]
            public byte ToByte()
                => Data[0];

            public RuleOperator Operator
            {
                [MethodImpl(Inline)]
                get => Type.Operator;
            }

            public FieldKind Field
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
                => src.ToNonterm();

            [MethodImpl(Inline)]
            public static explicit operator asci16(CellValueExpr src)
                => src.ToAsci();

            [MethodImpl(Inline)]
            public static explicit operator char(CellValueExpr src)
                => src.ToChar();

            [MethodImpl(Inline)]
            public static explicit operator RuleOperator(CellValueExpr src)
                => src.ToOperator();

            [MethodImpl(Inline)]
            public static explicit operator bit(CellValueExpr src)
                => src.ToBit();

            public static CellValueExpr Empty => new CellValueExpr(CellType.Empty, ByteBlock16.Empty);
        }
    }
}