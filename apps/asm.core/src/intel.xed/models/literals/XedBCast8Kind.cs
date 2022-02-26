//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource("xed")]
        public enum XedBCast8Kind : byte
        {
            [Symbol("{1to16}", "BCAST=17")]
            BCast_1TO16_8 = 17, // 128

            [Symbol("{1to32}", "BCAST=18")]
            BCast_1TO32_8 = 18, // 256

            [Symbol("{1to64}", "BCAST=19")]
            BCast_1TO64_8 = 19, // 512

            [Symbol("{1to2}", "BCAST=23")]
            BCast_1TO2_8  = 23,

            [Symbol("{1to4}", "BCAST=24")]
            BCast_1TO4_8  = 24,

            [Symbol("{1to8}", "BCAST=25")]
            BCast_1TO8_8  = 25,
        }
    }
}