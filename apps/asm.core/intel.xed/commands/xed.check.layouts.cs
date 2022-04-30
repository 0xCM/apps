//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static Datasets;
    using static core;

    partial class XedCmdProvider
    {
        static Span<object> clear(Span<object> src)
        {
            for(var i=0; i<src.Length; i++)
                seek(src,i) = EmptyString;
            return src;
        }

        [CmdOp("xed/check/symsegs")]
        Outcome CheckSymSegs(CmdArgs args)
        {
            var cells = CalcRuleCells();
            var tables = cells.Tables;
            var dst = text.buffer();
            var counter = 0;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref tables[i];
                for(var j=0; j<table.RowCount; j++)
                {
                    ref readonly var row = ref table[j];
                    var fields = CellTable.fields(row);
                    dst.AppendLineFormat("{0,-32} {1:D3} {2:D2} {3}", table.Sig, table.TableIndex, row.RowIndex, fields.Delimit(Chars.Space).Format());
                    counter++;
                }
            }

            FileEmit(dst.Emit(), counter, XedPaths.RuleTarget("tables.fields", FS.Txt));

            return true;
        }

        [CmdOp("xed/check/layouts")]
        Outcome CheckLayouts(CmdArgs args)
        {
            var cols = new TableColumns("xed.inst.layouts", new (string, byte)[]{
                ("PatternId",12),
                ("Instruction",18),
                ("OpCode",18),
                ("Count", 6),
                ("Cell[0]", 22),
                ("Cell[1]", 22),
                ("Cell[2]", 22),
                ("Cell[3]", 22),
                ("Cell[4]", 22),
                ("Cell[5]", 22),
                ("Cell[6]", 22),
                ("Cell[7]", 22),
                ("Cell[8]", 22),
                ("Cell[9]", 22),
            });

            var counter = 0;
            var src = CalcLayoutCells();
            var dst = text.emitter();
            Index<object> buffer = alloc<object>(cols.Count);
            dst.AppendLine(cols.Header);
            foreach(var r in src.Keys)
            {
                var cells = src[r];
                var count = cells.Length;
                counter += count;

                var fmt = cells.Select(x => string.Format("{0}:{1}", x.Kind, x));
                clear(buffer);
                var k=0;
                buffer[k++] = r.PatternId;
                buffer[k++] = r.InstClass;
                buffer[k++] = r.OpCode;
                buffer[k++] = count;
                for(var j=0; j<fmt.Length; j++, k++)
                    buffer[k] = fmt[j];

                dst.AppendLine(cols.FormatSeq(buffer));
            }

            FileEmit(dst.Emit(), counter, XedPaths.Targets() + FS.file("xed.inst.layouts", FS.Csv));
            // var inst = CalcInstSegs();
            // iter(inst, x => Write(x));
            return true;
        }
    }
}