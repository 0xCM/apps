//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedMachine;
    using static XedModels;
    using static XedRules;
    using static Datasets;

    partial class XedCmdProvider
    {
        public static InstOpClass @class(in InstOpDetail src)
        {
            var info = XedWidths.describe(src.WidthCode);
            var bitwidth = XedWidths.width(src.Mode, src.WidthCode).Bits;
            var dst = InstOpClass.Empty;
            dst.Kind = src.Kind;
            dst.DataWidth = src.BitWidth;
            dst.WidthCode = src.WidthCode;
            dst.ElementType = src.ElementType;
            dst.CellCount = src.SegInfo.CellCount;
            dst.IsRegLit = src.IsRegLit;
            dst.IsLookup = src.IsNonterm;
            return dst;

        }
        [CmdOp("xed/opclass")]
        Outcome CalcOpClasses(CmdArgs args)
        {
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

            var ops = Xed.Rules.CalcInstOpDetails();
            var buffer = bag<InstOpClass>();
            iter(ops, op =>buffer.Add(@class(op)), true);
            var src = buffer.Array().Distinct().Sort();
            var dst = text.buffer();
            dst.AppendLine(cols.Header);
            var rows = mapi(src, (i,item) =>
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

            var emission = Datasets.emit(cols,rows, XedPaths.Targets() + FS.file("xed.inst.ops.classes", FS.Csv));
            Status(string.Format("Emitted {0} rows to {1}", emission.count, emission.path));

            return true;
        }

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