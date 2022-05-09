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
        void EmitRuleExpr(RuleTables src)
        {
            Emit(CalcSpecExpr(src.Specs()));
        }

        public void EmitTableSpecs(RuleTables src)
        {
            var formatter = Tables.formatter<TableDefRow>(TableDefRow.RenderWidths);
            ref readonly var specs = ref src.Specs();
            ref readonly var criteria = ref src.Criteria();
            using var emitter = XedPaths.RuleSpecs().AsciEmitter();
            emitter.AppendLine(formatter.FormatHeader());
            var k=0u;
            var count = Require.equal(specs.TableCount,criteria.Count);
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref specs[i];
                ref readonly var cTable = ref criteria[i];
                if(table.IsNonEmpty)
                {
                    emitter.AppendLine();

                    var kRows = Require.equal(cTable.RowCount, table.RowCount);
                    for(var j=0u; j<kRows; j++, k++)
                    {
                        ref readonly var row = ref table[j];
                        var dst = TableDefRow.Empty;
                        dst.Seq = k;
                        dst.TableId = table.TableId;
                        dst.Index = j;
                        dst.Kind = table.TableKind;
                        dst.Name = table.Name;
                        dst.Statement = row.Format();
                        emitter.AppendLine(formatter.Format(dst));
                    }

                    emitter.AppendLine();
                    emitter.AppendLine();
                    cTable.RenderLines(emitter);
                    //table.RenderLines(emitter);
                }
            }
        }
    }
}