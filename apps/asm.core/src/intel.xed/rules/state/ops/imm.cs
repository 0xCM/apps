//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        partial struct RuleStateCalcs
        {
            public static Imm imm(in FieldState state, in AsmHexCode code)
            {
                var dst = Imm.Empty;
                if(state.IMM0)
                {
                    var size = Sizes.native(state.IMM_WIDTH);
                    var signed = state.IMM0SIGNED;
                    var pos = state.POS_IMM;
                    dst = asm.imm(code, pos, signed, size);
                }
                return dst;
            }
        }
    }
}