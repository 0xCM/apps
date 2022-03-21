//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = XedNames;

    partial struct XedModels
    {
        [SymSource(xed)]
        public enum OpCodeIndex : sbyte
        {
            [Symbol(N.LegacyMap0Name)]
            LegacyMap0 = 0,

            [Symbol(N.LegacyMap1Name, "0x0F")]
            LegacyMap1 = 1,

            [Symbol(N.LegacyMap2Name, "0x0F 0x38")]
            LegacyMap2 = 2,

            [Symbol(N.LegacyMap3Name, "0x0F 0x3A")]
            LegacyMap3 = 3,

            [Symbol(N.Amd3dMapName, "0x0F 0x0F")]
            Amd3dNow = 4,

            [Symbol(N.XopMap8Name)]
            Xop8 = 5,

            [Symbol(N.XopMap9Name)]
            Xop9 = 6,

            [Symbol(N.XopMapAName)]
            XopA = 7,

            [Symbol(N.VexMap1Name, "0x0F")]
            Vex0F = 8,

            [Symbol(N.VexMap2Name, "0x0F 0x38")]
            Vex0F38 = 9,

            [Symbol(N.VexMap3Name, "0x0F 0x3A")]
            Vex0F3A = 10,

            [Symbol(N.EvexMap1Name, "0x0F")]
            Evex0F = 11,

            [Symbol(N.EvexMap2Name, "0x0F 0x38")]
            Evex0F38 = 12,

            [Symbol(N.EvexMap3Name, "0x0F 0x3A")]
            Evex0F3A = 13,
        }
    }
}