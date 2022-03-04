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
            [Symbol("Map0")]
            LegacyMap0 = 0,

            [Symbol("Map1")]
            LegacyMap1 = 1,

            [Symbol("Map2")]
            LegacyMap2 = 2,

            [Symbol("Map3")]
            LegacyMap3 = 3,

            [Symbol("Amd3D")]
            Amd3dNow = 4,

            [Symbol("Xop8")]
            Xop8 = 5,

            [Symbol("Xop9")]
            Xop9 = 6,

            [Symbol("XopA")]
            XopA = 7,

            [Symbol("Vex0F")]
            Vex0F = 8,

            [Symbol("Vex0F38")]
            Vex0F38 = 9,

            [Symbol("Vex0F3A")]
            Vex0F3A = 10,

            [Symbol("Evex0F")]
            Evex0F = 11,

            [Symbol("Evex0F38")]
            Evex0F38 = 12,

            [Symbol("Evex0F3A")]
            Evex0F3A = 13,
        }
    }
}