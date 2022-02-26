//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.OpCodeKind;

    using OCI = XedModels.OpCodeIndex;

    partial struct XedModels
    {
        [Op]
        public static OpCodeIndex ocindex(OpCodeKind kind)
            => kind switch
            {
                LEGACY_MAP0 => OCI.LegacyMap0,
                LEGACY_MAP1 => OCI.LegacyMap1,
                LEGACY_MAP2 => OCI.LegacyMap2,
                LEGACY_MAP3 => OCI.LegacyMap3,
                AMD_3DNOW => OCI.Amd3dNow,
                XOP8 => OCI.Xop8,
                XOP9 => OCI.Xop9,
                XOPA => OCI.XopA,
                VEX_MAP_0F => OCI.Vex0F,
                VEX_MAP_0F38 => OCI.Vex0F38,
                VEX_MAP_0F3A => OCI.Vex0F3A,
                EVEX_MAP_0F => OCI.Evex0F,
                EVEX_MAP_0F38 => OCI.Evex0F38,
                EVEX_MAP_0F3A => OCI.Evex0F3A,
                _ => OCI.Invalid,
            };
    }
}