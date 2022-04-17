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
        public void EmitDetails(WsContext context, ConstLookup<DisasmSummaryDoc,Index<DetailBlock>> src, bool pll = true)
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

        Index<DetailBlockRow> EmitDetails(ConstLookup<FileRef,DisasmDetailDoc> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            var formatter = Tables.formatter<DetailBlockRow>(DetailBlockRow.RenderWidths);
            var headerBase = formatter.FormatHeader();
            var j = text.lastindex(headerBase, Chars.Pipe);
            headerBase = text.left(headerBase,j);
            var opheader = text.buffer();
            for(var k=0; k<6; k++)
            {
                opheader.Append("| ");
                opheader.Append(DisasmRender.OpDetailHeader(k));
            }

            var records = details(src);
            var header = string.Format("{0}{1}", headerBase, opheader.Emit());
            using var writer = dst.AsciWriter();
            writer.WriteLine(header);
            for(var i=0; i<records.Count; i++)
                writer.WriteLine(formatter.Format(records[i]));

            EmittedFile(emitting, records.Count);
            return records;
        }

        static Index<DetailBlockRow> details(ConstLookup<FileRef,DisasmDetailDoc> src)
        {
            var details = core.map(src.Values, doc => map(doc.Blocks, r => r.DetailRow)).SelectMany(x => x).Sort();
            for(var i=0u; i<details.Length; i++)
                seek(details,i).Seq = i;
            return details;
        }
    }
}