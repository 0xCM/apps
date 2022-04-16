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
        static Outcome blocks(WsContext context, DisasmSummaryDoc doc, in DisasmFile src, ConcurrentBag<DetailBlock> dst)
        {
            var blocks = doc.Blocks;
            var count = blocks.Count;
            var result = Outcome.Success;
            if(result.Fail)
                return result;

            if(doc.RowCount != count)
            {
                result = (false, string.Format("{0} != {1}", count, doc.RowCount));
                return result;
            }

            for(var i=0; i<count; i++)
            {
                ref readonly var lines = ref blocks[i];
                dst.Add(new (row(lines), lines));
            }

            return result;
        }

        static DisasmDetailDoc doc(WsContext context, in DisasmFile file, DisasmSummaryDoc summary)
        {
            var dst = bag<DetailBlock>();
            blocks(context, summary, file, dst).Require();
            return new (file, dst.ToArray().Sort());
        }

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
    }
}