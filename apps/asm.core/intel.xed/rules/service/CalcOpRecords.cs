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
        public static Index<PatternOpRow> CalcOpRecords(RuleTables tables, Index<InstPattern> patterns)
        {
            var details = CalcOpDetails(tables, patterns);
            var count = details.Count;
            var rows = alloc<PatternOpRow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref details[i];
                ref var dst = ref rows[i];
                dst.InstId = src.InstId;
                dst.PatternId = src.PatternId;
                dst.InstClass = src.InstClass.Classifier;
                dst.Lock = src.Lock;
                dst.Mode = src.Mode;
                dst.OpCode = src.OpCode;
                dst.Index = src.Index;
                dst.Name = src.Name;
                dst.Kind = src.Kind;
                dst.Action = src.Action;
                dst.WidthCode = src.WidthCode;
                dst.EType = src.EType;
                dst.EWidth = src.EWidth;
                dst.RegLit = src.RegLit;
                dst.Modifier = src.Modifier;
                dst.Visibility = src.Visibility;
                dst.NonTerminal = src.NonTerminal;
                dst.BitWidth = src.BitWidth;
                dst.SegInfo = src.SegInfo;
                dst.ECount = src.ECount;
                dst.SourceExpr = src.SourceExpr;
            }
            return rows;
            // var buffer = list<PatternOpRow>();
            // for(var i=0; i<src.Count; i++)
            // {
            //     ref readonly var pattern = ref src[i];
            //     ref readonly var ops = ref pattern.Ops;
            //     for(var j=0; j<ops.Count; j++)
            //     {
            //         var dst = PatternOpRow.Empty;
            //         ref readonly var op = ref ops[j];
            //         var info = describe(op);
            //         dst.InstId = pattern.InstId;
            //         dst.PatternId = pattern.PatternId;
            //         dst.InstClass = pattern.InstClass.Classifier;
            //         dst.Lock = XedFields.@lock(pattern.Fields);
            //         dst.Mode = pattern.Mode;
            //         dst.OpCode = pattern.OpCode;
            //         dst.Index = info.Index;
            //         dst.Name = info.Name;
            //         dst.Kind = info.Kind;
            //         dst.Action = info.Action;
            //         dst.WidthCode = info.WidthCode;
            //         dst.EType = info.CellType;
            //         dst.EWidth = info.CellWidth;
            //         dst.RegLit = info.RegLit;
            //         dst.Modifier = info.Modifier;
            //         dst.Visibility = info.Visibility;
            //         dst.NonTerminal = info.NonTerminal;
            //         if(info.WidthCode !=0)
            //         {
            //             dst.BitWidth = XedLookups.Service.Width(info.WidthCode, pattern.Mode).Bits;
            //             dst.SegInfo = XedLookups.Service.WidthInfo(info.WidthCode).Seg;
            //             dst.ECount = dst.SegInfo.CellCount;
            //         }

            //         dst.SourceExpr = op.SourceExpr;

            //         buffer.Add(dst);
            //     }
            // }

            // return buffer.ToArray().Sort();
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