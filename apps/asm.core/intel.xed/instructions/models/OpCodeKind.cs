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

            [Symbol(S.B0)]
            Base00 = OpCodeClass.Base | (ushort)((byte)BaseMapKind.BaseMap0 << 8),

            [Symbol(S.B1)]
            Base0F = OpCodeClass.Base | (ushort)((byte)BaseMapKind.BaseMap1 << 8),

            [Symbol(S.B2)]
            Base0F38 = OpCodeClass.Base | (ushort)((byte)BaseMapKind.BaseMap2 << 8),

            [Symbol(S.B3)]
            Base0F3A = OpCodeClass.Base | (ushort)((byte)BaseMapKind.BaseMap3 << 8),

            [Symbol(S.D3)]
            Amd3DNow = OpCodeClass.Base | (ushort)((byte)BaseMapKind.Amd3dNow << 8),

            [Symbol(S.X8)]
            Xop8 = OpCodeClass.Xop | (ushort)((byte)XopMapKind.Xop8 << 8),

            [Symbol(S.X9)]
            Xop9 = OpCodeClass.Xop | (ushort)((byte)XopMapKind.Xop9 << 8),

            [Symbol(S.XA)]
            XopA = OpCodeClass.Xop | (ushort)((byte)XopMapKind.XopA << 8),

            [Symbol(S.V1)]
            Vex0F = OpCodeClass.Vex | (ushort)((byte)VexMapKind.VEX_MAP_0F << 8),

            [Symbol(S.V2)]
            Vex0F38 = OpCodeClass.Vex | (ushort)((byte)VexMapKind.VEX_MAP_0F38 << 8),

            [Symbol(S.V3)]
            Vex0F3A = OpCodeClass.Vex | (ushort)((byte)VexMapKind.VEX_MAP_0F3A << 8),

            [Symbol(S.E1)]
            Evex0F = OpCodeClass.Evex | (ushort)((byte)EvexMapKind.EVEX_MAP_0F << 8),

            [Symbol(S.E2)]
            Evex0F38 = OpCodeClass.Evex | (ushort)((byte)EvexMapKind.EVEX_MAP_0F38 << 8),

            [Symbol(S.E3)]
            Evex0F3A = OpCodeClass.Evex | (ushort)((byte)EvexMapKind.EVEX_MAP_0F3A << 8),
        }
    }
}