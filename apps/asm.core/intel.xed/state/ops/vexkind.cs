//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static VexKind vexkind(in RuleState src)
            => (VexKind)src.VEX_PREFIX;

        [MethodImpl(Inline), Op]
        public static ref RuleState set(VexKind src, ref RuleState dst)
        {
            dst.VEX_PREFIX = (byte)src;
            return ref dst;
        }
    }
}