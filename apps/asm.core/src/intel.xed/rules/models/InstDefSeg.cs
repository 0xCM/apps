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
        public struct InstDefSeg
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            public InstDefSeg(Hex8 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src;
                data[15] = (byte)DefSegKind.HexLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefSeg(BitfieldSeg src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[15] = (byte)DefSegKind.Bitfield;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefSeg(FieldAssign src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[15] = (byte)DefSegKind.Assign;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefSeg(FieldConstraint src)
            {
                var data = ByteBlock16.Empty;
                data = bytes(src);
                data[15] = (byte)DefSegKind.Constraint;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefSeg(NontermCall src)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)src.Kind;
                data[15] = (byte)DefSegKind.Nonterm;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefSeg(uint5 src)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)src;
                data[1] = uint5.MaxLiteral;
                data[15] = (byte)DefSegKind.BitLiteral;
                Data = data;
            }

            [MethodImpl(Inline)]
            public InstDefSeg(BitNumber src)
            {
                var data = ByteBlock16.Empty;
                data[0] = src.Val8;
                data[1] = src.Width;
                data[15] = (byte)DefSegKind.BitLiteral;
                Data = data;
            }

            public ref readonly DefSegKind Kind
            {
                [MethodImpl(Inline)]
                get => ref @as<DefSegKind>(Data[15]);
            }

            public T Map<S,T>(DefSegKind kind, Func<S,T> f)
            {
                var dst = default(T);
                switch(kind)
                {
                    case DefSegKind.Assign:
                        dst = f(@as<InstDefSeg,S>(@as<FieldAssign>(Data.First)));
                    break;
                    case DefSegKind.Bitfield:
                        dst = f(@as<InstDefSeg,S>(@as<BitfieldSeg>(Data.First)));
                    break;
                    case DefSegKind.Constraint:
                        dst = f(@as<InstDefSeg,S>(@as<FieldConstraint>(Data.First)));
                    break;
                    case DefSegKind.HexLiteral:
                        dst = f(@as<InstDefSeg,S>(@as<Hex8>(Data.First)));
                    break;
                    case DefSegKind.BitLiteral:
                        dst = f(@as<InstDefSeg,S>(@as<uint5>(Data.First)));
                    break;
                    case DefSegKind.Nonterm:
                        dst = f(@as<InstDefSeg,S>(@as<NontermCall>(Data.First)));
                    break;
                }
                return dst;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstDefSeg(Hex8 src)
                => new InstDefSeg(src);

            // [MethodImpl(Inline)]
            // public static implicit operator InstDefSeg(uint8b src)
            //     => new InstDefSeg(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefSeg(uint5 src)
                => new InstDefSeg(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefSeg(BitfieldSeg src)
                => new InstDefSeg(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefSeg(FieldAssign src)
                => new InstDefSeg(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefSeg(FieldConstraint src)
                => new InstDefSeg(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefSeg(NontermCall src)
                => new InstDefSeg(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefSeg(BitNumber src)
                => new InstDefSeg(src);

            public static InstDefSeg Empty => default;
        }
    }
}