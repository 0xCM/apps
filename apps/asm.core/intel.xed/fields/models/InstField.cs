//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public struct InstField : IEquatable<InstField>, IComparable<InstField>
        {
            readonly ByteBlock16 Data;

            const byte OpIndex = 11;

            const byte PosIndex = 12;

            const byte KindIndex = 13;

            const byte FieldIndex = 14;

            const byte ClassIndex = 15;

            [MethodImpl(Inline)]
            public InstField(byte src)
            {
                var data = ByteBlock16.Empty;
                data.First = src;
                data[KindIndex] = (byte)InstFieldKind.IntLiteral;
                data[ClassIndex] = (byte)RuleCellKind.IntLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(uint5 src)
            {
                var data = ByteBlock16.Empty;
                data.First = src;
                data[KindIndex] = (byte)InstFieldKind.BitLiteral;
                data[ClassIndex] = (byte)RuleCellKind.BitLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(Hex8 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[KindIndex] = (byte)InstFieldKind.HexLiteral;
                data[ClassIndex] = (byte)RuleCellKind.HexLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(SegField src)
            {
                var data = ByteBlock16.Empty;
                core.@as<SegField>(data.First) = src;
                data[KindIndex] = (byte)InstFieldKind.Seg;
                data[FieldIndex] = (byte)src.Field;
                data[ClassIndex] = (byte)RuleCellKind.SegField;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(CellExpr src)
            {
                var data = ByteBlock16.Empty;
                @as<ulong>(data.First) = src.Value.Data;
                if(CellParser.parse(src.Format(), out RuleOperator op))
                {
                    data[OpIndex] = (byte)op;
                    switch(op.Kind)
                    {
                        case OperatorKind.Eq:
                            data[ClassIndex] = (byte)RuleCellKind.EqExpr;
                        break;
                        case OperatorKind.Neq:
                            data[ClassIndex] = (byte)RuleCellKind.NeqExpr;
                        break;
                        case OperatorKind.Impl:
                            data[ClassIndex] = (byte)RuleCellKind.Operator;
                        break;
                        default:
                            if(src.IsNonTerminal)
                                data[ClassIndex] = (byte)RuleCellKind.NontermExpr;
                        break;
                    }
                }
                data[KindIndex] = (byte)InstFieldKind.Expr;
                data[FieldIndex] = (byte)src.Field;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(Nonterminal src)
            {
                var data = ByteBlock16.Empty;
                data = (uint)src;
                data[KindIndex] = (byte)InstFieldKind.Nonterm;
                data[ClassIndex] = (byte)RuleCellKind.NontermCall;
                Data = data;
            }

            [MethodImpl(Inline)]
            InstField(ByteBlock16 data)
            {
                Data = data;
            }

            public ref readonly InstFieldKind DataKind
            {
                [MethodImpl(Inline)]
                get => ref @as<InstFieldKind>(Data[KindIndex]);
            }

            public ref readonly FieldKind FieldKind
            {
                [MethodImpl(Inline)]
                get => ref @as<FieldKind>(Data[FieldIndex]);
            }

            public ref readonly CellClass FieldClass
            {
                [MethodImpl(Inline)]
                get => ref @as<CellClass>(Data[ClassIndex]);
            }

            public bool IsFieldExpr
            {
                [MethodImpl(Inline)]
                get => DataKind == InstFieldKind.Expr;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get =>
                   DataKind == InstFieldKind.BitLiteral
                || DataKind == InstFieldKind.HexLiteral
                || DataKind == InstFieldKind.IntLiteral;
            }

            public ref readonly byte Position
            {
                [MethodImpl(Inline)]
                get => ref Data[PosIndex];
            }

            [MethodImpl(Inline)]
            public InstField WithPosition(byte pos)
            {
                var dst = InstField.Empty;
                var data = Data;
                data[PosIndex] = pos;
                return new InstField(data);
            }

            [MethodImpl(Inline)]
            public int CompareTo(InstField src)
                => Position.CompareTo(src.Position);

            [MethodImpl(Inline)]
            public bool Equals(InstField src)
                => Data.Equals(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is InstField p && Equals(p);

            [MethodImpl(Inline)]
            public ref readonly Hex8 AsHexLit()
                => ref @as<Hex8>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly byte AsIntLit()
                => ref @as<byte>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Nonterminal AsNonterminal()
                => ref @as<Nonterminal>(Data.First);

            [MethodImpl(Inline)]
            public CellExpr ToFieldExpr()
                => new CellExpr(
                    (OperatorKind)Data[OpIndex],
                    new CellValue(FieldKind, @as<ulong>(Data.First), FieldClass)
                    );

            [MethodImpl(Inline)]
            public ref readonly SegField AsSegField()
                => ref @as<SegField>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly uint5 AsBitLit()
                => ref @as<uint5>(Data.First);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static InstField Empty => default;
        }
    }
}