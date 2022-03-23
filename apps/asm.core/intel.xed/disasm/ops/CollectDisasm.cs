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
        public void CollectDisasm(WsContext context)
        {
            Projects.XedDisasmDir(context.Project).Clear();
            var files = context.Files(FileKind.XedRawDisasm);
            var dst = cdict<FileRef,Index<DisasmDetail>>();
            iter(files, file => CollectDisasm(context,file,dst),PllExec);
            EmitDisasmDetails(dst,Projects.Table<DisasmDetail>(context.Project));
        }

        void CollectDisasm(WsContext context, FileRef file, ConcurrentDictionary<FileRef,Index<DisasmDetail>> dst)
        {
            var summary = XedDisasm.summarize(context, file);
            var detail = CalcDisasmDetail(context, file, summary);
            dst.TryAdd(file,detail);
            dst.TryAdd(file, detail);
            EmitDisasmOps(context, file, detail);
            EmitDisasmProps(context, summary, XedDisasm.blocks(file));
            EmitDisasmChecks(context, summary);
        }

        const string OpDetailRenderPattern = "{0,-4} | {1,-8} | {2,-24} | {3,-10} | {4,-12} | {5,-12} | {6,-12} | {7,-12}";

        static string[] OpColPatterns = new string[]{"Op{0}", "Op{0}Name", "Op{0}Val", "Op{0}Action", "Op{0}Vis", "Op{0}Width", "Op{0}WKind", "Op{0}Selector"};

        static string OpDetailHeader(int index)
            => string.Format(OpDetailRenderPattern, OpColPatterns.Select(x => string.Format(x, index)));

        void EmitDisasmDetails(ConstLookup<FileRef,Index<DisasmDetail>> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            var formatter = Tables.formatter<DisasmDetail>(DisasmDetail.RenderWidths);
            var headerBase = formatter.FormatHeader();
            var j = text.lastindex(headerBase, Chars.Pipe);
            headerBase = text.left(headerBase,j);
            var opheader = text.buffer();
            for(var k=0; k<6; k++)
            {
                opheader.Append("| ");
                opheader.Append(OpDetailHeader(k));
            }

            var details = core.map(src.Values, x => x.Storage).SelectMany(x => x).Sort();
            for(var i=0u; i<details.Length; i++)
                seek(details,i).Seq = i;

            var header = string.Format("{0}{1}", headerBase, opheader.Emit());
            using var writer = dst.AsciWriter();
            writer.WriteLine(header);
            for(var i=0; i<details.Length; i++)
                writer.WriteLine(formatter.Format(skip(details,i)));

            EmittedFile(emitting, details.Length);
        }
    }
}