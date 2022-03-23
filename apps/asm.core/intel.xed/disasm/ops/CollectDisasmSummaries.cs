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
        DisasmSummaryDocs CollectDisasmSummaries(WsContext context)
        {
            var src = Projects.XedDisasmSources(context.Project);
            var count = src.Count;
            var dst = cdict<FileRef,DisasmSummaryDoc>();
            var seq = 0u;
            var files = context.Files(FileKind.XedRawDisasm);
            iter(files, file =>{
                var result = XedDisasm.summarize(context, file, out DisasmSummaryDoc doc);
                if(result)
                {
                    for(var j=0; j<doc.RowCount; j++)
                        doc[j].Seq = seq++;
                    dst.TryAdd(file, doc);
                }
                else
                {
                    Error(result.Message);
                }

            }, PllExec);

            return dst;
        }
    }
}