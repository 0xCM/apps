//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-address-width-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum AddressWidth : byte
        {
            None=0,

            [Symbol("16b", "16-bit addressing")]
            W16b=2,

            [Symbol("32b", "32-bit addressing")]
            W32b=4,

            [Symbol("64b", "64-bit addressing")]
            W64b=8,
        }
    }
}