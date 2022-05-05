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
            public static InstLayouts layouts(Index<InstPattern> src)
            {
                var count = src.Count;
                var blocks = LayoutCalcs.blocks(count);
                var size = InstLayoutBlock.Size;
                Index<InstLayout> dst = alloc<InstLayout>(count);
                var layouts = new InstLayouts(dst, blocks);
                for(var i=0; i<count; i++)
                {
                    var segref = new SegRef<LayoutCell>(blocks[i].Location, size);
                    layout(src[i], segref, out dst[i]);
                    layouts.Record(i) = record(dst[i]);
                }
                return layouts;
            }

            public static void layout(InstPattern src, SegRef<LayoutCell> block, out InstLayout dst)
            {
                ref readonly var fields = ref src.Layout;
                var count = Demand.lteq(fields.Count, InstLayoutRecord.CellCount);
                dst = new InstLayout((ushort)src.PatternId, src.InstClass, src.OpCode, count, block);
                for(var j=z8; j<fields.Count; j++)
                    dst[j] = layout(fields[j]);
            }

            public static InstLayoutRecord record(in InstLayout src)
            {
                var dst = InstLayoutRecord.Empty;
                dst.PatternId = (ushort)src.PatternId;
                dst.Instruction = src.Instruction;
                dst.OpCode = src.OpCode;
                dst.Count = Demand.lteq(src.Count, InstLayoutRecord.CellCount);
                for(var j=z8; j<src.Count; j++)
                {
                    assign(j, src[j], ref dst);
                }
                return dst;
            }

            public static NativeCells<InstLayoutBlock> blocks(uint count)
                => NativeCells.alloc<InstLayoutBlock>(count, out var id);

            static void assign(byte index, in LayoutCell src, ref InstLayoutRecord dst)
            {
                switch(index)
                {
                    case 0:
                        dst.Cell0 = src;
                    break;
                    case 1:
                        dst.Cell1 = src;
                    break;
                    case 2:
                        dst.Cell2 = src;
                    break;
                    case 3:
                        dst.Cell3 = src;
                    break;
                    case 4:
                        dst.Cell4 = src;
                    break;
                    case 5:
                        dst.Cell5 = src;
                    break;
                    case 6:
                        dst.Cell6 = src;
                    break;
                    case 7:
                        dst.Cell7 = src;
                    break;
                    case 8:
                        dst.Cell8 = src;
                    break;
                    case 9:
                        dst.Cell9 = src;
                    break;
                    case 10:
                        dst.Cell10 = src;
                    break;
                }
            }

            static LayoutCell layout(CellValue src)
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
                            @as<FieldSeg>(dst.First) = FieldSeg.literal(iseg.Field, iseg.ToLiteral());
                        else
                            @as<FieldSeg>(dst.First) = FieldSeg.symbolic(iseg.Field, InstSegTypes.pattern(iseg.Type));
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