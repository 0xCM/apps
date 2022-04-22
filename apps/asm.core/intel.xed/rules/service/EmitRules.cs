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
        public void EmitRuleCells(RuleTables rules)
        {
            var dst = text.emitter();
            CellEmitter.emit(rules,dst);
            FileEmit(dst.Emit(), 1, XedPaths.RuleTargets() + FS.file("xed.rules.cells", FS.Csv), TextEncodingKind.Asci);
        }

        void EmitTableSigs(RuleTables rules)
            => TableEmit(rules.SigRows.View, RuleSigRow.RenderWidths, XedPaths.Service.RuleTable<RuleSigRow>());

        void EmitRuleSeq()
        {
            var src = TableCalcs.ruleseq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        void EmitRuleCriteria(RuleTables rules)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            ref readonly var tables = ref rules.Criteria();
            var dst = XedPaths.RuleSpecs();
            using var writer = dst.AsciWriter();
            writer.AppendLine(formatter.FormatHeader());
            var k=0u;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref tables[i];
                if(table.IsNonEmpty)
                {
                    writer.AppendLine();
                    for(var j=0u; j<table.RowCount; j++, k++)
                    {
                        ref readonly var spec = ref table[j];
                        var row = TableDefRow.Empty;
                        row.Seq = k;
                        row.TableId = table.TableId;
                        row.Index = j;
                        row.Kind = table.TableKind;
                        row.Name = table.TableName;
                        row.Statement = spec.Format();
                        writer.AppendLine(formatter.Format(row));
                    }
                    writer.AppendLine();
                    writer.AppendLine();
                    lines(table,writer);
                    writer.AppendLine();
                }
            }
        }

        public void EmitRuleTables(RuleTables rules)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            ref readonly var tables = ref rules.Criteria();
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref tables[i];
                if(table.IsEmpty)
                    return;

                var dst = XedPaths.Service.TableDef(table.Sig);
                using var writer = dst.Path.AsciWriter();
                writer.WriteLine(formatter.FormatHeader());
                for(var j=0u; j<table.RowCount; j++)
                {
                    var row = TableDefRow.Empty;
                    row.Seq = j;
                    row.TableId = table.TableId;
                    row.Index = j;
                    row.Kind = table.TableKind;
                    row.Name = table.TableName;
                    row.Statement = table[j].Format();
                    writer.AppendLine(formatter.Format(row));
                }
                writer.AppendLine();
                writer.AppendLine();
                lines(table,writer);
                writer.AppendLine();
            }
        }
    }
}