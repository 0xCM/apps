//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedDisasmSvc
    {
        Outcome CalcDisasmDetails(WsContext context, in DisasmFileBlocks src, ConcurrentBag<DisasmDetail> buffer)
        {
            var blocks = src.LineBlocks;
            var count = blocks.Count;
            var result = XedDisasmOps.ParseSummaries(context, src.Source, out var summaries);
            if(result.Fail)
                return result;

            if(summaries.RowCount != count)
            {
                result = (false, string.Format("{0} != {1}", count, summaries.RowCount));
                return result;
            }

            for(var i=0u; i<count; i++)
            {
                ref readonly var block = ref blocks[i];
                ref readonly var encoding =ref summaries[i];
                var detail = DisasmDetail.Empty;
                result = CalcDisasmDetail(block, encoding, out detail);
                if(result.Fail)
                    break;
                else
                    buffer.Add(detail);
            }

            return result;
        }
    }
}