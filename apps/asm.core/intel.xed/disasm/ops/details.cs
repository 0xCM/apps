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
        public static Index<DetailBlockRow> details(ConstLookup<FileRef,DisasmDetailDoc> src)
        {
            var details = core.map(src.Values, doc => map(doc.View, r => r.Detail)).SelectMany(x => x).Sort();
            for(var i=0u; i<details.Length; i++)
                seek(details,i).Seq = i;
            return details;
        }
    }
}