//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public static Index<PatternOpDetail> opdetails(InstPattern src)
        {
            ref readonly var ops = ref src.Ops;
            var dst = alloc<PatternOpDetail>(ops.Count);
            for(var j=0; j<ops.Count; j++)
                seek(dst,j) = opdetail(src, ops[j]);
            return dst;
        }

        public static PatternOpDetail opdetail(InstPattern pattern, in PatternOp op)
        {
            var lookups = XedLookups.Service;
            ref readonly var fields = ref pattern.Fields;
            var info = opinfo(op);
            var dst = PatternOpDetail.Empty;
            dst.InstId = pattern.InstId;
            dst.PatternId = op.PatternId;
            dst.InstClass = pattern.InstClass.Classifier;
            dst.Lock = XedFields.@lock(fields);
            dst.Mode = pattern.Mode;
            dst.OpCode = pattern.OpCode;
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
                dst.BitWidth = lookups.Width(info.WidthCode, pattern.Mode).Bits;
                dst.SegInfo = lookups.WidthInfo(info.WidthCode).Seg;
                dst.ECount = dst.SegInfo.CellCount;
            }
            var expr = op.SourceExpr.Value;
            Demand.lteq(op.SourceExpr.Format().Length,32);
            dst.SourceExpr = op.SourceExpr.Value;
            return dst;
        }
    }
}