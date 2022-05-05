//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedOperands
    {
        public static InstOpClass opclass(MachineMode mode, in OpSpec spec)
        {
            var desc = describe(spec.WidthCode);
            var width = XedOperands.width(mode, spec.WidthCode);
            var dst =  new InstOpClass {
                        Kind = spec.Kind,
                        BitWidth = width.Bits,
                        ElementType = desc.ElementType,
                        IsRegLit = IsRegLit(spec.OpType),
                        IsRule = IsRule(spec.OpType),
                        ElementCount = desc.CellCount,
                        OpWidth = new OpWidth(spec.WidthCode, width.Bits)
                    };

            return dst;
        }

        public static InstOpClass opclass(in InstOpDetail src)
        {
            var dst = InstOpClass.Empty;
            dst.Kind = src.Kind;
            dst.BitWidth = src.BitWidth;
            dst.ElementType = src.ElementType;
            dst.ElementCount = src.SegInfo.CellCount;
            dst.IsRegLit = src.IsRegLit;
            dst.IsRule = src.IsNonterm;
            dst.OpWidth = new OpWidth(src.WidthCode, src.BitWidth);
            return dst;
        }
    }
}