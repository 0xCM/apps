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
        public static Index<InstOpDetail> opdetails(InstPattern src)
        {
            ref readonly var ops = ref src.Ops;
            var count = (byte)ops.Count;
            var dst = alloc<InstOpDetail>(count);
            for(var j=0; j<count; j++)
                seek(dst,j) = opdetail(src, count, ops[j]);
            return dst;
        }

        public static InstOpDetail opdetail(InstPattern pattern, byte opcount, in PatternOp op)
        {
            ref readonly var fields = ref pattern.Fields;
            var info = opinfo(pattern.Mode,op);
            var wcode = info.WidthCode;
            var dst = InstOpDetail.Empty;
            dst.PatternId = op.PatternId;
            Require.nonzero(pattern.InstClass.Kind);
            dst.InstClass = pattern.InstClass;
            dst.OpCode = pattern.OpCode;
            dst.Mode = pattern.Mode;
            dst.Lock = XedFields.@lock(fields);
            dst.Mod = XedFields.mod(fields);
            dst.RexW = XedFields.rexw(fields);
            dst.Rep = XedFields.rep(fields);
            dst.Attribs = op.Attribs;
            dst.OpCount = opcount;
            dst.Index = info.Index;
            dst.Name = info.Name;
            dst.Kind = info.Kind;
            dst.Action = info.Action;
            dst.WidthCode = wcode;
            dst.GrpWidth = info.GprWidth;
            dst.Scalable = info.GprWidth.IsScalable;
            dst.ElementType = info.CellType;
            dst.ElementWidth = info.CellWidth;
            dst.RegLit = info.RegLit;
            dst.Modifier = info.Modifier;
            dst.Visibility = info.Visibility;
            dst.NonTerm = info.NonTerminal;
            dst.BitWidth = info.BitWidth;
            if(wcode !=0)
            {
                var w = XedWidths.width(pattern.Mode,wcode);
                var wi = XedWidths.describe(wcode);
                dst.SegInfo = wi.SegType;
                dst.ElementCount = dst.SegInfo.CellCount;
            }
            if(info.RegLit.IsNonEmpty && dst.BitWidth == 0)
            {
                var regop = XedRegMap.map(info.RegLit);
                if(regop.IsNonEmpty)
                    dst.BitWidth = (ushort)regop.Size.Width;
            }

            var expr = op.SourceExpr.Value;
            var exprFmt = op.SourceExpr.Format();
            Demand.lteq(text.squote(exprFmt), exprFmt.Length, asci64.Size);
            dst.SourceExpr = expr;
            return dst;
        }
    }
}