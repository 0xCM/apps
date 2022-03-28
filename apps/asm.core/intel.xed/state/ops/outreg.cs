//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static RegOp outreg(in RuleState src)
            => XedRegMap.map(src.OUTREG);

        [MethodImpl(Inline), Op]
        public static ref RuleState outreg(XedRegId src, ref RuleState dst)
        {
            dst.OUTREG = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref RuleState outreg(RegKind src, ref RuleState dst)
        {
            dst.OUTREG = XedRegMap.map(src);
            return ref dst;
        }
    }
}