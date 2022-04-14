//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        public static ConstLookup<DisasmDetailDoc,Index<DetailBlockRow>> CalcDocDetails(ConstLookup<FileRef,DisasmDetailDoc> src)
        {
            var buffer = cdict<DisasmDetailDoc,Index<DetailBlockRow>>();
            var kvp = core.map(src.Values, doc => (doc, details: doc.View.ToArray().Select(x => x.Detail)));
            for(var j=0; j<kvp.Length; j++)
            {
                ref var details = ref seek(kvp,j).details;
                details.Sort();
                for(var i=0u; i<details.Length; i++)
                    seek(details,i).Seq = i;
                buffer[seek(kvp,j).doc] = details;
            }

            return buffer;
        }
    }
}