//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-chip-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum OpCodeMap : byte
        {
            None,

            AMD_3DNOW,

            AMD_XOP8,

            AMD_XOP9,

            AMD_XOPA,

            EVEX_MAP1,

            EVEX_MAP2,

            EVEX_MAP3,

            LEGACY_MAP0,

            LEGACY_MAP1,

            LEGACY_MAP2,

            LEGACY_MAP3,

            VEX_MAP1,

            VEX_MAP2,

            VEX_MAP3,
        }
    }
}