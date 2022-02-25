//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasmSvc
    {
        public AsmEncodingDocs CollectEncodingDocs(WsContext context)
        {
            var src = Projects.XedDisasmSources(context.Project);
            var count = src.Count;
            var dst = dict<FileRef,AsmEncodingDoc>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                var file = context.FileRef(src[i]);
                var result = XedDisasmOps.ParseEncodings(context, file, out var encodings);

                if(result)
                {
                    for(var j=0; j<encodings.RowCount; j++)
                        encodings[j].Seq = seq++;
                    dst[file] = encodings;
                }
                else
                {
                    Error(result.Message);
                    return dict<FileRef, AsmEncodingDoc>();
                }
            }

            return dst;
        }
    }
}