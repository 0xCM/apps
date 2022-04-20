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
            using var writer = dst.AsciWriter();
            var counter = 0u;
            var count = doc.Count;
            for(var i=0; i<count;i++)
            {
                ref readonly var row = ref doc[i];
                ref readonly var detail = ref row.DetailRow;
                var mnemonic = detail.InstClass;
                writer.AppendLineFormat("{0,-6} {1}", counter++, mnemonic);
                writer.AppendLine(RP.PageBreak40);
                ref readonly var ops = ref detail.Ops;
                for(var j=z8; j<ops.Count; j++)
                    writer.AppendLine(XedRender.format(j, ops[j]));

                writer.WriteLine();
            }

            EmittedFile(emitting,counter);
        }
    }
}