//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial class XedDisasmSvc
    {
        public AsmEncodingDocs CollectEncodingDocs(ProjectCollection collect)
        {
            var src = XedPaths.DisasmSources(collect.Project);
            var count = src.Count;
            var dst = dict<FS.FilePath,AsmEncodingDoc>();
            for(var i=0; i<count; i++)
            {
                var result = XedDisasmOps.ParseEncodings(collect.FileRef(src[i]), out var encodings);
                if(result)
                    dst[src[i]] = encodings;
                else
                {
                    Error(result.Message);
                    return dict<FS.FilePath,AsmEncodingDoc>();
                }
            }
            return dst;
        }
    }
}