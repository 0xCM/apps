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
        public static PatternOpInfo opinfo(in PatternOp src)
        {
            var dst = PatternOpInfo.Empty;
            dst.Index = src.Index;
            dst.Kind = src.Kind;
            dst.Name = src.Name;

            ref readonly var attribs = ref src.Attribs;
            XedPatterns.nonterm(src, out dst.NonTerminal);
            XedPatterns.visibility(src, out dst.Visibility);
            XedPatterns.action(src, out dst.Action);
            XedPatterns.modifier(src, out dst.Modifier);
            XedPatterns.widthcode(src, out dst.WidthCode);

            if(GprWidth.widths(dst.NonTerminal, out var gpr))
                dst.GprWidth = gpr;

            if(src.RegLiteral(out dst.RegLit))
                dst.BitWidth = XedPatterns.bitwidth(dst.RegLit);

            if(XedPatterns.etype(src, out dst.CellType))
                dst.CellWidth = XedPatterns.bitwidth(dst.WidthCode, dst.CellType);

            return dst;
        }
    }
}