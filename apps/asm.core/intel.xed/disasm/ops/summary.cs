//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class XedDisasm
    {
        static Summary summary(WsContext context, in FileRef src)
        {
            var buffer = bag<SummaryLines>();
            var file = datafile(context, src);
            summary(src, file.Origin, file.Blocks, buffer).Require();
            return summary(file, buffer.ToArray());
        }

        static Summary summary(WsContext context, in DataFile src)
        {
            var lines = bag<SummaryLines>();
            summary(src.Source, context.Root(src.Source), src.Blocks, lines).Require();
            return summary(src, lines.ToArray());
        }

        static Summary summary(in DataFile file, SummaryLines[] src)
        {
            var lines = src.Sort();
            var rows = resequence(lines.Select(line => line.Summary));
            return new Summary(file, file.Origin, rows, lines);
        }

        static Index<Summary> summaries(WsContext context, bool pll = true)
        {
            var files = sources(context);
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            var dst = bag<Summary>();
            iter(files, source => dst.Add(summary(context,source)), pll);
            return dst.Array();
        }

        static Outcome summary(in FileRef src, in FileRef origin, Index<LineBlock> blocks, ConcurrentBag<SummaryLines> dst)
        {
            var lines = NumberedLines(blocks);
            var expr = expressions(blocks);
            var seq = 0u;
            var result = Outcome.Success;
            var count = Require.equal(expr.Length, lines.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var summary = new SummaryRow();
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

        static Index<AsmExpr> expressions(ReadOnlySpan<LineBlock> src)
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

        static Index<TextLine> NumberedLines(ReadOnlySpan<LineBlock> src)
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
    }
}