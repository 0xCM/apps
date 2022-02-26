//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial struct XedModels
    {
        public static Imm imm(in OpState state, in AsmHexCode code)
        {
            var dst = Imm.Empty;
            if(state.imm0)
            {
                var size = Sizes.native(state.imm_width);
                var signed = state.imm0signed;
                var pos = state.pos_imm;
                dst = asm.imm(code, pos, signed, size);
            }
            return dst;
        }
    }
}