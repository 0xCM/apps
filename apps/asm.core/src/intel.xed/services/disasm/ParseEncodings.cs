//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static Root;
    using static core;
    using static XedModels;

    partial class XedDisasmSvc
    {
        public Index<AsmStatementEncoding> ParseEncodings(ReadOnlySpan<FS.FilePath> src)
        {
            var dst = list<AsmStatementEncoding>();
            var counter = 0u;
            var count = src.Length;

            for(var i=0; i<count; i++)
            {
                var result = XedDisasmOps.ParseEncodings(skip(src,i), dst);
                if(result.Fail)
                {
                    Error(result.Message);
                    return sys.empty<AsmStatementEncoding>();
                }
            }

            var encodings = dst.ToArray();
            for(var i=0u; i<encodings.Length; i++)
                seek(encodings,i).Seq = i;

            return encodings;
        }

        public ConstLookup<FS.FilePath,SourceEncodings> ParseEncodings(IProjectWs project)
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