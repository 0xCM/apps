//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [SymSource(xed)]
        public enum OpName : byte
        {
            None = 0,

            REG0,

            REG1,

            REG2,

            REG3,

            REG4,

            REG5,

            REG6,

            REG7,

            REG8,

            REG9,

            MEM0,

            MEM1,

            IMM0,

            IMM1,

            IMM2,

            RELBR,

            BASE0,

            BASE1,

            SEG0,

            SEG1,

            AGEN,

            PTR,

            INDEX,

            SCALE,

            DISP,
        }
    }
}