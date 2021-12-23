//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-state-bits.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(state)]
        public enum VectorLengthKind : byte
        {
            [Symbol("VL128", "VL=0")]
            VL128 = 0,

            [Symbol("VL256", "VL=1")]
            VL256 = 1,

            [Symbol("VL512", "VL=2")]
            VL512 = 2
        }
    }
}