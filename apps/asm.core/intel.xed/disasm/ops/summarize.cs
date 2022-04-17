//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class XedDisasm
    {
        static Index<DisasmSummaryDoc> CalcSummaryDocs(WsContext context, bool pll = true)
        {
            var files = sources(context);
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            var dst = bag<DisasmSummaryDoc>();
            iter(files, source => dst.Add(summary(context,source)), pll);
            return dst.Array();
        }

        static DisasmSummaryDoc summary(WsContext context, in DisasmFile file)
        {
            var buffer = bag<DisasmSummaryLines>();
            summarize(context, file, buffer).Require();
            return DisasmSummaryDoc.create(file, context.Root(file.Source), buffer.ToArray());
        }

        static Outcome summarize(WsContext context, in DisasmFile file, ConcurrentBag<DisasmSummaryLines> dst)
            => summarize(file.Source, context.Root(file.Source), file.Lines, dst);

        static Index<TextLine> NumberedLines(ReadOnlySpan<DisasmLineBlock> src)
        {
            var dst = list<TextLine>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var lines = ref skip(src,i).Lines;
                var count = lines.Count;
                for(var j=0; j<count; j++)
                {
                    if(j == count-1)
                        dst.Add(lines[j]);
                }
            }
            return dst.ToArray();
        }

        static Index<AsmExpr> expressions(ReadOnlySpan<DisasmLineBlock> src)
        {
            var dst = list<AsmExpr>();
            foreach(var block in src)
            {
                foreach(var line in block.Lines)
                {
                    var i = text.index(line.Content, DisasmParse.YDIS);
                    if(i >= 0)
                        dst.Add(text.trim(text.right(line.Content, i + DisasmParse.YDIS.Length)));
                }
            }
            return dst.ToArray();
        }

        static Outcome summarize(in FileRef src, in FileRef origin, Index<DisasmLineBlock> blocks, ConcurrentBag<DisasmSummaryLines> dst)
        {
            var lines = NumberedLines(blocks);
            var expr = expressions(blocks);
            var seq = 0u;
            var result = Outcome.Success;
            var count = Require.equal(expr.Length, lines.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var summary = new DisasmSummaryRow();
                result = DisasmParse.parse(line.Content, out summary.Encoded);
                if(result.Fail)
                    return result;

                summary.DocSeq = seq++;
                summary.OriginId = origin.DocId;
                summary.OriginName = origin.DocName;
                result = DisasmParse.parse(line.Content, out summary.IP);
                if(result.Fail)
                    break;

                summary.InstructionId = AsmBytes.instid(summary.OriginId, summary.IP, summary.Encoded.Bytes);
                summary.EncodingId = summary.InstructionId.EncodingId;
                summary.Asm = expr[i];
                summary.Source = src.Path;
                summary.Source = summary.Source.LineRef(line.LineNumber);
                summary.Size = summary.Encoded.Size;
                dst.Add(new (blocks[i], summary));
            }

            return result;
        }
    }
}