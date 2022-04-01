//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum FpuRegId : ushort
        {
            [Symbol("ST(0)")]
            ST0 = XedRegId.ST0,

            [Symbol("ST(1)")]
            ST1 = XedRegId.ST1,

            [Symbol("ST(2)")]
            ST2 = XedRegId.ST2,

            [Symbol("ST(3)")]
            ST3 = XedRegId.ST3,

            [Symbol("ST(4)")]
            ST4 = XedRegId.ST4,

            [Symbol("ST(5)")]
            ST5 = XedRegId.ST5,

            [Symbol("ST(6)")]
            ST6 = XedRegId.ST6,

            [Symbol("ST(7)")]
            ST7 = XedRegId.ST7,
        }
    }
}