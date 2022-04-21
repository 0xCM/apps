//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        public void EmitOpsReport(WsContext context, Document src)
            => EmitOpsReport(context, src.Detail);

        void EmitOpsReport(WsContext context, Detail doc)
        {
            var dst = DisasmOpsPath(context,doc.DataFile.Source);
            var emitting = EmittingFile(dst);
            using var emitter = dst.AsciEmitter();
            var counter = 0u;
            var count = doc.Count;
            for(var i=0; i<count;i++)
            {
                ref readonly var row = ref doc[i];
                ref readonly var detail = ref row.DetailRow;
                var inst = detail.Instruction;
                emitter.AppendLine(RP.PageBreak80);
                XedRender.describe(detail, -24, emitter);
                ref readonly var ops = ref detail.Ops;
                emitter.AppendLine("Operands");
                for(var j=z8; j<ops.Count; j++)
                    emitter.AppendLine(XedRender.format(j, -24, ops[j]));

                emitter.WriteLine();
            }

            EmittedFile(emitting,counter);
        }
    }
}