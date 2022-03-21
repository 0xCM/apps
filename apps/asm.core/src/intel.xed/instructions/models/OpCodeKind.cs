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
        public enum OpCodeKind : ushort
        {
            None = 0,

            [Symbol(N.LegacyMap0Name)]
            LEGACY_00 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP0 << 8),

            [Symbol(N.LegacyMap1Name)]
            LEGACY_0F = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP1 << 8),

            [Symbol(N.LegacyMap2Name)]
            LEGACY_0F38 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP2 << 8),

            [Symbol(N.LegacyMap3Name)]
            LEGACY_0F3A = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP3 << 8),

            [Symbol(N.Amd3dMapName)]
            AMD_3DNOW = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.AMD_3DNOW << 8),

            [Symbol(N.XopMap8Name)]
            XOP8 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP8 << 8),

            [Symbol(N.XopMap9Name)]
            XOP9 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP9 << 8),

            [Symbol(N.XopMapAName)]
            XOPA = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOPA << 8),

            [Symbol(N.VexMap1Name)]
            VEX_0F = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F << 8),

            [Symbol(N.VexMap2Name)]
            VEX_0F38 = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F38 << 8),

            [Symbol(N.VexMap3Name)]
            VEX_0F3A = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F3A << 8),

            [Symbol(N.EvexMap1Name)]
            EVEX_0F = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F << 8),

            [Symbol(N.EvexMap2Name)]
            EVEX_0F38 = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F38 << 8),

            [Symbol(N.EvexMap3Name)]
            EVEX_0F3A = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F3A << 8),
        }
    }
}