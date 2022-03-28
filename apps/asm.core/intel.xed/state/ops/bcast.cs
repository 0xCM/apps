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
        public static BCastKind bcast(in RuleState src)
            => src.BCAST;

        [MethodImpl(Inline), Op]
        public static ref RuleState set(BCastKind src, ref RuleState dst)
        {
            dst.BCAST = src;
            return ref dst;
        }
    }
}