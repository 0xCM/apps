//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        public void EmitDetailReports(WsContext context, ConstLookup<DisasmSummaryDoc,Index<DetailBlock>> src, bool pll = true)
        {
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            iter(src.Keys, doc =>{
                ref readonly var origin = ref doc.Origin;
                var blocks = src[doc];
                var target = outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.details.csv");
                var buffer = text.buffer();
                DisasmRender.render(blocks, buffer);
                var emitting = EmittingFile(target);
                using var emitter = target.AsciEmitter();
                emitter.Write(buffer.Emit());
                EmittedFile(emitting, blocks.Count);
            },pll);
        }

        public void EmitDetailReport(WsContext context, DisasmDetailDoc doc)
        {
            ref readonly var origin = ref doc.Origin;
            ref readonly var blocks = ref doc.Blocks;
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            var target = outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.details.csv");
            var buffer = text.buffer();
            DisasmRender.render(blocks, buffer);
            var emitting = EmittingFile(target);
            using var emitter = target.AsciEmitter();
            emitter.Write(buffer.Emit());
            EmittedFile(emitting, blocks.Count);
        }

        public void EmitDetailReport(WsContext context, Index<DetailBlock> src)
        {
            var target = Projects.Table<DetailBlockRow>(context.Project);
            var buffer = text.buffer();
            DisasmRender.render(resequence(src), buffer);
            var emitting = EmittingFile(target);
            using var emitter = target.AsciEmitter();
            emitter.Write(buffer.Emit());
            EmittedFile(emitting, src.Count);
        }
    }
}