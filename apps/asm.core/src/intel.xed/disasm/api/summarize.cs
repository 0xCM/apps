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
        public static Outcome summarize(WsContext context, in FileRef src, out AsmDisasmSummaryDoc dst)
        {
            var buffer = list<AsmDisasmSummary>();
            var result = summarize(context, src,buffer);
            if(result)
                dst = (src.Path,buffer.ToArray());
            else
                dst = (src.Path,sys.empty<AsmDisasmSummary>());
            return result;
        }

        public static Outcome summarize(WsContext context, in FileRef src, List<AsmDisasmSummary> dst)
            => summarize(src, context.Root(src), XedDisasm.blocks(src).Lines,dst);

        static ReadOnlySpan<TextLine> SummaryLines(ReadOnlySpan<DisasmLineBlock> src)
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
            return dst.ViewDeposited();
        }

        public static Index<AsmDisasmSummary> summarize(WsContext context, DisasmFileBlocks blocks)
        {
            var dst = list<AsmDisasmSummary>();
            summarize(blocks.Source, context.Root(blocks.Source), blocks.Lines, dst).Require();
            return dst.ToArray();
        }

        public static Index<AsmDisasmSummary> summarize(WsContext context, in FileRef src)
        {
            var dst = list<AsmDisasmSummary>();
            summarize(src, context.Root(src), XedDisasm.blocks(src).Lines, dst).Require();
            return dst.ToArray();
        }

        public static Outcome summarize(in FileRef src, in FileRef origin, Index<DisasmLineBlock> blocks, List<AsmDisasmSummary> dst)
        {
            var summaries = SummaryLines(blocks);
            var expr = expressions(blocks);
            var counter = 0u;
            var result = Outcome.Success;
            var count = Require.equal(expr.Length,summaries.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(summaries,i);
                ref readonly var content = ref line.Content;
                ref readonly var expression = ref skip(expr,i);

                var record = new AsmDisasmSummary();
                result = ParseHexCode(line, out record.Encoded);
                if(result.Fail)
                    return result;

                record.DocSeq = counter++;

                record.OriginId = origin.DocId;
                record.OriginName = origin.DocName;
                result = ParseIP(content, out record.IP);
                if(result.Fail)
                    break;

                record.InstructionId = AsmBytes.instid(record.OriginId, record.IP, record.Encoded.Bytes);
                record.EncodingId = record.InstructionId.EncodingId;
                record.Asm = expression;
                record.Source = src.Path;
                record.Source = record.Source.LineRef(line.LineNumber);
                record.Size = record.Encoded.Size;
                dst.Add(record);
            }

            return result;
        }
    }
}
