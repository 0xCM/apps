//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-iclass-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum LookupKind : byte
        {
            INVALID,

            ERROR,

            IMM,

            IMM_CONST,

            NT_LOOKUP_FN,

            NT_LOOKUP_FN2,

            NT_LOOKUP_FN4,

            REG,
        }
    }
}