//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedRecords
    {
        [SymSource(xed_state)]
        public enum Mode64WidthDefault : byte
        {
            [Symbol("nrmw", "DF64=0")]
            NRMW = 0,

            [Symbol("df64", "DF64=1")]
            DF64 = 1,
        }
    }
}