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
        partial struct Code
        {
            [Op]
            public static Imm imm0(in RuleState state, in AsmHexCode code)
            {
                var dst = Imm.Empty;
                if(state.IMM0)
                    dst = asm.imm(code, state.POS_IMM, state.IMM0SIGNED, Sizes.native(state.IMM_WIDTH));
                return dst;
            }
        }
    }
}