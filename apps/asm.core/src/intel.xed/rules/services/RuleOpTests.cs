//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-iclass-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules.RuleOpName;

    partial class XedRules
    {
        [ApiHost]
        public readonly struct RuleOpTests
        {
            [MethodImpl(Inline), Op]
            public static bool basereg(RuleOpName src)
                => src >= RuleOpName.BASE0 && src <= RuleOpName.BASE1;

            [MethodImpl(Inline), Op]
            public static bool sreg(RuleOpName src)
                => src >= RuleOpName.SEG0 && src <= RuleOpName.SEG1;

            [MethodImpl(Inline), Op]
            public static bool ireg(RuleOpName src)
                => src == RuleOpName.INDEX;

            [MethodImpl(Inline), Op]
            public static bool scale(RuleOpName src)
                => src == RuleOpName.SCALE;

            [MethodImpl(Inline), Op]
            public static bool pointer(RuleOpName src)
                => src == RuleOpName.PTR;

            [MethodImpl(Inline), Op]
            public static bool reg(RuleOpName src)
                => src >= RuleOpName.REG0 && src <= RuleOpName.REG9;

            [MethodImpl(Inline), Op]
            public static bool relbr(RuleOpName src)
                => src == RuleOpName.RELBR;

            [MethodImpl(Inline), Op]
            public static bool mem(RuleOpName src)
                => src >= RuleOpName.MEM0 && src <= RuleOpName.MEM1;

            [MethodImpl(Inline), Op]
            public static bool imm(RuleOpName src)
                => src >= RuleOpName.IMM0 && src <= RuleOpName.IMM2;

            [Op]
            static bool regix(RuleOpName src, out byte index)
            {
                var i = src switch
                {
                    REG0 => 0,
                    REG1 => 1,
                    REG2 => 2,
                    REG3 => 3,
                    REG4 => 4,
                    REG5 => 5,
                    REG6 => 6,
                    REG7 => 7,
                    REG8 => 8,
                    _ => -1,
                };

                if(i >0)
                {
                    index = (byte)i;
                    return true;
                }
                else
                {
                    index = 0xFF;
                    return false;
                }
            }

            [Op]
            static sbyte BaseRegIndex(RuleOpName src)
                => src switch
                {
                    BASE0 => 0,
                    BASE1 => 1,
                    _ => -1,
                };

            [Op]
            static sbyte SegRegIndex(RuleOpName src)
                => src switch
                {
                    SEG0 => 0,
                    SEG1 => 1,
                    _ => -1,
                };

            [Op]
            static sbyte ImmIndex(RuleOpName src)
                => src switch
                {
                    IMM0 => 0,
                    IMM1 => 1,
                    _ => -1,
                };

            [Op]
            static sbyte MemIndex(RuleOpName src)
                => src switch
                {
                    MEM0 => 0,
                    MEM1 => 1,
                    _ => -1,
                };
        }
    }
}