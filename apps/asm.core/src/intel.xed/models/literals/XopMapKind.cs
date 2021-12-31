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
        public enum XopMapKind : byte
        {
            XOP8=8,

            XOP9=9,

            XOPA=10,
        }
    }
}