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

            [Symbol("Map0")]
            LEGACY_MAP0 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP0 << 8),

            [Symbol("Map1")]
            LEGACY_MAP1 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP1 << 8),

            [Symbol("Map2")]
            LEGACY_MAP2 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP2 << 8),

            [Symbol("Map3")]
            LEGACY_MAP3 = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.LEGACY_MAP3 << 8),

            [Symbol("Map3DNow")]
            AMD_3DNOW = OpCodeClass.LEGACY | (ushort)((byte)LegacyMapKind.AMD_3DNOW << 8),

            [Symbol("MapXop8")]
            XOP8 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP8 << 8),

            [Symbol("MapXop9")]
            XOP9 = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOP9 << 8),

            [Symbol("MapXopA")]
            XOPA = OpCodeClass.XOP | (ushort)((byte)XopMapKind.XOPA << 8),

            [Symbol("Vex0F")]
            VEX_MAP_0F = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F << 8),

            [Symbol("Vex0F38")]
            VEX_MAP_0F38 = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F38 << 8),

            [Symbol("Vex0F3A")]
            VEX_MAP_0F3A = OpCodeClass.VEX | (ushort)((byte)VexMapKind.VEX_MAP_0F3A << 8),

            [Symbol("Evex0F")]
            EVEX_MAP_0F = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F << 8),

            [Symbol("Evex0F38")]
            EVEX_MAP_0F38 = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F38 << 8),

            [Symbol("Evex0F3A")]
            EVEX_MAP_0F3A = OpCodeClass.EVEX | (ushort)((byte)EvexMapKind.EVEX_MAP_0F3A << 8),
        }
    }
}