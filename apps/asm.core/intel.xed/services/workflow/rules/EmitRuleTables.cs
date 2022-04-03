//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;

    partial class XedRules
    {
        public void EmitRuleTables(RuleTables tables, Index<InstPattern> patterns)
        {
            EmitPatternOps(tables, patterns);

            exec(PllExec,
                () => EmitTableDefs(tables),
                () => EmitTableSigs(tables.SigInfo),
                () => EmitTableSchemas(tables.Schema),
                () => EmitRuleSeq(),
                () => EmitTableSpecs(tables),
                () => EmitTableFiles(tables)
            );
        }

       void EmitTableSchemas(Index<RuleSchema> src)
            => TableEmit(src.View, RuleSchema.RenderWidths, XedPaths.Service.RuleSchemas());

        void EmitTableDefs(RuleTables rules)
            => TableEmit(rules.DefRows().View, TableDefRow.RenderWidths, TextEncodingKind.Asci, XedPaths.RuleTable<TableDefRow>());

       void EmitTableSigs(Index<RuleSigRow> src)
            => TableEmit(src.View, RuleSigRow.RenderWidths, XedPaths.Service.RuleTable<RuleSigRow>());

        void EmitRuleSeq()
        {
            var src = XedRules.CalcRuleSeq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        void EmitTableSpecs(RuleTables tables)
        {
            exec(PllExec,
                () => EmitTableSpecs(tables, RuleTableKind.Enc),
                () => EmitTableSpecs(tables, RuleTableKind.Dec)
                );
        }

        public void EmitTableFiles(RuleTables tables)
        {
            exec(PllExec,
                () => EmitTableFiles(tables,RuleTableKind.Enc),
                () => EmitTableFiles(tables, RuleTableKind.Dec)
            );
        }

        void EmitTableFiles(RuleTables tables, RuleTableKind kind)
            => iter(tables.Specs[kind], spec => EmitTableFile(spec, XedPaths.Service.TableDef(spec.Sig)), false);

        void EmitTableSpecs(RuleTables tables, RuleTableKind kind)
        {
            var buffer = text.buffer();
            var specs = tables.Specs[kind];
            var path = XedPaths.RuleSpecs(kind);
            buffer.AppendLine(RuleCellRender.SpecHeader);
            RuleCellRender.render(specs, buffer);
            FileEmit(buffer.Emit(), specs.Count, XedPaths.RuleSpecs(kind), TextEncodingKind.Asci);
        }

        static void EmitTableFile(in RuleTableSpec spec, FS.FilePath dst)
        {
            var buffer = text.buffer();
            if(dst.Exists)
                dst = dst.ChangeExtension(FS.ext(string.Format("2.{0}", dst.Ext)));

            buffer.AppendLine(RuleCellRender.SpecHeader);
            RuleCellRender.render(spec, buffer);

            using var writer = dst.AsciWriter();
            writer.Append(buffer.Emit());
        }
    }
}