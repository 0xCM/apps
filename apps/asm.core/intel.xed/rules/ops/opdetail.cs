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
            var info = opinfo(pattern.Mode,op);
            var wcode = info.WidthCode;
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
            dst.WidthCode = wcode;
            dst.GrpWidth = info.GprWidth;
            dst.ElementType = info.CellType;
            dst.ElementWidth = info.CellWidth;
            dst.RegLit = info.RegLit;
            dst.Modifier = info.Modifier;
            dst.Visibility = info.Visibility;
            dst.NonTerminal = info.NonTerminal;
            dst.BitWidth = info.BitWidth;
            if(wcode !=0)
            {
                var w = lookups.Width(wcode, pattern.Mode);
                var wi = lookups.WidthInfo(wcode);
                dst.SegInfo = wi.Seg;
                dst.ElementCount = dst.SegInfo.CellCount;
            }
            if(info.RegLit.IsNonEmpty && dst.BitWidth == 0)
            {
                var regop = XedRegMap.map(info.RegLit);
                if(regop.IsNonEmpty)
                    dst.BitWidth = (ushort)regop.Size.Width;
            }

            var expr = op.SourceExpr.Value;
            Demand.lteq(op.SourceExpr.Format().Length,32);
            dst.SourceExpr = op.SourceExpr.Value;
            return dst;
        }
    }
}