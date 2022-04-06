//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedFields;

    partial class XedRules
    {
        public struct InstDefField : IEquatable<InstDefField>
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public InstDefField(byte src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[15] = (byte)DefFieldClass.IntLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(uint5 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)src;
                data[1] = uint5.MaxLiteral;
                data[15] = (byte)DefFieldClass.BitLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(Hex8 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[15] = (byte)DefFieldClass.HexLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(BfSeg src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.Bitfield;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(CellExpr src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.FieldExpr;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(Nonterminal src)
            {
                var data = ByteBlock16.Empty;
                data = (uint)src;
                data[15] = (byte)DefFieldClass.Nonterm;
                Data = data;
            }

            internal ref readonly byte this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            internal ref readonly byte this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref readonly DefFieldClass FieldClass
            {
                [MethodImpl(Inline)]
                get => ref @as<DefFieldClass>(Data[15]);
            }

            public ref readonly FieldKind FieldKind
            {
                [MethodImpl(Inline)]
                get => ref @as<FieldKind>(Data[14]);
            }

            public bool IsBitfield
            {
                [MethodImpl(Inline)]
                get => FieldClass == DefFieldClass.Bitfield;
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => FieldClass == DefFieldClass.Nonterm;
            }

            public bool IsFieldExpr
            {
                [MethodImpl(Inline)]
                get => FieldClass == DefFieldClass.FieldExpr;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get =>
                   FieldClass == DefFieldClass.BitLiteral
                || FieldClass == DefFieldClass.HexLiteral
                || FieldClass == DefFieldClass.IntLiteral;
            }

            [MethodImpl(Inline)]
            public bool Equals(InstDefField src)
                => Data.Equals(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is InstDefField p && Equals(p);

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
            public ref readonly BfSeg AsBitfield()
                => ref @as<BfSeg>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly uint5 AsBitLit()
                => ref @as<uint5>(Data.First);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static InstDefField Empty => default;
        }
    }
}