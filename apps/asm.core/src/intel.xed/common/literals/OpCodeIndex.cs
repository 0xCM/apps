//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using OCP = XedModels.OcPatternNames;

    partial struct XedModels
    {
        public enum OpCodeIndex : sbyte
        {
            [Symbol(OCP.LegacyMap0Name)]
            LegacyMap0 = 0,

            [Symbol(OCP.LegacyMap1Name, "0x0F")]
            LegacyMap1 = 1,

            [Symbol(OCP.LegacyMap2Name, "0x0F 0x38")]
            LegacyMap2 = 2,

            [Symbol(OCP.LegacyMap3Name, "0x0F 0x3A")]
            LegacyMap3 = 3,

            [Symbol(OCP.Amd3dName, "0x0F 0x0F")]
            Amd3dNow = 4,

            [Symbol(OCP.Xop8Name)]
            Xop8 = 5,

            [Symbol(OCP.Xop9Name)]
            Xop9 = 6,

            [Symbol(OCP.XopAName)]
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