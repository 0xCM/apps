//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class XedDisasm
    {
        public static DisasmSummaryDoc summarize(WsContext context, in DisasmFile file)
        {
            var buffer = bag<DisasmBlock>();
            summarize(context, file, buffer).Require();
            return DisasmSummaryDoc.from(file.Source, context.Root(file.Source), buffer.ToArray());
        }

        public static Outcome summarize(WsContext context, in DisasmFile file, ConcurrentBag<DisasmBlock> dst)
            => summarize(file.Source, context.Root(file.Source), file.Lines, dst);

        static Index<TextLine> SummaryLines(ReadOnlySpan<DisasmLineBlock> src)
        {
            var dst = list<TextLine>();
            for(var i=0; i<src.Length; i++)
            {
                var lines = skip(src,i).Lines;
                var count = lines.Count;
                for(var j=0; j<count; j++)
                {
                    if(j == count-1)
                        dst.Add(lines[j]);
                }
            }
            return dst.ToArray();
        }

        static Outcome summarize(in FileRef src, in FileRef origin, Index<DisasmLineBlock> blocks, ConcurrentBag<DisasmBlock> dst)
        {
            var lines = SummaryLines(blocks);
            var expr = DisasmParse.expressions(blocks);
            var seq = 0u;
            var result = Outcome.Success;
            var count = Require.equal(expr.Length,lines.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var summary = new DisasmSummary();
                result = DisasmParse.parse(line, out summary.Encoded);
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
                dst.Add(new (blocks[i],summary));
            }

            return result;
        }
    }
}