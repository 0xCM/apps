//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static MASK mask(in RuleState src)
            => (MASK)src.MASK;
    }
}