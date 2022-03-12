//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.OpCodeKind;
    using static XedModels;

    using OCP = XedModels.OcPatternNames;
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

        public static OpCodeKind ockind(string rule)
        {
            var content = rule;
            var i = NotFound;
            i = text.index(content, OCP.VexMapClass);
            if(i >= 0)
            {
                i = text.index(content, OCP.VexPattern0F38);
                if(i>=0)
                    return VEX_0F38;

                i = text.index(content, OCP.VexPattern0F3A);
                if(i>=0)
                    return VEX_0F3A;

                i = text.index(content, OCP.VexPattern0F);
                if(i>=0)
                    return VEX_0F;

                return 0;
            }

            i = text.index(content, OCP.EvexMapClass);
            if(i >= 0)
            {
                i = text.index(content, OCP.EvexPattern0F38);
                if(i>=0)
                    return EVEX_0F38;

                i = text.index(content, OCP.EvexPattern0F3A);
                if(i>=0)
                    return EVEX_0F3A;

                i = text.index(content, OCP.EvexPattern0F);
                if(i>=0)
                    return EVEX_0F;

                return 0;
            }

            i = text.index(content, OCP.LegacyPattern2);
            if(i >= 0)
                return LEGACY_0F38;

            i = text.index(content, OCP.LegacyPattern3);
            if(i >= 0)
                return LEGACY_0F3A;

            i = text.index(content, OCP.Amd3dNowPattern);
            if(i >= 0)
                return AMD_3DNOW;

            i = text.index(content, OCP.LegacyPattern1);
            if(i >= 0)
                return LEGACY_0F;

            i = text.index(content, OCP.XopPattern8);
            if(i >= 0)
                return XOP8;

            i = text.index(content, OCP.XopPattern9);
            if(i >= 0)
                return XOP9;

            i = text.index(content, OCP.XopPatternA);
            if(i >= 0)
                return XOPA;

            return LEGACY_00;
        }
    }
}