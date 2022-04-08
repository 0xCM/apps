//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedState
    {
        [Op]
        public static EncodingOffsets offsets(in RuleState src)
        {
            var offsets = EncodingOffsets.Empty;
            offsets.OpCode = (sbyte)(src.POS_NOMINAL_OPCODE);
            if(src.HAS_MODRM)
                offsets.ModRm = (sbyte)src.POS_MODRM;
            if(src.POS_SIB != 0)
                offsets.Sib = (sbyte)src.POS_SIB;
            if(src.POS_DISP != 0)
                offsets.Disp = (sbyte)src.POS_DISP;
            if(src.IMM0)
                offsets.Imm0 = (sbyte)src.POS_IMM;
            if(src.IMM1)
                offsets.Imm1 = (sbyte)src.POS_IMM1;
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