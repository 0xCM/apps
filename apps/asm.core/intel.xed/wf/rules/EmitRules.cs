//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;
    using static XedPatterns;

    partial class XedRules
    {
        public void EmitRules(RuleTables tables, Index<InstPattern> patterns)
        {
            EmitPatternOps(tables, patterns);

            exec(PllExec,
                () => EmitTableDefs(tables),
                () => EmitTableSigs(tables.SigInfo),
                () => EmitRuleSeq(),
                () => EmitTableSpecs(tables),
                () => EmitTableFiles(tables)
            );
        }

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

        void EmitTableSpecs(RuleTables rules)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            ref readonly var specs = ref rules.TableSpecs();
            var dst = XedPaths.RuleSpecs();
            using var writer = dst.AsciWriter();
            writer.AppendLine(formatter.FormatHeader());
            for(var i=0; i<specs.Count; i++)
            {
                ref readonly var spec = ref specs[i];
                var rows = rules.DefRows(spec.Sig);
                if(rows.IsNonEmpty)
                {
                    writer.AppendLine();
                    Emit(rules, spec, formatter, writer);
                    writer.AppendLine();
                }
            }
        }

        static void Emit(RuleTables rules, in CellTableSpec spec, IRecordFormatter<TableDefRow> formatter, StreamWriter writer)
        {
            var rows = rules.DefRows(spec.Sig);
            if(rows.IsNonEmpty)
            {
                for(var k=0; k<rows.Count; k++)
                    writer.AppendLine(formatter.Format(rows[k]));

                writer.AppendLine();
                writer.AppendLine();
                foreach(var line in spec.Lines())
                    writer.AppendLineFormat("# {0}", line.Content);
            }
        }

        public void EmitTableFiles(RuleTables rules)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            ref readonly var specs = ref rules.TableSpecs();
            iter(specs, spec => emit(spec), PllExec);

            void emit(in CellTableSpec spec)
            {
                var dst = XedPaths.Service.TableDef(spec.Sig);
                Require.invariant(!dst.Exists);
                var rows = rules.DefRows(spec.Sig);
                if(rows.IsNonEmpty)
                {
                    using var writer = dst.AsciWriter();
                    writer.AppendLine(formatter.FormatHeader());
                    Emit(rules, spec, formatter, writer);
                }
            }
        }
    }
}