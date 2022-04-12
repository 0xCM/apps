//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public static Index<PatternOpRow> CalcOpRecords(RuleTables tables, Index<InstPattern> patterns)
        {
            var details = opdetails(tables, patterns);
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
        }
    }
}