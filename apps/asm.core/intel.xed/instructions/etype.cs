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
        public static bool etype(in PatternOp src, out ElementType dst)
        {
            var result = XedPatterns.first(src.Attribs, OpAttribClass.ElementType, out var attrib);
            if(result)
                dst = attrib.ToElementType();
            else
                dst = ElementType.Empty;

            return result;
        }
    }
}