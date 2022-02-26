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
        public enum XedBCast16Kind : byte
        {
            [Symbol("{1to8}", "BCAST=14")]
            BCast_1TO8_16 = 14, // 128

            [Symbol("{1to16}", "BCAST=15")]
            BCast_1TO16_16 = 15, // 256

            [Symbol("{1to32}", "BCAST=16")]
            BCast_1TO32_16 = 16, // 512

            [Symbol("{1to2}", "BCAST=26")]
            BCast_1TO2_16  = 26,

            [Symbol("{1to4}", "BCAST=27")]
            BCast_1TO4_16  = 27,
        }
    }
}