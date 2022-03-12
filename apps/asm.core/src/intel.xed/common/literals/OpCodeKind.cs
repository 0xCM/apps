//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum OpCodeKind : ushort
        {
            None = 0,

            [Symbol("LMap0")]
            LEGACY_00 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP0 << 8),

            [Symbol("LMap1")]
            LEGACY_0F = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP1 << 8),

            [Symbol("LMap2")]
            LEGACY_0F38 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP2 << 8),

            [Symbol("LMap3")]
            LEGACY_0F3A = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP3 << 8),

            [Symbol("3DNow")]
            AMD_3DNOW = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.AMD_3DNOW << 8),

            [Symbol("Xop8")]
            XOP8 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP8 << 8),

            [Symbol("Xop9")]
            XOP9 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP9 << 8),

            [Symbol("XopA")]
            XOPA = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOPA << 8),

            [Symbol("Vex0F")]
            VEX_0F = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F << 8),

            [Symbol("Vex0F38")]
            VEX_0F38 = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F38 << 8),

            [Symbol("Vex0F3A")]
            VEX_0F3A = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F3A << 8),

            [Symbol("Evex0F")]
            EVEX_0F = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F << 8),

            [Symbol("Evex0F38")]
            EVEX_0F38 = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F38 << 8),

            [Symbol("Evex0F3A")]
            EVEX_0F3A = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F3A << 8),
        }
    }
}