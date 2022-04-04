//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(2)]
        public enum LLRC : byte
        {
            [Symbol("LLRC0", "LLRC=0")]
            LLRC0=0,

            [Symbol("LLRC1", "LLRC=1")]
            LLRC1=1,

            [Symbol("LLRC2", "LLRC=2")]
            LLRC2=2,

            [Symbol("LLRC3", "LLRC=3")]
            LLRC3=3
        }
    }
}