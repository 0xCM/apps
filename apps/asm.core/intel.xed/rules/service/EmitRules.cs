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
            => TableEmit(records(CalcRuleFields(rules)).View, KeyedCellRecord.RenderWidths, XedPaths.RuleTable<KeyedCellRecord>());

        void EmitTableSigs(RuleTables rules)
            => TableEmit(rules.SigRows.View, RuleSigRow.RenderWidths, XedPaths.Service.RuleTable<RuleSigRow>());

        void EmitRuleSeq()
        {
            var src = TableCalcs.ruleseq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        public void EmitTableFiles(RuleTables src)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            ref readonly var tables = ref src.Criteria();
            using var sEmitter = XedPaths.RuleSpecs().AsciEmitter();
            sEmitter.AppendLine(formatter.FormatHeader());
            var k=0u;

            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref tables[i];
                if(table.IsNonEmpty)
                {
                    using var fEmitter = XedPaths.Service.TableDef(table.Sig).Path.AsciEmitter();
                    fEmitter.AppendLine(formatter.FormatHeader());
                    sEmitter.AppendLine();

                    for(var j=0u; j<table.RowCount; j++, k++)
                    {
                        ref readonly var spec = ref table[j];
                        var specFormat = spec.Format();

                        var tRow = TableDefRow.Empty;
                        var sRow = TableDefRow.Empty;
                        tRow.Seq = k;
                        tRow.TableId = table.TableId;
                        tRow.Index = j;
                        tRow.Kind = table.TableKind;
                        tRow.Name = table.TableName;
                        tRow.Statement = specFormat;
                        fEmitter.AppendLine(formatter.Format(tRow));

                        sRow.Seq = k;
                        sRow.TableId = table.TableId;
                        sRow.Index = j;
                        sRow.Kind = table.TableKind;
                        sRow.Name = table.TableName;
                        sRow.Statement = specFormat;
                        sEmitter.AppendLine(formatter.Format(sRow));

                    }
                    fEmitter.AppendLine();
                    fEmitter.AppendLine();
                    lines(table, fEmitter);

                    sEmitter.AppendLine();
                    sEmitter.AppendLine();
                    lines(table,sEmitter);
                }
            }
        }
    }
}