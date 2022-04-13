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
        public static ref readonly VexClass vexclass(in RuleState src)
            => ref XedOpCodes.vexclass(src);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref VexClass vexclass(ref RuleState src)
                => ref @as<VexClass>(src.VEXVALID);
        }
    }
}