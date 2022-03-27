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
        public void EmitRuleTables()
        {
            XedPaths.Service.RuleTargets().Delete();
            var tables = CalcTableSet(PllExec);
            exec(PllExec,
                () => EmitTableDefs(tables),
                () => EmitRuleSigs(tables.SigInfo),
                () => EmitSchemas(tables.Schema),
                () => EmitRuleSeq(),
                () => EmitTableFiles(tables),
                () => EmitTableSpecs(tables)
            );
        }

        void EmitTableDefs(RuleTableSet tables)
        {
            exec(PllExec,
                () => EmitTableDefs(RuleTableKind.Enc, tables),
                () => EmitTableDefs(RuleTableKind.Dec, tables),
                () => EmitTableDefs(RuleTableKind.EncDec, tables)
                );

            EmitTableDefs(tables.Rows(), XedPaths.RuleTable<RuleTableRow>());
        }

        void EmitRuleSeq()
        {
            var src = XedRules.CalcRuleSeq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        void EmitRuleSigs(Index<RuleSigRow> src)
            => TableEmit(src.View, RuleSigRow.RenderWidths, XedPaths.Service.RuleTable<RuleSigRow>());

        void EmitSchemas(Index<RuleSchema> src)
            => TableEmit(src.View, RuleSchema.RenderWidths, XedPaths.Service.RuleSchemas());
    }
}