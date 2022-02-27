//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class XedDisasmSvc
    {
        public Index<XedDisasmSummary> EmitDisasmSummary(AsmEncodingDocs sources, FS.FilePath dst)
        {
            var paths = sources.Keys.ToArray().Sort();
            var recordcount = 0u;
            iter(sources.Values, src => recordcount += src.RowCount);
            var buffer = alloc<XedDisasmSummary>(recordcount);
            var counter = 0u;
            for(var i=0; i<paths.Length;i++)
            {
                sources.Find(skip(paths,i), out var encodings);
                var encoded = encodings.View;
                for(var j=0; j<encoded.Length; j++)
                {
                    ref var target = ref seek(buffer, counter++);
                    target = skip(encoded,j);
                }
            }
            var result = buffer.Sort();
            for(var i=0u; i<result.Length; i++)
                seek(result,i).Seq = i;

            TableEmit(@readonly(result), XedDisasmSummary.RenderWidths, dst);
            return result;
        }
    }
}