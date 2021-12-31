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
        public enum LegacyMapKind : byte
        {
            LEGACY_MAP0=0,

            LEGACY_MAP1=1,

            LEGACY_MAP2=2,

            LEGACY_MAP3=3,
        }
    }
}