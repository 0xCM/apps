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
        public static bool scale(in PatternOp src, out MemoryScale dst)
        {
            var result = search(src.Attribs, OpClass.Scale, out var attrib);
            if(result)
                dst = attrib.ToScale();
            else
                dst = default;

            return result;
        }
    }
}