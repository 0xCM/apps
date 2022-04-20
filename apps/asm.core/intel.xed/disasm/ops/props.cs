//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedDisasm
    {
        public static DisasmProps props(InstClass @class, InstForm form, Index<Facet<string>> src)
        {
            var dst = dict<string,string>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var kvp = ref src[i];
                dst.Add(kvp.Key, kvp.Value);
            }
            return new DisasmProps(@class,form,dst);
        }
    }
}