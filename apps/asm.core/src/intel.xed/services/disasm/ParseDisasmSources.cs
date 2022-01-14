//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;
    using static XedModels;

    partial class XedDisasmSvc
    {
        public ConstLookup<FS.FilePath,SourceEncodings> ParseDisasmSources(IProjectWs project)
        {
            var src = XedPaths.DisasmSources(project);
            var count = src.Count;
            var dst = dict<FS.FilePath,SourceEncodings>();
            for(var i=0; i<count; i++)
            {
                var result = XedDisasmOps.ParseEncodings(src[i], out var encodings);
                if(result)
                    dst[src[i]] = encodings;
                else
                {
                    Error(result.Message);
                    return dict<FS.FilePath,SourceEncodings>();
                }
            }
            return dst;
        }
    }
}