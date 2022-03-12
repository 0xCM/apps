//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using OCP = XedModels.OcPatternNames;

    partial struct XedModels
    {
        [SymSource(xed)]
        public enum LegacyMapKind : byte
        {
            [Symbol(OCP.LegacyMap0Name, EmptyString)]
            LEGACY_MAP0 = 0,

            [Symbol(OCP.LegacyMap1Name, OCP.LegacyPattern1)]
            LEGACY_MAP1 = 1,

            [Symbol(OCP.LegacyMap2Name, OCP.LegacyPattern2)]
            LEGACY_MAP2 = 2,

            [Symbol(OCP.LegacyMap3Name, OCP.LegacyPattern3)]
            LEGACY_MAP3 = 3,

            [Symbol("3DNow", OCP.Amd3dNowPattern)]
            AMD_3DNOW = 4,
        }
    }
}