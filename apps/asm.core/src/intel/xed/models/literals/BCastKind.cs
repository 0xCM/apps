//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum BCast8Kind : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("{1to16}")]
            BCast_1TO16_8 = 17, // 128

            [Symbol("{1to32}")]
            BCast_1TO32_8 = 18, // 256

            [Symbol("{1to64}")]
            BCast_1TO64_8 = 19, // 512

            [Symbol("{1to2}")]
            BCast_1TO2_8  = 23,

            [Symbol("{1to4}")]
            BCast_1TO4_8  = 24,

            [Symbol("{1to8}")]
            BCast_1TO8_8  = 25,
        }

        [SymSource(xed)]
        public enum BCast16Kind : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("{1to8}")]
            BCast_1TO8_16 = 14, // 128

            [Symbol("{1to16}")]
            BCast_1TO16_16 = 15, // 256

            [Symbol("{1to32}")]
            BCast_1TO32_16 = 16, // 512

            [Symbol("{1to2}")]
            BCast_1TO2_16  = 26,

            [Symbol("{1to4}")]
            BCast_1TO4_16  = 27,
        }

        public enum BCast32Kind : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("{1to16}")]
            BCast_1TO16_32 = 1, // 512

            [Symbol("{4to16}")]
            BCast_4TO16_32 = 2, // 512

            [Symbol("{1to8}")]
            BCast_1TO8_32 = 3, // 256

            [Symbol("{4to8}")]
            BCast_4TO8_32 = 4, // 256

            [Symbol("{2to16}")]
            BCast_2TO16_32 = 7, // 512

            [Symbol("{8to16}")]
            BCast_8TO16_32 = 9, // 512

            [Symbol("{1to4}")]
            BCast_1TO4_32 = 10, // 128

            [Symbol("{2to4}")]
            BCast_2TO4_32 = 12, // 128

            [Symbol("{2to8}")]
            BCast_2TO8_32 = 21,   // 256

            [Symbol("{1to2}")]
            BCast_1TO2_32 = 22,   // 128
        }

        [SymSource(xed)]
        public enum BCast64Kind : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("{1to8}")]
            BCast_1TO8_64 = 5, // 512

            [Symbol("{4to8}")]
            BCast_4TO8_64 = 6, // 512

            [Symbol("{2to8}")]
            BCast_2TO8_64 = 8, // 512

            [Symbol("{1to2}")]
            BCast_1TO2_64 = 11, // 128

            [Symbol("{1to4}")]
            BCast_1TO4_64 = 13, //256

            [Symbol("{2to4}")]
            BCast_2TO4_64 = 20, // 256
        }
    }
}