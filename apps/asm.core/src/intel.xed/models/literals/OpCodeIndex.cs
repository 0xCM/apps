//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum OpCodeIndex : sbyte
        {
            Invalid = -1,

            LegacyMap0 = 0,

            LegacyMap1 = 1,

            LegacyMap2 = 2,

            LegacyMap3 = 3,

            Amd3dNow = 4,

            Xop8 = 5,

            Xop9 = 6,

            XopA = 7,

            Vex0F = 8,

            Vex0F38 = 9,

            Vex0F3A = 10,

            Evex0F = 11,

            Evex0F38 = 12,

            Evex0F3A = 13,
        }
    }
}