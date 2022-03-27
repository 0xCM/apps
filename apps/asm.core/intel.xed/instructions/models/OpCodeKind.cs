//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = XedPatterns.OpCodeSymbols;

    partial struct XedModels
    {
        [SymSource(xed)]
        public enum OpCodeKind : ushort
        {
            None = 0,

            [Symbol(S.L0)]
            LEGACY_00 = OpCodeClass.Legacy | (ushort)((byte)LegacyMapKind.LEGACY_MAP0 << 8),

            [Symbol(S.L1)]
            LEGACY_0F = OpCodeClass.Legacy | (ushort)((byte)LegacyMapKind.LEGACY_MAP1 << 8),

            [Symbol(S.L2)]
            LEGACY_0F38 = OpCodeClass.Legacy | (ushort)((byte)LegacyMapKind.LEGACY_MAP2 << 8),

            [Symbol(S.L3)]
            LEGACY_0F3A = OpCodeClass.Legacy | (ushort)((byte)LegacyMapKind.LEGACY_MAP3 << 8),

            [Symbol(S.D3)]
            AMD_3DNOW = OpCodeClass.Legacy | (ushort)((byte)LegacyMapKind.AMD_3DNOW << 8),

            [Symbol(S.X8)]
            XOP8 = OpCodeClass.Xop | (ushort)((byte)XopMapKind.XOP8 << 8),

            [Symbol(S.X9)]
            XOP9 = OpCodeClass.Xop | (ushort)((byte)XopMapKind.XOP9 << 8),

            [Symbol(S.XA)]
            XOPA = OpCodeClass.Xop | (ushort)((byte)XopMapKind.XOPA << 8),

            [Symbol(S.V1)]
            VEX_0F = OpCodeClass.Vex | (ushort)((byte)VexMapKind.VEX_MAP_0F << 8),

            [Symbol(S.V2)]
            VEX_0F38 = OpCodeClass.Vex | (ushort)((byte)VexMapKind.VEX_MAP_0F38 << 8),

            [Symbol(S.V3)]
            VEX_0F3A = OpCodeClass.Vex | (ushort)((byte)VexMapKind.VEX_MAP_0F3A << 8),

            [Symbol(S.E1)]
            EVEX_0F = OpCodeClass.Evex | (ushort)((byte)EvexMapKind.EVEX_MAP_0F << 8),

            [Symbol(S.E2)]
            EVEX_0F38 = OpCodeClass.Evex | (ushort)((byte)EvexMapKind.EVEX_MAP_0F38 << 8),

            [Symbol(S.E3)]
            EVEX_0F3A = OpCodeClass.Evex | (ushort)((byte)EvexMapKind.EVEX_MAP_0F3A << 8),
        }
    }
}