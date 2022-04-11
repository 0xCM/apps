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

            const byte PosIndex = 13;

            const byte FieldInex = 14;

            const byte DatKindIndex = 15;

            [MethodImpl(Inline)]
            public InstField(byte src)
                : this(0,src) {}

            public InstField(byte index, byte src)
            {
                var data = ByteBlock16.Empty;
                data.First = src;
                data[PosIndex] = index;
                data[DatKindIndex] = (byte)InstFieldKind.IntLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(byte index, uint5 src)
            {
                var data = ByteBlock16.Empty;
                data.First = src;
                data[PosIndex] = index;
                data[DatKindIndex] = (byte)InstFieldKind.BitLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(byte index, Hex8 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[PosIndex] = index;
                data[DatKindIndex] = (byte)InstFieldKind.HexLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(byte index, SegField src)
            {
                var data = ByteBlock16.Empty;
                core.@as<SegField>(data.First) = src;
                data[PosIndex] = index;
                data[FieldInex] = (byte)src.Field;
                data[DatKindIndex] = (byte)InstFieldKind.Seg;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(byte index, CellExpr src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[PosIndex] = index;
                data[FieldInex] = (byte)src.Field;
                data[DatKindIndex] = (byte)InstFieldKind.Expr;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstField(byte index, Nonterminal src)
            {
                var data = ByteBlock16.Empty;
                data = (uint)src;
                data[PosIndex] = index;
                data[DatKindIndex] = (byte)InstFieldKind.Nonterm;
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
                get => ref @as<InstFieldKind>(Data[DatKindIndex]);
            }

            public ref readonly FieldKind FieldKind
            {
                [MethodImpl(Inline)]
                get => ref @as<FieldKind>(Data[FieldInex]);
            }

            public InstFieldClass DataClass
            {
                get => XedPatterns.@class(DataKind);
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => DataKind == InstFieldKind.Nonterm;
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

            public ref readonly byte Index
            {
                [MethodImpl(Inline)]
                get => ref Data[PosIndex];
            }

            [MethodImpl(Inline)]
            public InstField WithIndex(byte index)
            {
                var dst = InstField.Empty;
                var data = Data;
                data[PosIndex] = index;
                return new InstField(data);
            }

            [MethodImpl(Inline)]
            public int CompareTo(InstField src)
                => Index.CompareTo(src.Index);

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
            public ref readonly CellExpr AsFieldExpr()
                => ref @as<CellExpr>(Data.First);

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