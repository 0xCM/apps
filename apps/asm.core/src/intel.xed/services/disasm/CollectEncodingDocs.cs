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
            var dst = dict<FileRef, AsmEncodingDoc>();
            for(var i=0; i<count; i++)
            {
                var fref = context.FileRef(src[i]);
                var result = XedDisasmOps.ParseEncodings(fref, out var encodings);
                if(result)
                    dst[fref] = encodings;
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