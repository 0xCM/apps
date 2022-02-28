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
        public enum BCast64Kind : byte
        {
            [Symbol("{1to8}", "BCAST=5")]
            BCast_1TO8_64 = 5, // 512

            [Symbol("{4to8}", "BCAST=6")]
            BCast_4TO8_64 = 6, // 512

            [Symbol("{2to8}", "BCAST=8")]
            BCast_2TO8_64 = 8, // 512

            [Symbol("{1to2}", "BCAST=11")]
            BCast_1TO2_64 = 11, // 128

            [Symbol("{1to4}", "BCAST=13")]
            BCast_1TO4_64 = 13, //256

            [Symbol("{2to4}", "BCAST=20")]
            BCast_2TO4_64 = 20, // 256
        }
    }
}