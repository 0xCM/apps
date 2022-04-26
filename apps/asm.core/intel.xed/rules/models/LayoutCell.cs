//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = XedRules.RuleCellKind;
    using static XedRules.LayoutCellKind;

    partial class XedRules
    {
        public enum LayoutCellKind : byte
        {
            None,

            BL = K.BitLiteral,

            XL = K.HexLiteral,

            SV = K.SegVar,

            SF = K.SegField,

            NT = K.NontermCall,
        }

        public readonly record struct LayoutCell
        {
            public static LayoutCell from(InstField src)
            {
                var dst = ByteBlock16.Empty;
                switch(src.CellKind)
                {
                    case K.BitLiteral:
                        dst[0] = src.AsBitLit();
                        dst[15] = (byte)BL;
                    break;
                    case K.HexLiteral:
                        dst[0] = src.AsHexLit();
                        dst[15] = (byte)XL;
                    break;
                    case K.InstSeg:
                    {
                        var iseg = src.AsInstSeg();
                        if(iseg.IsLiteral)
                            @as<SegField>(dst.First) = SegField.literal(iseg.Field, iseg._ToLiteral());
                        else
                            @as<SegField>(dst.First) = SegField.symbolic(iseg.Field, InstSegTypes.pattern(iseg.Type));
                        dst[15] = (byte)SF;
                    }
                    break;
                    case K.NontermCall:
                        @as<Nonterminal>(dst.First) = src.AsNonterm();
                        dst[15] = (byte)NT;
                    break;
                    default:
                        Errors.Throw($"The field type {src.CellKind} is not supported");
                    break;

                }
                return new LayoutCell(dst);
            }

            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            LayoutCell(ByteBlock16 data)
            {
                Data = data;
            }

            [MethodImpl(Inline)]
            public ref readonly Hex8 AsHexLit()
                => ref @as<Hex8>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly uint5 AsBitLit()
                => ref @as<uint5>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly SegField AsSegField()
                => ref @as<SegField>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Nonterminal AsNonterm()
                => ref @as<Nonterminal>(Data.First);

            public ref readonly LayoutCellKind Kind
            {
                [MethodImpl(Inline)]
                get => ref @as<LayoutCellKind>(Data[15]);
            }

            public string Format()
            {
                var dst = EmptyString;
                switch(Kind)
                {
                    case BL:
                        dst = AsBitLit().Format();
                    break;
                    case XL:
                        dst = AsHexLit().Format();
                    break;
                    case SF:
                        dst = AsSegField().Format();
                    break;
                    case NT:
                        dst = AsNonterm().Format();
                    break;
                }
                return dst;
            }


            public override string ToString()
                => Format();
        }
    }
}