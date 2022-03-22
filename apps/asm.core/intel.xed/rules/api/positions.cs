//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [Op]
        public static EncodingOffsets positions(in RuleState state)
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
            if(state.IMM1)
                offsets.Imm1 = (sbyte)state.POS_IMM1;
            return offsets;
        }

        [MethodImpl(Inline), Op]
        public static void pack(EncodingOffsets src, Span<byte> dst)
        {
            var offsets = @readonly(bytes(src));
            Bitfields.pack4x4(
                skip(offsets,0),
                skip(offsets,1),
                skip(offsets,2),
                skip(offsets,3),
                ref seek16(dst,0)
                );

            Bitfields.pack4x2(
                skip(offsets,4),
                skip(offsets,5),
                ref seek(dst,4)
                );
        }
    }
}