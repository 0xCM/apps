//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static InstOpClass opclass(in InstOpDetail src)
        {
            var info = XedWidths.describe(src.WidthCode);
            var bitwidth = XedWidths.width(src.Mode, src.WidthCode).Bits;
            var dst = InstOpClass.Empty;
            dst.Kind = src.Kind;
            dst.DataWidth = src.BitWidth;
            dst.WidthCode = src.WidthCode;
            dst.ElementType = src.ElementType;
            dst.CellCount = src.SegInfo.CellCount;
            dst.IsRegLit = src.IsRegLit;
            dst.IsLookup = src.IsNonterm;
            return dst;
        }
    }
}