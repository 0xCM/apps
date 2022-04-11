//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedPatterns
    {
        [Op]
        public static OpCodeMap ocmap(OpCodeKind kind)
        {
            var @class = XedPatterns.occlass(kind);
            var selector = XedPatterns.selector(kind);
            var indicator = XedPatterns.indicator(@class);
            var index = XedPatterns.ocindex(kind);
            return new OpCodeMap(kind, @class, index, indicator, selector);
        }
    }
}