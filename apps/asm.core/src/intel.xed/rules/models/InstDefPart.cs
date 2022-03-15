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
        public struct InstDefPart
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
            public InstDefPart(BitfieldSeg src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefSegKind.Bitfield;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(FieldAssign src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefSegKind.FieldAssign;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(FieldConstraint src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefSegKind.Constraint;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(Nonterminal src)
            {
                var data = ByteBlock16.Empty;
                @as<ushort>(data.First) = (ushort)src;
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
            public InstDefPart(BitNumber src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src.Val8;
                data[1] = src.Width;
                data[15] = (byte)DefSegKind.BitLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefPart(FieldValue src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[14] = (byte)src.Field;
                data[15] = (byte)DefSegKind.FieldLiteral;
                Data = data;
            }

            public ref readonly DefSegKind PartKind
            {
                [MethodImpl(Inline)]
                get => ref @as<DefSegKind>(Data[15]);
            }

            public ref readonly FieldKind Field
            {
                [MethodImpl(Inline)]
                get => ref @as<FieldKind>(Data[14]);
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

            public T Map<S,T>(DefSegKind kind, Func<S,T> f)
            {
                var dst = default(T);
                switch(kind)
                {
                    case DefSegKind.FieldAssign:
                        dst = f(@as<InstDefPart,S>(AsAssign()));
                    break;
                    case DefSegKind.Bitfield:
                        dst = f(@as<InstDefPart,S>(@as<BitfieldSeg>(Data.First)));
                    break;
                    case DefSegKind.Constraint:
                        dst = f(@as<InstDefPart,S>(@as<FieldConstraint>(Data.First)));
                    break;
                    case DefSegKind.HexLiteral:
                        dst = f(@as<InstDefPart,S>(AsHexLit()));
                    break;
                    case DefSegKind.BitLiteral:
                        dst = f(@as<InstDefPart,S>(@as<uint5>(Data.First)));
                    break;
                    case DefSegKind.Nonterm:
                        dst = f(@as<InstDefPart,S>(@as<Nonterminal>(Data.First)));
                    break;
                    case DefSegKind.FieldLiteral:
                        dst = f(@as<InstDefPart,S>(AsFieldLit()));
                    break;
                }
                return dst;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstDefPart(Hex8 src)
                => new InstDefPart(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefPart(uint5 src)
                => new InstDefPart(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefPart(BitfieldSeg src)
                => new InstDefPart(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefPart(FieldAssign src)
                => new InstDefPart(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefPart(FieldConstraint src)
                => new InstDefPart(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefPart(Nonterminal src)
                => new InstDefPart(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefPart(BitNumber src)
                => new InstDefPart(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefPart(FieldValue src)
                => new InstDefPart(src);

            public static InstDefPart Empty => default;
        }
    }
}