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
        public static bool ptrwidth(in PatternOp src, out PointerWidthKind dst)
        {
            var result = search(src.Attribs, OpClass.PtrWidth, out var attrib);
            if(result)
                dst = attrib.AsPtrWidth();
            else
                dst = 0;
            return result;
        }
    }
}