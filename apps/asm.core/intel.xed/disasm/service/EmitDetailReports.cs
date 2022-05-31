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
        public void EmitDetailReport(WsContext context, Document doc)
        {
            ref readonly var detail = ref doc.Detail;
            ref readonly var origin = ref detail.Origin;
            ref readonly var blocks = ref detail.Blocks;
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            var target = outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.details.csv");
            var buffer = text.buffer();
            DisasmRender.render(blocks, buffer);
            var emitting = EmittingFile(target);
            using var emitter = target.AsciEmitter();
            emitter.Write(buffer.Emit());
            EmittedFile(emitting, blocks.Count);
        }
    }
}