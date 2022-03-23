//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static ScaleFactor scale(in RuleState src)
            => (ScaleFactor)src.SCALE;

        [MethodImpl(Inline), Op]
        public static void scale(ScaleFactor src, ref RuleState dst)
            => dst.SCALE = (byte)src;
    }
}