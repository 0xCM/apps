//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;

    public partial class XedDisasm
    {
        public static Outcome summarize(WsContext context, in FileRef src, out DisasmSummaryDoc dst)
        {
            var buffer = bag<DisasmSummaryBlock>();
            var result = summarize(context, src, buffer);
            if(result)
                dst = DisasmSummaryDoc.from(src,context.Root(src), buffer.ToArray().Sort());
            else
                dst = DisasmSummaryDoc.Empty;
            return result;
        }

        public static Outcome summarize(WsContext context, in FileRef src, ConcurrentBag<DisasmSummaryBlock> dst)
            => summarize(src, context.Root(src), XedDisasm.blocks(src).Lines, dst);

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

        [MethodImpl(Inline)]
        public static ref uint inc(ref uint dst)
        {
            core.inc(ref core.@as<int>(dst));
            return ref dst;
        }

        public static Index<DisasmSummaryBlock> summarize(WsContext context, DisasmFileBlocks src)
        {
            var dst = bag<DisasmSummaryBlock>();
            summarize(src.Source, context.Root(src.Source), src.Lines, dst).Require();
            return dst.ToArray().Sort();
        }

        public static Outcome summarize(in FileRef src, in FileRef origin, Index<DisasmLineBlock> blocks, ConcurrentBag<DisasmSummaryBlock> dst)
        {
            var lines = SummaryLines(blocks);
            var expr = expressions(blocks);
            var seq = 0u;
            var result = Outcome.Success;
            var count = Require.equal(expr.Length,lines.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var summary = new AsmDisasmSummary();
                result = ParseHexCode(line, out summary.Encoded);
                if(result.Fail)
                    return result;

                summary.DocSeq = seq++;
                summary.OriginId = origin.DocId;
                summary.OriginName = origin.DocName;
                result = ParseIP(line.Content, out summary.IP);
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