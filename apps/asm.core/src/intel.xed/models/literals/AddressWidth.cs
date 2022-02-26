//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-address-width-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        const string xed = nameof(xed);

        const string xed_state = nameof(xed_state);

        [SymSource(xed)]
        public enum AddressWidth : byte
        {
            INVALID=0,

            [Symbol("16b", "16-bit addressing")]
            WIDTH_16b=2,

            [Symbol("32b", "32-bit addressing")]
            WIDTH_32b=4,

            [Symbol("64b", "64-bit addressing")]
            WIDTH_64b=8,
        }
    }
}