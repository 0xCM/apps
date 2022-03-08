//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.OpCodeKind;

    using I = XedModels.OpCodeIndex;

    partial class XedRules
    {
        [Op]
        public static OpCodeIndex ocindex(OpCodeKind kind)
            => kind switch
            {
                LEGACY_MAP0 => I.LegacyMap0,
                LEGACY_MAP1 => I.LegacyMap1,
                LEGACY_MAP2 => I.LegacyMap2,
                LEGACY_MAP3 => I.LegacyMap3,
                AMD_3DNOW => I.Amd3dNow,
                XOP8 => I.Xop8,
                XOP9 => I.Xop9,
                XOPA => I.XopA,
                VEX_MAP_0F => I.Vex0F,
                VEX_MAP_0F38 => I.Vex0F38,
                VEX_MAP_0F3A => I.Vex0F3A,
                EVEX_MAP_0F => I.Evex0F,
                EVEX_MAP_0F38 => I.Evex0F38,
                EVEX_MAP_0F3A => I.Evex0F3A,
                _ => 0
            };
    }
}