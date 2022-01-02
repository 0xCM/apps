//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum RuleOpKind : byte
        {
            None = 0,

            REG0 = 1,

            REG1 = 2,

            REG2 = 3,

            REG3 = 4,

            REG4 = 5,

            REG5 = 6,

            REG6 = 7,

            REG7 = 8,

            REG8 = 9,

            MEM0 = 10,

            MEM1 = 11,

            IMM0 = 12,

            IMM1 = 13,

            IMM2 = 14,

            RELBR = 15,

            BASE0 = 16,

            BASE1 = 17,

            SEG0 = 18,

            SEG1 = 19,

            AGEN = 20,

            PTR,

            INDEX,

            SCALE,
        }
    }
}