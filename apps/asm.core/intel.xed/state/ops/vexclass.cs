//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static VexClass vexclass(in RuleState src)
            => (VexClass)src.VEXVALID;

        [MethodImpl(Inline), Op]
        public static ref RuleState set(VexClass src, ref RuleState dst)
        {
            dst.VEXVALID = (byte)src;
            return ref dst;
        }
    }
}