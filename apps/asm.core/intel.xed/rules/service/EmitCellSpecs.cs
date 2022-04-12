//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Datasets;
    using static core;

    partial class XedRules
    {
        public void EmitCellSpecs(RuleTables rules)
        {
            var dst = text.buffer();
            var count = RenderCellSpecs(rules,dst);
            FileEmit(dst.Emit(), count, XedPaths.RuleTargets() + FS.file("xed.rules.cells", FS.Csv), TextEncodingKind.Asci);
        }

        static uint RenderCellSpecs(RuleTables rules, ITextBuffer dst)
        {
            var cols = new TableColumns(
                ("TableId", 10),
                ("TableKind", 10),
                ("TableName", 32),
                ("RowIndex", 10),
                ("CellIndex", 10),
                ("Type", 24),
                ("Field", 22),
                ("Op", 4),
                ("Value", 16)
                );

            var tables = rules.TableSpecs().Select(x => (x.TableId, x)).ToDictionary();

            var buffer = cols.Buffer();
            buffer.EmitHeader(dst);

            var trows = rules.RowSpecs();
            var tkeys = trows.Keys;
            var counter = 0u;
            for(var i=0; i<tkeys.Length; i++)
            {
                var tid = skip(tkeys,i);
                var table = tables[tid];
                var tname = table.TableName;
                var trow = trows[tid];
                for(var j=0; j<trow.Count; j++)
                {
                    ref readonly var row = ref trow[j];
                    ref readonly var tk = ref row.TableKind;
                    ref readonly var rix = ref row.RowIndex;
                    ref readonly var count = ref row.ColCount;
                    for(var k = z16; k<count; k++)
                    {
                        ref readonly var cell = ref row.Cell(k);
                        ref readonly var key = ref row.Key(k);
                        ref readonly var cix = ref key.CellIndex;
                        ref readonly var type = ref cell.Type;

                        buffer.Write(tid);
                        buffer.Write(tk);
                        buffer.Write(tname);
                        buffer.Write(rix);
                        buffer.Write(cix);
                        buffer.Write(type);
                        buffer.Write(XedRender.format(cell.Field));
                        buffer.Write(cell.Operator);
                        buffer.Write(cell);
                        buffer.EmitLine(dst);
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}