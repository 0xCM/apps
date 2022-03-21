//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;

    partial class XedFields
    {
        [Op]
        public static XedRegId reg(in RuleState src, byte index, bit sreg = default)
            =>
            index switch
            {
                0 => sreg ? src.SEG0 : src.REG0,
                1 => sreg ? src.SEG1 : src.REG1,
                2 => src.REG2,
                3 => src.REG3,
                4 => src.REG4,
                5 => src.REG5,
                6 => src.REG6,
                7 => src.REG7,
                8 => src.REG8,
                9 => src.REG9,

                _ => XedRegId.INVALID
            };
    }
}