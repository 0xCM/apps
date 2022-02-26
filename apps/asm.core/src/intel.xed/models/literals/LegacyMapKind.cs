//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using OCP = XedModels.OcPatternNames;

    partial struct XedModels
    {
        [SymSource(xed)]
        public enum LegacyMapKind : byte
        {
            [Symbol("Map0", EmptyString)]
            LEGACY_MAP0 = 0,

            [Symbol("Map1", OCP.LegacyPattern1)]
            LEGACY_MAP1 = 1,

            [Symbol("Map2", OCP.LegacyPattern2)]
            LEGACY_MAP2 = 2,

            [Symbol("Map3", OCP.LegacyPattern3)]
            LEGACY_MAP3 = 3,

            [Symbol("Map3DNow", OCP.Amd3dNowPattern)]
            AMD_3DNOW = 4,
        }
    }
}