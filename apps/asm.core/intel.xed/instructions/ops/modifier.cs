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
        public static bool modifier(in PatternOp src, out OpModifier dst)
        {
            if(search(src.Attribs, OpClass.Visibility, out var attrib))
                dst = attrib.AsModifier();
            else
                dst = default;
            return true;
        }
    }
}