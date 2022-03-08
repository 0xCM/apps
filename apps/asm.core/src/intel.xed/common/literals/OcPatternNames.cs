//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct OcPatternNames
        {
            public const string LegacyMapClass = "LEGACY";

            public const string XopMapClass = "XOP";

            public const string XOPV = "XOPV";

            public const string VV1 = "VV1";

            public const string EVV = "EVV";

            public const string VexMapClass = VV1;

            public const string EvexMapClass = EVV;

            public const string LegacyPattern1 = "0x0F";

            public const string LegacyPattern2 = "0x0F 0x38";

            public const string LegacyPattern3 = "0x0F 0x3A";

            public const string Amd3dNowPattern = "0x0F 0x0F";

            public const string XopPattern8 = "XMAP8";

            public const string XopPattern9 = "XMAP9";

            public const string XopPatternA = "XMAPA";

            public const string VexPattern0F = "V0F";

            public const string VexPattern0F38 = "V0F38";

            public const string VexPattern0F3A = "V0F3A";

            public const string EvexPattern0F = "V0F";

            public const string EvexPattern0F38 = "V0F38";

            public const string EvexPattern0F3A = "V0F3A";
        }
    }
}