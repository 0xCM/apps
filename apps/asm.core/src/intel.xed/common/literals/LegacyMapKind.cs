//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = XedNames;

    partial struct XedModels
    {
        [SymSource(xed)]
        public enum LegacyMapKind : byte
        {
            [Symbol(N.LegacyMap0Name)]
            LEGACY_MAP0 = 0,

            [Symbol(N.LegacyMap1Name)]
            LEGACY_MAP1 = 1,

            [Symbol(N.LegacyMap2Name)]
            LEGACY_MAP2 = 2,

            [Symbol(N.LegacyMap3Name)]
            LEGACY_MAP3 = 3,

            [Symbol(N.Amd3dMapName)]
            AMD_3DNOW = 4,
        }
    }
}