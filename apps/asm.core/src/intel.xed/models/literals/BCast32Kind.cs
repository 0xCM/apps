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
        public enum BCast32Kind : byte
        {
            [Symbol("{1to16}", "BCAST=1")]
            BCast_1TO16_32 = 1, // 512

            [Symbol("{4to16}", "BCAST=2")]
            BCast_4TO16_32 = 2, // 512

            [Symbol("{1to8}", "BCAST=3")]
            BCast_1TO8_32 = 3, // 256

            [Symbol("{4to8}", "BCAST=4")]
            BCast_4TO8_32 = 4, // 256

            [Symbol("{2to16}", "BCAST=7")]
            BCast_2TO16_32 = 7, // 512

            [Symbol("{8to16}", "BCAST=9")]
            BCast_8TO16_32 = 9, // 512

            [Symbol("{1to4}", "BCAST=10")]
            BCast_1TO4_32 = 10, // 128

            [Symbol("{2to4}", "BCAST=12")]
            BCast_2TO4_32 = 12, // 128

            [Symbol("{2to8}", "BCAST=21")]
            BCast_2TO8_32 = 21,   // 256

            [Symbol("{1to2}", "BCAST=22")]
            BCast_1TO2_32 = 22,   // 128
        }
    }
}