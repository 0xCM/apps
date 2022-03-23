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
        void EmitDisasmOps(WsContext context, in FileRef file, Index<DisasmDetail> details)
        {
            var outdir = Projects.XedDisasmDir(context.Project);
            var filename = FS.file(string.Format("{0}.ops",file.Path.FileName.WithoutExtension.Format()), FS.Txt);
            var dst = outdir + filename;
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var counter = 0u;
            foreach(var detail in details)
            {
                var mnemonic = detail.Mnemonic;
                var ops = detail.Operands;
                var count = ops.Count;
                writer.AppendLineFormat("{0,-6} {1}", counter++, mnemonic);
                writer.AppendLine(RP.PageBreak40);
                for(var i=0; i<count; i++)
                    writer.AppendLine(XedRender.format(ops[i]));
                writer.WriteLine();
            }
            EmittedFile(emitting,counter);
        }
    }
}