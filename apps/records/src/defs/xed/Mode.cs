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
        public enum Mode : sbyte
        {
            [Symbol("mode16", "MODE=0")]
            Mode16 = 0,

            [Symbol("mode32", "MODE=1")]
            Mode32 = 1,

            [Symbol("mode64", "MODE=2")]
            Mode64 = 2,

            [Symbol("not64", "MODE!=2")]
            Not64 = 3,
        }
    }
}