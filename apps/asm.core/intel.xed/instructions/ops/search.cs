//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static bool search(in OpAttribs src, OpClass @class, out OpAttrib dst)
        {
            var result = false;
            dst = OpAttrib.Empty;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var a = ref src[i];
                if(a.Class == @class)
                {
                    dst = a;
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}