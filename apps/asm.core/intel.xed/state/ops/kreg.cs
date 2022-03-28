//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static RegOp kreg(in RuleState src)
            => asm.reg(NativeSizeCode.W64, RegClassCode.MASK, src.MASK);
    }
}