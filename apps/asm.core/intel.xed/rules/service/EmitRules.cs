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
            var lookup = CalcRuleCells(src);
            exec(PllExec,
                () => EmitSigs(src),
                () => EmitRuleSeq(),
                () => EmitCellDetail(lookup),
                () => EmitTableDefReport(src),
                () => EmitTableDefs(src)
            );
            Docs.EmitRuleDocs(src);
            return src;
        }

        void EmitSigs(RuleTables rules)
            => TableEmit(rules.SigRows.View, RuleSigRow.RenderWidths, XedPaths.Service.RuleTable<RuleSigRow>());

        void EmitRuleSeq()
        {
            var src = CellParser.ruleseq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }
   }
}