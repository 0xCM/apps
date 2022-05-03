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
        public static InstOpClass opclass(in InstOpDetail src)
        {
            var info = describe(src.WidthCode);
            var bitwidth = width(src.Mode, src.WidthCode).Bits;
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