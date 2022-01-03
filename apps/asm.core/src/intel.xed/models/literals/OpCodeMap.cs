//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-chip-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// From xed-mapu-enum.h
        /// </summary>
        [SymSource(xed)]
        public enum OpCodeMap : byte
        {
            [Symbol("AMD_3DNOW")]
            AMD_3DNOW = 1,

            [Symbol("AMD_XOP8")]
            AMD_XOP8 = 2,

            [Symbol("AMD_XOP9")]
            AMD_XOP9 = 3,

            [Symbol("AMD_XOPA")]
            AMD_XOPA = 4,

            [Symbol("EVEX_MAP1")]
            EVEX_MAP1 = 5,

            [Symbol("EVEX_MAP2")]
            EVEX_MAP2 = 6,

            [Symbol("EVEX_MAP3")]
            EVEX_MAP3 = 7,

            [Symbol("LEGACY_MAP0")]
            LEGACY_MAP0 = 8,

            [Symbol("LEGACY_MAP1")]
            LEGACY_MAP1 = 9,

            [Symbol("LEGACY_MAP2")]
            LEGACY_MAP2 = 10,

            [Symbol("LEGACY_MAP3")]
            LEGACY_MAP3 = 11,

            [Symbol("MAP=0")]
            MAP_VMAP0 = 0,

            [Symbol("MAP=1")]
            MAP_V0F = 12,

            [Symbol("VEX_MAP2")]
            MAP_V0F38 = 13,

            [Symbol("VEX_MAP3")]
            MAP_V0F3A = 14,
        }
    }
}