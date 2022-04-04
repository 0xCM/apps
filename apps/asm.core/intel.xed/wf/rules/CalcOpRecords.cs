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
        public static Index<PatternOpRow> CalcOpRecords(RuleTables tables, Index<InstPattern> src)
        {
            var buffer = list<PatternOpRow>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    var dst = PatternOpRow.Empty;
                    ref readonly var op = ref ops[j];
                    var info = describe(op);
                    dst.InstId = pattern.InstId;
                    dst.PatternId = pattern.PatternId;
                    dst.InstClass = pattern.InstClass;
                    dst.Mode = pattern.Mode;
                    dst.OcKind = pattern.OpCode.Kind;
                    dst.OcValue = pattern.OpCode.Value;
                    dst.Index = info.Index;
                    dst.Name = info.Name;
                    dst.Kind = info.Kind;
                    dst.Action = info.Action;
                    dst.WidthCode = info.WidthCode;
                    dst.EType = info.CellType;
                    dst.EWidth = info.CellWidth;
                    dst.RegLit = info.RegLit;
                    dst.Modifier = info.Modifier;
                    dst.Visibility = info.Visibility;
                    dst.NonTerminal = info.NonTerminal;
                    if(info.WidthCode !=0)
                    {
                        dst.BitWidth = XedLookups.Data.Width(info.WidthCode, pattern.Mode).Bits;
                        dst.SegType = XedLookups.Data.WidthInfo(info.WidthCode).Seg;
                        dst.ECount = dst.SegType.CellCount;
                    }

                    dst.SourceExpr = op.SourceExpr;

                    buffer.Add(dst);
                }
            }

            return buffer.ToArray().Sort();
        }

        public static PatternOpInfo describe(in PatternOp src)
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