//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataWidth(5)]
        public enum BCastKind : byte
        {
            None = 0,

            BCast_1TO16_32 = 1, // 512

            BCast_4TO16_32 = 2, // 512

            BCast_1TO8_32 = 3, // 256

            BCast_4TO8_32 = 4, // 256

            BCast_1TO8_64 = 5, // 512

            BCast_4TO8_64 = 6, // 512

            BCast_2TO16_32 = 7, // 512

            BCast_2TO8_64 = 8, // 512

            BCast_8TO16_32 = 9, // 512

            BCast_1TO4_32 = 10, // 128

            BCast_1TO2_64 = 11, // 128

            BCast_2TO4_32 = 12, // 128

            BCast_1TO4_64 = 13, //256

            BCast_1TO8_16 = 14, // 128

            BCast_1TO16_16 = 15, // 256

            BCast_1TO32_16 = 16, // 512

            BCast_1TO16_8 = 17, // 128

            BCast_1TO32_8 = 18, // 256

            BCast_1TO64_8 = 19, // 512

            BCast_2TO4_64 = 20, // 256

            BCast_2TO8_32 = 21,   // 256

            BCast_1TO2_32 = 22,   // 128

            BCast_1TO2_8  = 23,

            BCast_1TO4_8  = 24,

            BCast_1TO8_8  = 25,

            BCast_1TO2_16  = 26,

            BCast_1TO4_16  = 27,
        }
    }
}