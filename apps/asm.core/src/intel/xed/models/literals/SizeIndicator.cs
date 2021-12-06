//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum SizeIndicator
        {
            None = 0,

            [Symbol("b", "Indicates an 8-bit operand")]
            b,

            [Symbol("d", "Indicates a 32-bit operand")]
            d,

            [Symbol("q", "Indicates a 64-bit operand")]
            q,

            [Symbol("ps", "Indicates a packed scalar single-precision floating point operand")]
            ps,

            [Symbol("pd", "Indicates a packed scalar double-precision floating point operand")]
            pd,

            [Symbol("dq", "Indicates a 128-bit quantity in memory or xmm register")]
            dq,

            [Symbol("qq", "Indicates a 256-bit quantity in memory or ymm register")]
            qq,

            [Symbol("v", "Indicates 16, 32 or 64-bit operands depending on the effective operand size")]
            v,

            [Symbol("v", "Indicates either 16 or 32-bit operation; when the effective operand size is 64, the operand is still 32 bits")]
            z,
        }
    }
}