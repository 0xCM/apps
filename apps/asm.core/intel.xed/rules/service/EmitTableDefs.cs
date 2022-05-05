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
        void EmitTableDef(in TableCriteria table)
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
            table.RenderLines(emitter);
        }

        public void EmitTableDefs(RuleTables src)
        {
            ref readonly var tables = ref src.Criteria();
            iter(tables, table => EmitTableDef(table), PllExec);
        }
    }
}