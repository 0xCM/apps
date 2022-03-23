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
        public struct InstDefField : IEquatable<InstDefField>
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public InstDefField(Hex8 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[15] = (byte)DefFieldClass.HexLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(byte src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[15] = (byte)DefFieldClass.IntLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(BitfieldSeg src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.Bitfield;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(FieldAssign src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.FieldAssign;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(FieldConstraint src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.Constraint;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefField(Nonterminal src)
            {
                var data = ByteBlock16.Empty;
                data = core.bytes(src);
                data[15] = (byte)DefFieldClass.Nonterm;
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
            public InstDefField(FieldValue src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefFieldClass.FieldLiteral;
                Data = data;
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

            [MethodImpl(Inline)]
            public bool Equals(InstDefField src)
                => Data.Equals(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is InstDefField p && Equals(p);

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
            public ref readonly BitfieldSeg AsBfSeg()
                => ref @as<BitfieldSeg>(Data.First);

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