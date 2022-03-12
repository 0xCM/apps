//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

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
                data[15] = (byte)DefSegKind.Hex8;
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

            public ref readonly DefSegKind Kind
            {
                [MethodImpl(Inline)]
                get => ref @as<DefSegKind>(Data[15]);
            }

            [MethodImpl(Inline)]
            public ref readonly Hex8 AsHex8()
                => ref @as<Hex8>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly BitfieldSeg AsBitfield()
                => ref @as<BitfieldSeg>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly FieldAssign AsAssign()
                => ref @as<FieldAssign>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly FieldConstraint AsConstraint()
                => ref @as<FieldConstraint>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly NontermCall AsNonterm()
                => ref @as<NontermCall>(Data.First);

            public T Map<S,T>(DefSegKind kind, Func<S,T> f)
            {
                var dst = default(T);
                switch(kind)
                {
                    case DefSegKind.Assign:
                        dst = f(@as<InstDefSeg,S>(AsAssign()));
                    break;
                    case DefSegKind.Bitfield:
                        dst = f(@as<InstDefSeg,S>(AsBitfield()));
                    break;
                    case DefSegKind.Constraint:
                        dst = f(@as<InstDefSeg,S>(AsConstraint()));
                    break;
                    case DefSegKind.Hex8:
                        dst = f(@as<InstDefSeg,S>(AsHex8()));
                    break;
                    case DefSegKind.Nonterm:
                        dst = f(@as<InstDefSeg,S>(AsNonterm()));
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

            public static InstDefSeg Empty => default;
        }
    }
}