//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasmSvc
    {
        void EmitDisasmOps(WsContext context, DisasmDetailDoc doc)
        {
            var outdir = Projects.XedDisasmDir(context.Project);
            var filename = FS.file(string.Format("{0}.ops", doc.File.Source.Path.FileName.WithoutExtension.Format()), FS.Txt);
            var dst = outdir + filename;
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var counter = 0u;
            var count = doc.RowCount;
            for(var i=0; i<count;i++)
            {
                ref readonly var row = ref doc[i];
                ref readonly var detail = ref row.Detail;
                var mnemonic = detail.InstClass;
                writer.AppendLineFormat("{0,-6} {1}", counter++, mnemonic);
                writer.AppendLine(RP.PageBreak40);
                ref readonly var ops = ref detail.Operands;
                for(var j=0; j<ops.Count; j++)
                    writer.AppendLine(XedRender.format(ops[j]));

                writer.WriteLine();
            }

            EmittedFile(emitting,counter);
        }
    }
}