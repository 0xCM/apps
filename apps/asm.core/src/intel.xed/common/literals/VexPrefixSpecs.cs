//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [LiteralProvider("xed.vex")]
        public readonly struct VexPrefixSpecs
        {
            public const string VV0 = nameof(VV0);

            public const string VV1 = nameof(VV1);

            public const string EVV = nameof(EVV);

            public const string XOPV = nameof(XOPV);

            public const string KVV = nameof(KVV);

            public const string VexValidity = "VV1 | EVV | XOPV | KVV";

            public const string VL128 = nameof(VL128);

            public const string VL256 = nameof(VL256);

            public const string VL512 = nameof(VL512);

            public const string VexLength = "VL128 | VL256 | VL512";

            public const string VNP = nameof(VNP);

            public const string V66 = nameof(V66);

            public const string VF2 = nameof(VF2);

            public const string VF3 = nameof(VF3);

            public const string VexKind = "VNP | V66 | VF2 | VF3";

            public const string V0F = nameof(V0F);

            public const string V0F38 = nameof(V0F38);

            public const string V0F3A = nameof(V0F3A);

            public const string VexMap = "V0F | V0F38 | V0F3A";

            public const string VEXDEST4 = nameof(VEXDEST4);

            public const string VEXDEST3 = nameof(VEXDEST3);

            public const string VEXDEST210 = nameof(VEXDEST210);

            public const string NOVSR = nameof(NOVSR);

            public const string NOEVSR = nameof(NOEVSR);

            public const string NO_SPARSE_EVSR = nameof(NO_SPARSE_EVSR);
        }
    }
}