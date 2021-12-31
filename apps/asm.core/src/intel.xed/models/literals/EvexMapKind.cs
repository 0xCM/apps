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
        public enum EvexMapKind : byte
        {
            EVEX_MAP1=1,

            EVEX_MAP2=2,

            EVEX_MAP3=3,
        }
    }
}