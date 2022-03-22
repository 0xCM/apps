//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    partial class XedFields
    {
        [Op]
        public static Imm imm1(in RuleState state, in AsmHexCode code)
        {
            var dst = Imm.Empty;
            if(state.IMM1)
                dst = asm.imm(code, state.POS_IMM1, false, Sizes.native(state.IMM1_BYTES/8));
            return dst;
        }
    }
}