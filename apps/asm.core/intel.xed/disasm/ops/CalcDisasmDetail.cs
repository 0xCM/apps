//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        public static DisasmDetailDoc CalcDetailDoc(WsContext context, in DisasmFile file, DisasmSummaryDoc summary)
        {
            var dst = bag<DetailBlock>();
            CalcDetailBlocks(context, summary, file, dst).Require();
            return DisasmDetailDoc.from(file, dst.ToArray().Sort());
        }
   }
}