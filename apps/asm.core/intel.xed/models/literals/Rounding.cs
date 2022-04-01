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
        public enum ROUNDC : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("{rn-sae}","ROUNDC=1 => LLRC=0 & BCRC=1: Round to nearest, ties to even, suppress all exceptions")]
            RnSae = 1,

            [Symbol("{rd-sae}","ROUNDC=2 => LLRC=1 & BCRC=1: Round down (toward negative infinity), suppress all exceptions")]
            RdSae = 2,

            [Symbol("{ru-sae}","ROUNDC=3 => LLRC=2 & BCRC=1: Round up (toward positive infinity), suppress all exception")]
            RuSae = 3,

            [Symbol("{rz-sae}","ROUNDC=4 => LLRC=3 & BCRC=1: Round toward zero, suppress all exception")]
            RzSae = 4,
        }

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