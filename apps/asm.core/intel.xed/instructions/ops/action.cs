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
        public static bool action(in PatternOp src, out OpAction dst)
        {
            var result = search(src.Attribs, OpClass.Action, out var attrib);
            if(result)
                dst = attrib.AsAction();
            else
                dst = default;

            return result;
        }
    }
}