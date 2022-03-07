//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasmSvc
    {
        Index<AsmDisasmSummary> CalcDisasmSummary(AsmDisasmSummaryDocs docs)
        {
            var paths = docs.Keys.ToArray().Sort();
            var recordcount = 0u;
            iter(docs.Values, src => recordcount += src.RowCount);
            var buffer = alloc<AsmDisasmSummary>(recordcount);
            var counter = 0u;
            for(var i=0; i<paths.Length;i++)
            {
                docs.Find(skip(paths,i), out var doc);
                var summaries = doc.View;
                for(var j=0; j<summaries.Length; j++)
                    seek(buffer, counter++) = skip(summaries,j);
            }
            var result = buffer.Sort();
            for(var i=0u; i<result.Length; i++)
                seek(result,i).Seq = i;
            return result;
        }
    }
}