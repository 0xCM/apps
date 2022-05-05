//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;
    using static XedRules;
    using static core;

    partial class XedDisasmSvc
    {
        public void EmitOpsReport(WsContext context, Document src)
            => EmitOpsReport(context, src.Detail);

        void EmitOpsReport(WsContext context, Detail doc)
        {
            var outpath = DisasmOpsPath(context,doc.DataFile.Source);
            var emitting = EmittingFile(outpath);
            using var dst = outpath.AsciEmitter();
            dst.AppendLineFormat(RenderCol2, "DataSource", doc.Source.Path.ToUri().Format());
            var counter = 0u;
            var count = doc.Count;
            for(var i=0; i<count;i++)
            {
                ref readonly var row = ref doc[i];
                ref readonly var detail = ref row.DetailRow;
                var inst = detail.Instruction;
                dst.AppendLine(RP.PageBreak80);
                XedRender.describe(detail, dst);
                ref readonly var ops = ref detail.Ops;
                dst.AppendLine("Operands");
                var specs = ops.Map(x => x.Spec);
                for(var j=0; j<specs.Length; j++)
                    dst.AppendLine(OpSpec.specifier(skip(specs,j)));

                //for(var j=z8; j<ops.Count; j++)
                    //dst.AppendLine(XedRender.format(j, ops[j]));

                dst.WriteLine();
            }

            EmittedFile(emitting,counter);
        }
    }
}