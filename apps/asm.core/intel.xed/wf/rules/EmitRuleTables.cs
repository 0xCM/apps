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
            var src = RuleTableCalcs.CalcRuleSeq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        void EmitTableSpecs(RuleTables tables)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            exec(PllExec,
                () => emit(RuleTableKind.Enc),
                () => emit(RuleTableKind.Dec)
                );

            void emit(RuleTableKind kind)
            {
                var specs = tables.TableSpecs(kind);
                var dst = XedPaths.RuleSpecs(kind);
                using var writer = dst.AsciWriter();
                writer.AppendLine(formatter.FormatHeader());
                for(var i=0; i<specs.Count; i++)
                {
                    ref readonly var spec = ref specs[i];
                    ref readonly var sig = ref spec.Sig;
                    var rows = tables.DefRows(sig);
                    if(rows.IsNonEmpty)
                    {
                        writer.AppendLine();

                        for(var j=0; j<rows.Count; j++)
                        {
                            ref readonly var row = ref rows[j];
                            writer.AppendLine(formatter.Format(row));
                        }

                        writer.AppendLine();
                        writer.AppendLine();
                        foreach(var line in spec.Format().Lines(trim:false))
                            writer.AppendLineFormat("# {0}", line.Content);
                    }
                }
            }
        }

        public void EmitTableFiles(RuleTables tables)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            ref readonly var specs = ref tables.TableSpecs();
            iter(specs,spec => emit(spec), PllExec);
            void emit(in RuleTableSpec spec)
            {
                ref readonly var sig = ref spec.Sig;
                var dst = XedPaths.Service.TableDef(sig);
                Require.invariant(!dst.Exists);
                var rows = tables.DefRows(sig);
                if(rows.IsNonEmpty)
                {
                    using var writer = dst.AsciWriter();
                    writer.AppendLine(formatter.FormatHeader());
                    for(var i=0; i<rows.Count; i++)
                        writer.AppendLine(formatter.Format(rows[i]));

                    writer.AppendLine();
                    writer.AppendLine();
                    foreach(var line in spec.Format().Lines(trim:false))
                        writer.AppendLineFormat("# {0}", line.Content);
                }
            }
        }
    }
}