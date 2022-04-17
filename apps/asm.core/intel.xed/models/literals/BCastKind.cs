//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using BK = XedModels.BCastKind;

    partial struct XedModels
    {
        [DataWidth(5)]
        public enum BCastKind : byte
        {
            None = 0,

            BCast_1TO16_32 = BCast32Kind.BCast_1TO16_32,

            BCast_4TO16_32 = BCast32Kind.BCast_4TO16_32,

            BCast_1TO8_32 = BCast32Kind.BCast_1TO8_32,

            BCast_4TO8_32 = BCast32Kind.BCast_4TO8_32,

            BCast_1TO8_64 = BCast64Kind.BCast_1TO8_64,

            BCast_4TO8_64 = BCast64Kind.BCast_4TO8_64,

            BCast_2TO16_32 = 7,

            BCast_2TO8_64 = 8,

            BCast_8TO16_32 = 9,

            BCast_1TO4_32 = 10,

            BCast_1TO2_64 = 11,

            BCast_2TO4_32 = 12,

            BCast_1TO4_64 = 13,

            BCast_1TO8_16 = 14,

            BCast_1TO16_16 = BCast16Kind.BCast_1TO16_16,

            BCast_1TO32_16 = 16,

            BCast_1TO16_8 = BCast8Kind.BCast_1TO16_8,

            BCast_1TO32_8 = 18,

            BCast_1TO64_8 = BCast8Kind.BCast_1TO64_8,

            BCast_2TO4_64 = 20,

            BCast_2TO8_32 = 21,

            BCast_1TO2_32 = 22,

            BCast_1TO2_8  = 23,

            BCast_1TO4_8  = 24,

            BCast_1TO8_8  = BCast8Kind.BCast_1TO8_8,

            BCast_1TO2_16  = 26,

            BCast_1TO4_16  = 27,
        }

        public enum EMX_BROADCAST_KIND : byte
        {
            EMX_BROADCAST_1TO4_32 = BK.BCast_1TO4_32,

            EMX_BROADCAST_1TO4_64 = BK.BCast_1TO4_64,

            EMX_BROADCAST_1TO8_32 = BK.BCast_1TO8_32,

            EMX_BROADCAST_2TO4_64 = BK.BCast_2TO4_64,

            EMX_BROADCAST_1TO2_64 = BK.BCast_1TO2_64,

            EMX_BROADCAST_1TO8_16 = BK.BCast_1TO8_16,

            EMX_BROADCAST_1TO16_16 = BK.BCast_1TO16_16,

            EMX_BROADCAST_1TO16_8 = BK.BCast_1TO16_8,

            EMX_BROADCAST_1TO32_8 = BK.BCast_1TO32_8,

            EMX_BROADCAST_1TO16_32 = BK.BCast_1TO16_32,

            EMX_BROADCAST_4TO16_32 = BK.BCast_4TO16_32,

            EMX_BROADCAST_1TO8_64 = BK.BCast_1TO8_64,

            EMX_BROADCAST_4TO8_64 = BK.BCast_4TO8_64,

            EMX_BROADCAST_2TO16_32 = BK.BCast_2TO16_32,

            EMX_BROADCAST_2TO8_64 = BK.BCast_2TO8_64,

            EMX_BROADCAST_8TO16_32 = BK.BCast_8TO16_32,

            EMX_BROADCAST_1TO32_16 = BK.BCast_1TO32_16,

            EMX_BROADCAST_1TO64_8 = BK.BCast_1TO64_8,

            EMX_BROADCAST_4TO8_32 = BK.BCast_4TO8_32,

            EMX_BROADCAST_2TO4_32 = BK.BCast_2TO4_32,

            EMX_BROADCAST_2TO8_32 = BK.BCast_2TO8_32,

            EMX_BROADCAST_1TO2_32 = BK.BCast_1TO2_32,

            EMX_BROADCAST_1TO2_8 = BK.BCast_1TO2_8,

            EMX_BROADCAST_1TO4_8 = BK.BCast_1TO4_8,

            EMX_BROADCAST_1TO8_8 = BK.BCast_1TO8_8,

            EMX_BROADCAST_1TO2_16 = BK.BCast_1TO2_16,

            EMX_BROADCAST_1TO4_16 = BK.BCast_1TO4_16,
        }
    }
}