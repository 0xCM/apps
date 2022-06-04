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
            var targets = context.ProjectDatasets("xed.disasm");
            var target = targets.Path(doc.Origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.details.csv"));
            var dst = text.emitter();
            DisasmRender.render(doc.DetailBlocks, dst);
            var emitting = EmittingFile(target);
            using var emitter = target.AsciEmitter();
            emitter.Write(dst.Emit());
            EmittedFile(emitting, doc.DetailBlocks.Count);
        }
    }
}