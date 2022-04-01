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
            [Symbol("ESRC0", "ESRC=0")]
            ESRC0,

            [Symbol("ESRC1","ESRC=1")]
            ESRC1,

            [Symbol("ESRC2","ESRC=2")]
            ESRC2,

            [Symbol("ESRC3","ESRC=3")]
            ESRC3,

            [Symbol("ESRC4","ESRC=4")]
            ESRC4,

            [Symbol("ESRC5","ESRC=5")]
            ESRC5,

            [Symbol("ESRC6","ESRC=6")]
            ESRC6,

            [Symbol("ESRC7","ESRC=7")]
            ESRC7,

            [Symbol("ESRC8","ESRC=8")]
            ESRC8,

            [Symbol("ESRC9","ESRC=9")]
            ESRC9,

            [Symbol("ESRC10","ESRC=10")]
            ESRC10,

            [Symbol("ESRC11","ESRC=11")]
            ESRC11,

            [Symbol("ESRC12","ESRC=12")]
            ESRC12,

            [Symbol("ESRC13","ESRC=13")]
            ESRC13,

            [Symbol("ESRC14","ESRC=14")]
            ESRC14,

            [Symbol("ESRC15","ESRC=15")]
            ESRC15,
        }
    }
}