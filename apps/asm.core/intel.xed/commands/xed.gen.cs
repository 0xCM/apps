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
    using static Datasets;

    partial class XedCmdProvider
    {
        static char symbol(NumericIndicator src)
            => src switch
            {
                NumericIndicator.Float => 'f',
                NumericIndicator.Unsigned => 'u',
                NumericIndicator.Signed=> 'i',
                _ => '\0',
            };
        public static InstOpClass @class(MachineMode mode, DisasmOpInfo src)
        {
            var info = XedWidths.describe(src.WidthCode);
            var bw = XedWidths.width(mode, src.WidthCode).Bits;
            var seg = info.SegType;
            var n = seg.CellCount;
            var et = symbol(info.ElementType.Indicator);

            var dst =  new InstOpClass {
                        Kind = src.Kind,
                        DataWidth = bw,
                        ElementType = info.ElementType,
                        CellCount = n,
                        Action = src.Action,
                        WidthCode = src.WidthCode,
                        OpType = src.OpType,
                        Selector = src.Selector
                    };

            return dst;
        }

        [CmdOp("xed/gen")]
        Outcome XedGen(CmdArgs args)
        {

            var docs = XedDisasm.docs(Context());
            var buffer = hashset<InstOpClass>();
            foreach(var (summary,detail) in docs)
            {
                buffer.AddRange(detail.Blocks.Select(x => x.DetailRow).SelectMany(x => x.Ops).Select(x => @class(ModeKind.Mode64, x.OpInfo)).Distinct());
            }


            var cols = new TableColumns(
                ("Seq",8),
                ("Kind",8),
                ("DataWidth", 12),
                ("ElementType", 12),
                ("CellCount", 12),
                ("WidthCode", 16),
                ("OpType", 16),
                ("Action", 12),
                ("Selector", 12)
                );

            var dst = text.buffer();
            dst.AppendLine(cols.Header);


            var src = buffer.Array().Sort();

            var rows = mapi(src, (i,item) =>
                new {
                    i,
                    item.Kind,
                    item.DataWidth,
                    item.ElementType,
                    item.CellCount,
                    item.WidthCode,
                    item.OpType,
                    item.Action,
                    item.Selector
                }
            );

            var emission = Datasets.emit(cols,rows, XedPaths.Targets() + FS.file("xed.inst.ops.classes", FS.Csv));
            Status(string.Format("Emitted {0} rows to {1}", emission.count, emission.path));

            //var docs = CalcDocs(Context());

            // var summaries = CalcSummaryDocs(context);
            // var details = CalcDetailBlocks(summaries);

            // EmitSummaries(context, summaries);
            // EmitDetails(context, details);

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