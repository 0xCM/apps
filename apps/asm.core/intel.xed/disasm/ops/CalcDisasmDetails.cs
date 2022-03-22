//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedDisasmSvc
    {
        public Index<DisasmDetail> CalcDisasmDetails(WsContext context, in FileRef src)
        {
            var dst = core.bag<DisasmDetail>();
            CalcDisasmDetails(context, src, dst).Require();
            return dst.ToArray().Sort();
        }

        Outcome CalcDisasmDetails(WsContext context, in FileRef src, ConcurrentBag<DisasmDetail> dst)
            => CalcDisasmDetails(context, XedDisasm.blocks(src), dst);

        Outcome CalcDisasmDetails(WsContext context, in DisasmFileBlocks src, ConcurrentBag<DisasmDetail> dst)
        {
            var blocks = src.Lines;
            var count = blocks.Count;
            var result = XedDisasm.summarize(context, src.Source, out var summaries);
            if(result.Fail)
                return result;

            if(summaries.RowCount != count)
            {
                result = (false, string.Format("{0} != {1}", count, summaries.RowCount));
                return result;
            }

            for(var i=0u; i<count; i++)
            {
                result = CalcDisasmDetail(blocks[i], summaries[i], out DisasmDetail detail);
                if(result.Fail)
                    break;
                else
                    dst.Add(detail);
            }

            return result;
        }
   }
}