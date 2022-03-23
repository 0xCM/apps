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
        public DisasmDetailDoc CalcDisasmDetail(WsContext context, in DisasmFile file, DisasmSummaryDoc summary)
        {
            var dst = bag<DisasmDetailBlock>();
            CalcDisasmDetail(context, summary, file, dst).Require();
            return DisasmDetailDoc.from(file, dst.ToArray().Sort());
        }

        Outcome CalcDisasmDetail(WsContext context, DisasmSummaryDoc doc, in DisasmFile src, ConcurrentBag<DisasmDetailBlock> dst)
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
                ref readonly var block = ref blocks[i];
                dst.Add(new (CalcDisasmDetail(block), block));
            }

            return result;
        }
   }
}