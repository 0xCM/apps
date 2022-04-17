//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public static PatternOpInfo opinfo(MachineMode mode, in PatternOp src)
        {
            var dst = PatternOpInfo.Empty;
            dst.Index = src.Index;
            dst.Kind = src.Kind;
            dst.Name = src.Name;
            var wc = OpWidthCode.INVALID;
            ref readonly var attribs = ref src.Attribs;
            XedPatterns.nonterm(src, out dst.NonTerminal);
            XedPatterns.visibility(src, out dst.Visibility);
            XedPatterns.action(src, out dst.Action);
            XedPatterns.modifier(src, out dst.Modifier);
            if(XedPatterns.widthcode(src, out wc))
            {
                dst.WidthCode = wc;
                var w = XedWidths.width(wc, mode);
                dst.BitWidth = w.Bits;
                var wi = XedWidths.describe(wc);
                dst.SegType = wi.Seg;
                dst.CellType = wi.CellType;
                dst.CellWidth = wi.CellWidth;
            }

            var gpr = GprWidth.Empty;
            if(GprWidth.widths(dst.NonTerminal, out gpr))
                dst.GprWidth = gpr;
            else
                dst.GprWidth = GprWidth.Empty;

            if(src.RegLiteral(out dst.RegLit))
                dst.BitWidth = XedPatterns.bitwidth(dst.RegLit);

            if(dst.BitWidth == 0 && gpr.IsNonEmpty && gpr.IsInvariant)
                dst.BitWidth = (ushort)gpr.InvariantWidth.Width;

            return dst;
        }
    }
}