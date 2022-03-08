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
        AsmDisasmSummaryDocs CollectDisasmSummaries(WsContext context)
        {
            var src = Projects.XedDisasmSources(context.Project);
            var count = src.Count;
            var dst = dict<FileRef,AsmDisasmSummaryDoc>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                var file = context.FileRef(src[i]);
                var result = XedDisasm.ParseSummaries(context, file, out var summaries);

                if(result)
                {
                    for(var j=0; j<summaries.RowCount; j++)
                        summaries[j].Seq = seq++;
                    dst[file] = summaries;
                }
                else
                {
                    Error(result.Message);
                    return dict<FileRef, AsmDisasmSummaryDoc>();
                }
            }

            return dst;
        }
    }
}