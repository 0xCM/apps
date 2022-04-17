//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;

    partial class XedDisasm
    {
        static Index<DetailBlock> resequence(Index<DetailBlock> src)
        {
            var dst = src.Sort();
            for(var i=0u; i<dst.Count; i++)
            {
                var row = dst[i].DetailRow;
                row.Seq = i;
                dst[i] = new DetailBlock(row, dst[i].SummaryLines);
            }
            return dst;
        }

    }
}