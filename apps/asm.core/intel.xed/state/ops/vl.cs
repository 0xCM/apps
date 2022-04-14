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
        public static ref readonly VexLength vl(in RuleState src)
            => ref @as<VexLength>(src.VL);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref VexLength vl(ref RuleState src)
                => ref @as<VexLength>(src.VL);
        }
    }
}