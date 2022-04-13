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
            RenderCellSpecs(rules,dst);
            FileEmit(dst.Emit(), 1, XedPaths.RuleTargets() + FS.file("xed.rules.cells", FS.Csv), TextEncodingKind.Asci);
        }

        public static string format(Index<RowSpec> table, TableColumns cols)
        {
            var dst = text.buffer();
            render(table,cols,dst);
            return dst.Emit();
        }

        public static string format(Index<RowSpec> table)
        {
            var dst = text.buffer();
            render(table,dst);
            return dst.Emit();
        }

        public static void render(Index<RowSpec> table, ITextBuffer dst)
        {
            if(table.IsEmpty)
                return;
            var cols = RowSpecs.Columns;
            render(table,cols, cols.Buffer(),dst);
        }

        public static void render(Index<RowSpec> table, TableColumns cols, ITextBuffer dst)
        {
            if(table.IsEmpty)
                return;

            render(table,cols,cols.Buffer(),dst);
        }

        public static void render(Index<RowSpec> table, TableColumns cols, ColumnBuffer buffer, ITextBuffer dst)
        {
            if(table.IsEmpty)
                return;

            ref readonly var sig = ref table.First.Sig;
            for(var j=0; j<table.Count; j++)
            {
                ref readonly var row = ref table[j];
                ref readonly var tk = ref row.TableKind;
                ref readonly var rix = ref row.RowIndex;
                ref readonly var count = ref row.ColCount;
                for(var k = z16; k<count; k++)
                {
                    ref readonly var cell = ref row.Cell(k);
                    ref readonly var key = ref row.Key(k);
                    ref readonly var cix = ref key.CellIndex;
                    ref readonly var type = ref cell.Type;

                    buffer.Write(row.TableId);
                    buffer.Write(tk);
                    buffer.Write(sig.ShortName);
                    buffer.Write(rix);
                    buffer.Write(cix);
                    buffer.Write(type);
                    buffer.Write(XedRender.format(cell.Field));
                    buffer.Write(cell.Operator);
                    buffer.Write(cell);
                    buffer.EmitLine(dst);
                }
            }
        }

        public static void render(RowSpecs tables, TableColumns cols, ITextBuffer dst)
        {
            var buffer = cols.Buffer();
            buffer.EmitHeader(dst);
            var sigs = tables.Keys;
            var counter = 0u;
            for(var i=0; i<sigs.Length; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                var table = tables[sig];
                render(table, cols, buffer, dst);
            }
        }

        static void RenderCellSpecs(RuleTables rules, ITextBuffer dst)
        {
            var cols = RowSpecs.Columns;
            var tables = rules.RowSpecs();
            render(tables, cols, dst);
        }
    }
}