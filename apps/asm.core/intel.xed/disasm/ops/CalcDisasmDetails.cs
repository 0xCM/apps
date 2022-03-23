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
        public Index<DisasmDetail> CalcDisasmDetail(WsContext context, in FileRef src, DisasmSummaryDoc summary)
        {
            var dst = core.bag<DisasmDetail>();
            var blocks = XedDisasm.blocks(src);
            CalcDisasmDetail(context, summary, blocks, dst).Require();
            return dst.ToArray().Sort();
        }

        Outcome CalcDisasmDetail(WsContext context, DisasmSummaryDoc doc, in DisasmFile src, ConcurrentBag<DisasmDetail> dst)
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
                dst.Add(CalcDisasmDetail(blocks[i]));

            return result;
        }
   }
}