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
            [Symbol("ESRC=0")]
            XMM0,

            [Symbol("ESRC=1")]
            XMM1,

            [Symbol("ESRC=2")]
            XMM2,

            [Symbol("ESRC=3")]
            XMM3,

            [Symbol("ESRC=4")]
            XMM4,

            [Symbol("ESRC=5")]
            XMM5,

            [Symbol("ESRC=6")]
            XMM6,

            [Symbol("ESRC=7")]
            XMM7,

            [Symbol("ESRC=8")]
            XMM8,

            [Symbol("ESRC=9")]
            XMM9,

            [Symbol("ESRC=10")]
            XMM10,

            [Symbol("ESRC=11")]
            XMM11,

            [Symbol("ESRC=12")]
            XMM12,

            [Symbol("ESRC=13")]
            XMM13,

            [Symbol("ESRC=14")]
            XMM14,

            [Symbol("ESRC=15")]
            XMM15,


        }
    }
}