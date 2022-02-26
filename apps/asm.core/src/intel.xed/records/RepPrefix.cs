//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-reg-role-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed_state)]
        public enum RepPrefix : byte
        {
            None = 0,

            [Symbol("F2")]
            REPF2 = 2,

            [Symbol("F3")]
            REPF3 = 3,
        }
    }
}