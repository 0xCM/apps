//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.OpCodeKind;
    using static XedModels;

    using I = XedModels.OpCodeIndex;

    partial class XedRules
    {
        [Op]
        public static OpCodeKind ockind(OpCodeIndex src)
            => src switch {
                I.LegacyMap0 => LEGACY_00,
                I.LegacyMap1 => LEGACY_0F,
                I.LegacyMap2 => LEGACY_0F38,
                I.LegacyMap3 => LEGACY_0F3A,
                I.Amd3dNow => AMD_3DNOW,
                I.Xop8 => XOP8,
                I.Xop9 => XOP9,
                I.XopA => XOPA,
                I.Vex0F => VEX_0F,
                I.Vex0F38 => VEX_0F38,
                I.Vex0F3A => VEX_0F3A,
                I.Evex0F => EVEX_0F,
                I.Evex0F38 => EVEX_0F38,
                I.Evex0F3A => EVEX_0F3A,
                _=> OpCodeKind.None
            };
   }
}