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
        public struct InstDefPart : IEquatable<InstDefPart>
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public InstDefPart(Hex8 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[15] = (byte)DefSegKind.HexLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(byte src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[15] = (byte)DefSegKind.IntLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(BitfieldSeg src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[15] = (byte)DefSegKind.Bitfield;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(FieldAssign src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[15] = (byte)DefSegKind.FieldAssign;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(FieldConstraint src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[15] = (byte)DefSegKind.Constraint;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(Nonterminal src)
            {
                var data = ByteBlock16.Empty;
                data = core.bytes(src);
                data[15] = (byte)DefSegKind.Nonterm;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(uint5 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)src;
                data[1] = uint5.MaxLiteral;
                data[15] = (byte)DefSegKind.BitLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(FieldValue src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[15] = (byte)DefSegKind.FieldLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public bool Equals(InstDefPart src)
                => Data.Equals(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is InstDefPart p && Equals(p);

            public ref readonly DefSegKind PartKind
            {
                [MethodImpl(Inline)]
                get => ref @as<DefSegKind>(Data[15]);
            }

            [MethodImpl(Inline)]
            public ref readonly FieldAssign AsAssign()
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
            public ref readonly uint5 AsB5()
                => ref @as<uint5>(Data.First);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static InstDefPart Empty => default;
        }
    }
}