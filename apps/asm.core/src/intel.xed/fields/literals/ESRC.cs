//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(3)]
        public enum ESRC : byte
        {
            [Symbol("xmm0", "ESRC=0")]
            XMM0,

            [Symbol("xmm1","ESRC=1")]
            XMM1,

            [Symbol("xmm2","ESRC=2")]
            XMM2,

            [Symbol("xmm3","ESRC=3")]
            XMM3,

            [Symbol("xmm4","ESRC=4")]
            XMM4,

            [Symbol("xmm5","ESRC=5")]
            XMM5,

            [Symbol("xmm6","ESRC=6")]
            XMM6,

            [Symbol("xmm7","ESRC=7")]
            XMM7,

            [Symbol("xmm8","ESRC=8")]
            XMM8,

            [Symbol("xmm9","ESRC=9")]
            XMM9,

            [Symbol("xmm10","ESRC=10")]
            XMM10,

            [Symbol("xmm11","ESRC=11")]
            XMM11,

            [Symbol("xmm12","ESRC=12")]
            XMM12,

            [Symbol("xmm13","ESRC=13")]
            XMM13,

            [Symbol("xmm14","ESRC=14")]
            XMM14,

            [Symbol("xmm15","ESRC=15")]
            XMM15,
        }
    }
}