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
        public RuleTables EmitRules(RuleTables src)
        {
            exec(PllExec,
                () => Emit(src.SigRows),
                () => EmitCellDetail(CalcRuleCells(src)),
                () => EmitTableDefReport(src),
                () => Emit(CellParser.ruleseq()),
                () => Docs.EmitRuleDocs(src),
                () => EmitTableDefs(src)
            );
            return src;
        }

        public void Emit(Index<RuleSigRow> src)
            => TableEmit(src.View, RuleSigRow.RenderWidths, XedPaths.Service.RuleTable<RuleSigRow>());

        public void Emit(Index<RuleSeq> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }
   }
}