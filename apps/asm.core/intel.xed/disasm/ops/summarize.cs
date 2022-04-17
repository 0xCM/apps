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
        static DisasmSummaryDoc summary(WsContext context, in DisasmFile file)
        {
            var buffer = bag<DisasmSummaryLines>();
            summarize(context, file, buffer).Require();
            return DisasmSummaryDoc.from(file.Source, context.Root(file.Source), buffer.ToArray());
        }

        static Outcome summarize(WsContext context, in DisasmFile file, ConcurrentBag<DisasmSummaryLines> dst)
            => summarize(file.Source, context.Root(file.Source), file.Lines, dst);

        static Outcome summarize(in FileRef src, in FileRef origin, Index<DisasmLineBlock> blocks, ConcurrentBag<DisasmSummaryLines> dst)
        {
            var lines = SummaryLines(blocks);
            var expr = expressions(blocks);
            var seq = 0u;
            var result = Outcome.Success;
            var count = Require.equal(expr.Length,lines.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var summary = new DisasmSummary();
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
                dst.Add(new (blocks[i],summary));
            }

            return result;
        }
    }
}