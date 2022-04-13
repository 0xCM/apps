//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static ref readonly ROUNDC rounc(in RuleState src)
            => ref @as<ROUNDC>(src.ROUNDC);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref ROUNDC rounc(in RuleState src)
                => ref @as<ROUNDC>(src.ROUNDC);
        }
    }
}