//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Op]
        public static EncodingOffsets offsets(in RuleState state)
        {
            var offsets = EncodingOffsets.Empty;
            offsets.OpCode = (sbyte)(state.POS_NOMINAL_OPCODE);
            if(state.HAS_MODRM)
                offsets.ModRm = (sbyte)state.POS_MODRM;
            if(state.POS_SIB != 0)
                offsets.Sib = (sbyte)state.POS_SIB;
            if(state.POS_DISP != 0)
                offsets.Disp = (sbyte)state.POS_DISP;
            if(state.IMM0)
                offsets.Imm0 = (sbyte)state.POS_IMM;
            return offsets;
        }
    }
}