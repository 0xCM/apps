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
        public static byte map(in RuleState src)
            => src.MAP;

        [MethodImpl(Inline), Op]
        public static ref RuleState map(byte src, ref RuleState dst)
        {
            dst.MAP = src;
            return ref dst;
        }
    }
}