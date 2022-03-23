//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedPatterns
    {
        internal static bool classify(Index<InstRulePart,string> names, string src, out InstRulePart part)
        {
            var count = names.Count;
            var result = false;
            part = default;
            for(var i=0; i<count; i++)
            {
                var p = (InstRulePart)i;
                ref readonly var n = ref names[p];
                if(n == src)
                {
                    part = p;
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}