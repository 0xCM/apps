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
        public struct InstDefPart : IEquatable<InstDefPart>
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public InstDefPart(Hex8 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[15] = (byte)DefFieldClass.HexLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(byte src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[15] = (byte)DefFieldClass.IntLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(BitfieldSeg src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.Bitfield;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(FieldAssign src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.FieldAssign;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(FieldExpr src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.FieldExpr;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(FieldConstraint src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.Constraint;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(Nonterminal src)
            {
                var data = ByteBlock16.Empty;
                data = core.bytes(src);
                data[15] = (byte)DefFieldClass.Nonterm;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(uint5 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)src;
                data[1] = uint5.MaxLiteral;
                data[15] = (byte)DefFieldClass.BitLiteral;
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

            public bool IsConstraint
            {
                [MethodImpl(Inline)]
                get => FieldClass == DefFieldClass.Constraint;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => FieldClass == DefFieldClass.BitLiteral
                || FieldClass == DefFieldClass.HexLiteral
                || FieldClass == DefFieldClass.IntLiteral
                || FieldClass == DefFieldClass.IntLiteral;
            }

            public bool IsBitfield
            {
                [MethodImpl(Inline)]
                get => FieldClass == DefFieldClass.BitLiteral;
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => FieldClass == DefFieldClass.Nonterm;
            }

            public bool HasKind
            {
                [MethodImpl(Inline)]
                get => FieldKind != 0;
            }

            public ref readonly FieldKind FieldKind
            {
                [MethodImpl(Inline)]
                get => ref @as<FieldKind>(Data[14]);
            }

            [MethodImpl(Inline)]
            public bool Equals(InstDefPart src)
                => Data.Equals(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is InstDefPart p && Equals(p);

            [MethodImpl(Inline)]
            public ref readonly FieldAssign AsAssignment()
                => ref @as<FieldAssign>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly FieldValue AsFieldLit()
                => ref @as<FieldValue>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Hex8 AsHexLit()
                => ref @as<Hex8>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly byte AsIntLit()
                => ref @as<byte>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly FieldConstraint AsConstraint()
                => ref @as<FieldConstraint>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Nonterminal AsNonterminal()
                => ref @as<Nonterminal>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly FieldExpr AsFieldExpr()
                => ref @as<FieldExpr>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly BitfieldSeg AsBitfield()
                => ref @as<BitfieldSeg>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly uint5 AsBitLit()
                => ref @as<uint5>(Data.First);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static InstDefPart Empty => default;
        }
    }
}