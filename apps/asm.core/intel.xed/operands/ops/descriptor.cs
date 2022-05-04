//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    public partial class XedOperands
    {
        public static string descriptor(MachineMode mode, in PatternOp src)
        {
            const string RenderPattern = "{0,-6} {1,-3} {2,-10} {3,-12}";
            src.ElementType(out var et);
            src.WidthCode(out var w);
            var bw = XedOperands.width(mode,w).Bits;
            var wi = describe(w);
            if(XedOperands.reglit(src, out Register reg))
                bw = XedOperands.width(reg);

            var seg = EmptyString;
            if(wi.SegType.CellCount > 1)
            {
                var indicator = EmptyString;
                if(et.Indicator != 0)
                    indicator = ((char)et.Indicator).ToString();
                seg = string.Format("{0}x{1}{2}x{3}n", wi.SegType.DataWidth, wi.SegType.CellWidth, indicator, wi.SegType.CellCount);
            }

            var _bw = bw.ToString();
            if(src.Nonterminal(out var nt))
            {
                if(GprWidth.widths(nt, out var gpr))
                    _bw = gpr.Format();
            }

            return string.Format(RenderPattern, XedRender.format(w), et, _bw, seg);
        }
    }
}