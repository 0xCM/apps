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
        public Index<InstOperandRow> CalcInstOps()
            => CalcInstOpRows(CalcInstOpDetails());

        public Index<InstOpDetail> CalcInstOpDetails()
            => CalcInstOpDetails(CalcRules(), CalcInstPatterns());

        public Index<InstOpDetail> CalcInstOpDetails(RuleTables tables, Index<InstPattern> patterns)
            => Data(nameof(CalcInstOpDetails), () => opdetails(tables,patterns));

        public Index<InstOperandRow> CalcInstOpRows(Index<InstOpDetail> details)
        {
            return Data(nameof(CalcInstOpRows),Calc);

            Index<InstOperandRow> Calc()
            {
                var count = details.Count;
                var rows = alloc<InstOperandRow>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var src = ref details[i];
                    ref var dst = ref rows[i];
                    dst.PatternId = src.PatternId;
                    dst.InstClass = src.InstClass.Classifier;
                    dst.OpCode = src.OpCode;
                    dst.Mode = src.Mode;
                    dst.Lock = src.Lock;
                    dst.Mod = src.Mod;
                    dst.RexW = src.RexW;
                    dst.OpCount = src.OpCount;
                    dst.Index = src.Index;
                    dst.Name = src.Name;
                    dst.Kind = src.Kind;
                    dst.Action = src.Action;
                    dst.WidthCode = src.WidthCode;
                    dst.EType = src.ElementType;
                    dst.EWidth = src.ElementWidth;
                    dst.RegLit = src.RegLit;
                    dst.Modifier = src.Modifier;
                    dst.Visibility = src.Visibility;
                    dst.NonTerminal = src.NonTerm;
                    dst.BitWidth = src.BitWidth;
                    dst.GprWidth = src.GrpWidth;
                    dst.SegInfo = src.SegInfo;
                    dst.ECount = src.ElementCount;
                    dst.SourceExpr = src.SourceExpr;
                }
                return rows;
            }
        }
    }
}