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
        static void blocks(DisasmSummaryDoc doc, ConcurrentBag<DetailBlock> dst)
        {
            var blocks = doc.Lines;
            Require.equal(blocks.Count, doc.RowCount);
            for(var i=0; i<blocks.Count; i++)
                dst.Add(new (row(blocks[i]), blocks[i]));
        }

        static DisasmDetailDoc doc(WsContext context, in DisasmFile file, DisasmSummaryDoc summary)
        {
            var dst = bag<DetailBlock>();
            blocks(summary, dst);
            return new (file, dst.ToArray().Sort());
        }
    }
}