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
        public static Index<PatternOpDetail> CalcOpDetails(RuleTables tables, Index<InstPattern> src)
        {
            var count = src.Map(x => (uint)x.OpCount).Storage.Sum();
            var buffer = list<PatternOpDetail>(count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    var dst = PatternOpDetail.Empty;
                    ref readonly var op = ref ops[j];
                    var info = describe(op);
                    dst.InstId = pattern.InstId;
                    dst.PatternId = pattern.PatternId;
                    dst.InstClass = pattern.InstClass.Classifier;
                    dst.Lock = XedFields.@lock(pattern.Fields);
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
                    dst.SourceExpr = op.SourceExpr.Value;
                    if(info.WidthCode !=0)
                    {
                        dst.BitWidth = XedLookups.Service.Width(info.WidthCode, pattern.Mode).Bits;
                        dst.SegInfo = XedLookups.Service.WidthInfo(info.WidthCode).Seg;
                        dst.ECount = dst.SegInfo.CellCount;
                    }
                    buffer.Add(dst);
                }
            }

            return buffer.ToArray().Sort();
        }
    }
}