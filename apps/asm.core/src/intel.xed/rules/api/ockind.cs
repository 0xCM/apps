//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.OpCodeKind;
    using static XedModels;

    using N = XedNames;
    using OCI = XedModels.OpCodeIndex;

    partial class XedRules
    {
        [Op]
        public static OpCodeKind ockind(OpCodeIndex src)
            => src switch {
                OCI.LegacyMap0 => LEGACY_00,
                OCI.LegacyMap1 => LEGACY_0F,
                OCI.LegacyMap2 => LEGACY_0F38,
                OCI.LegacyMap3 => LEGACY_0F3A,
                OCI.Amd3dNow => AMD_3DNOW,
                OCI.Xop8 => XOP8,
                OCI.Xop9 => XOP9,
                OCI.XopA => XOPA,
                OCI.Vex0F => VEX_0F,
                OCI.Vex0F38 => VEX_0F38,
                OCI.Vex0F3A => VEX_0F3A,
                OCI.Evex0F => EVEX_0F,
                OCI.Evex0F38 => EVEX_0F38,
                OCI.Evex0F3A => EVEX_0F3A,
                _=> OpCodeKind.None
            };
   }
}