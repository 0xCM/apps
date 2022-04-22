//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellEmitter
        {
            public static void emit(RuleTables rules, ITextEmitter dst)
            {
                var cols = TableSpecs.Columns;
                dst.WriteLine(cols.Header);
                var tables = rules.Specs().Values.ToArray().Index();
                for(var i=0; i<tables.Count; i++)
                {
                    ref readonly var table = ref tables[i];
                    ref readonly var rows = ref table.Rows;
                    for(var j=z16; j<rows.Count; j++)
                    {
                        ref readonly var row = ref rows[j];
                        ref readonly var cells = ref row.Cells;
                        for(var k=z16; k<cells.Count; k++)
                        {
                            ref readonly var cell = ref cells[k];
                            var buffer = cols.Buffer();
                            buffer.Write(i);
                            buffer.Write(row.Sig.TableKind);
                            buffer.Write(row.Sig.TableName);
                            buffer.Write(j);
                            buffer.Write(k);
                            buffer.Write(cell.Type);
                            buffer.Write(XedRender.format(cell.Field));
                            buffer.Write(cell.Operator);
                            buffer.Write(cell);
                            dst.WriteLine(buffer.Emit());
                        }
                    }
                }
            }
        }
    }
}