//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        [SymSource(xed), DataWidth(1)]
        public enum ZEROING : byte
        {
            [Symbol("")]
            Disabled = 0,

            [Symbol("{z}")]
            Enabled = 1,
        }

        [SymSource(xed), DataWidth(2)]
        public enum MASK : byte
        {
            [Symbol("k0","MASK=0")]
            K0 = RegIndexCode.r0,

            [Symbol("k1","MASK=1")]
            K1 = RegIndexCode.r1,

            [Symbol("k2","MASK=2")]
            K2 = RegIndexCode.r2,

            [Symbol("k3","MASK=3")]
            K3 = RegIndexCode.r3,

            [Symbol("k4","MASK=4")]
            K4 = RegIndexCode.r4,

            [Symbol("k5","MASK=5")]
            K5 = RegIndexCode.r5,

            [Symbol("k6","MASK=6")]
            K6 = RegIndexCode.r6,

            [Symbol("k7","MASK=7")]
            K7 = RegIndexCode.r7,
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

        [SymSource(xed), DataWidth(1)]
        public enum BCRC : byte
        {
            [Symbol("BCRC0", "BCRC=0")]
            BCRC0 = 0,

            [Symbol("BCRC1", "BCRC=1")]
            BCRC1 = 1
        }

        [SymSource(xed), DataWidth(3)]
        public enum ROUNDC : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("{rn-sae}","ROUNDC=1 => LLRC=0 BCRC=1: Round to nearest, ties to even, suppress all exceptions")]
            RnSae = 1,

            [Symbol("{rd-sae}","ROUNDC=2 => LLRC=1 BCRC=1: Round down (toward negative infinity), suppress all exceptions")]
            RdSae = 2,

            [Symbol("{ru-sae}","ROUNDC=3 => LLRC=2 BCRC=1: Round up (toward positive infinity), suppress all exception")]
            RuSae = 3,

            [Symbol("{rz-sae}","ROUNDC=4 => LLRC=3 BCRC=1: Round toward zero, suppress all exception")]
            RzSae = 4,
        }
    }
}
