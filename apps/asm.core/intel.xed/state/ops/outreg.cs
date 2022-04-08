//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static ref readonly Register outreg(in RuleState src)
            => ref @as<XedRegId,Register>(src.OUTREG);
    }
}