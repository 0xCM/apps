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
        static void lines(in TableCriteria src, ITextEmitter dst)
        {
            foreach(var line in src.Lines())
                dst.AppendLineFormat("# {0}", line.Content);
        }

        void EmitTableDef(TableCriteria table)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            using var emitter = XedPaths.Service.TableDef(table.Sig).Path.AsciEmitter();
            emitter.AppendLine(formatter.FormatHeader());
            var k=0u;
            for(var j=0u; j<table.RowCount; j++, k++)
            {
                ref readonly var spec = ref table[j];
                var specFormat = spec.Format();
                var row = TableDefRow.Empty;
                row.Seq = k;
                row.TableId = table.TableId;
                row.Index = j;
                row.Kind = table.TableKind;
                row.Name = table.TableName;
                row.Statement = specFormat;
                emitter.AppendLine(formatter.Format(row));

            }
            emitter.AppendLine();
            emitter.AppendLine();
            lines(table, emitter);
        }

        public void EmitTableDefs(RuleTables src)
        {
            ref readonly var tables = ref src.Criteria();
            iter(tables, table => EmitTableDef(table), PllExec);
        }

        public void EmitTableDefReport(RuleTables src)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            ref readonly var tables = ref src.Criteria();
            using var emitter = XedPaths.RuleSpecs().AsciEmitter();
            emitter.AppendLine(formatter.FormatHeader());
            var k=0u;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref tables[i];
                if(table.IsNonEmpty)
                {
                    emitter.AppendLine();

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
                        emitter.AppendLine(formatter.Format(row));
                    }

                    emitter.AppendLine();
                    emitter.AppendLine();
                    lines(table,emitter);
                }
            }
        }
    }
}