//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static EOSZ eosz(in RuleState src)
            => (EOSZ)src.EOSZ;

        [MethodImpl(Inline), Op]
        public static void eosz(EOSZ src, ref RuleState dst)
            => dst.EOSZ = (byte)src;
    }
}