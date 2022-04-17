//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Datasets;

    partial class XedCmdProvider
    {

        [CmdOp("xed/gen")]
        Outcome XedGen(CmdArgs args)
        {
            var docs = XedDisasm.docs(Context());
            var cols = new TableColumns(
                ("Seq",8),
                ("Kind",8),
                ("DataWidth", 12),
                ("ElementType", 12),
                ("IsRegLit", 12),
                ("IsLookup", 12),
                ("CellCount", 12),
                ("WidthCode", 16)
                );

            var src = XedDisasm.opclasses(docs);
            var dst = text.buffer();
            dst.AppendLine(cols.Header);
            var rows = mapi(src.Storage, (i,item) =>
                new {
                    i,
                    item.Kind,
                    item.DataWidth,
                    item.ElementType,
                    item.IsRegLit,
                    item.IsLookup,
                    item.CellCount,
                    item.WidthCode,
                }
            );

            var emission = Datasets.emit(cols,rows, XedPaths.Targets() + FS.file("xed.inst.ops.classes.disasm", FS.Csv));
            Status(string.Format("Emitted {0} rows to {1}", emission.count, emission.path));

            // ref readonly var fields = ref XedFields.ByPosition;
            // var bits = fields[0,51];
            // var dst = BitVector64.Zero;
            // var set = FieldSet.create();
            // for(var i=z8; i<bits.Length; i++)
            // {
            //     ref readonly var field = ref skip(bits,i);
            //     Write(string.Format("{0,-8} | {1,-24} | {2}", field.Pos, field.Field, field.FieldSize));

            // }


            return true;
        }

    }
}