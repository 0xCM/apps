//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-chip-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum OpCodeMapOverlap : byte
        {
            AMD_3DNOW=4,

            AMD_XOP8=8,

            AMD_XOP9=9,

            AMD_XOPA=10,

            EVEX_MAP1=1,

            EVEX_MAP2=2,

            EVEX_MAP3=3,

            LEGACY_MAP0=0,

            LEGACY_MAP1=1,

            LEGACY_MAP2=2,

            LEGACY_MAP3=3,

            VEX_MAP1=1,

            VEX_MAP2=2,

            VEX_MAP3=3,
        }
    }
}