//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = XedNames;

    partial struct XedModels
    {
        [SymSource("xed")]
        public enum BCast8Kind : byte
        {
            [Symbol(N.N1to16, "BCAST=17")]
            BCast_1TO16_8 = 17, // 128

            [Symbol(N.N1to32, "BCAST=18")]
            BCast_1TO32_8 = 18, // 256

            [Symbol(N.N1to64, "BCAST=19")]
            BCast_1TO64_8 = 19, // 512

            [Symbol(N.N1to2, "BCAST=23")]
            BCast_1TO2_8  = 23,

            [Symbol(N.N1to4, "BCAST=24")]
            BCast_1TO4_8  = 24,

            [Symbol(N.N1to8, "BCAST=25")]
            BCast_1TO8_8  = 25,
        }
    }
}