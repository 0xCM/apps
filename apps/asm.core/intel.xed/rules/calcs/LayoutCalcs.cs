//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules.LayoutCellKind;

    using K = XedRules.RuleCellKind;

    partial class XedRules
    {
        public readonly struct LayoutCalcs
        {
            public static Index<InstLayout> layouts(Index<InstPattern> src)
            {
                var count = src.Count;
                var dst = alloc<InstLayout>(count);
                for(var i=0; i<src.Count; i++)
                    seek(dst,i) = layout(src[i]);
                return dst;
            }

            public static InstLayout layout(InstPattern src)
            {
                var dst = InstLayout.Empty;
                ref readonly var fields = ref src.Layout;
                dst.PatternId = (ushort)src.PatternId;
                dst.Instruction = src.InstClass;
                dst.OpCode = src.OpCode;
                dst.Count = Demand.lteq(fields.Count,InstLayout.CellCount);
                for(var j=z8; j<fields.Count; j++)
                    layout(j, fields[j], ref dst);
                return dst;
            }

            static void layout(byte index, InstField src, ref InstLayout dst)
            {
                switch(index)
                {
                    case 0:
                        dst.Cell0 = layout(src);
                    break;
                    case 1:
                        dst.Cell1 = layout(src);
                    break;
                    case 2:
                        dst.Cell2 = layout(src);
                    break;
                    case 3:
                        dst.Cell3 = layout(src);
                    break;
                    case 4:
                        dst.Cell4 = layout(src);
                    break;
                    case 5:
                        dst.Cell5 = layout(src);
                    break;
                    case 6:
                        dst.Cell6 = layout(src);
                    break;
                    case 7:
                        dst.Cell7 = layout(src);
                    break;
                    case 8:
                        dst.Cell8 = layout(src);
                    break;
                    case 9:
                        dst.Cell9 = layout(src);
                    break;
                    case 10:
                        dst.Cell10 = layout(src);
                    break;
                }
            }

            static LayoutCell layout(InstField src)
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
                        Errors.Throw(AppMsg.UnhandledCase.Format(src.CellKind));
                    break;

                }
                return new LayoutCell(dst);
            }
        }
    }
}