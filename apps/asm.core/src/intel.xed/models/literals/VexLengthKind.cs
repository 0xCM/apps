//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-state-bits.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using PS = XedModels.VexPrefixSpecs;

    partial struct XedModels
    {
        [SymSource(state)]
        public enum VexLengthKind : byte
        {
            [Symbol(PS.VL128, "VL=0")]
            VL128 = 0,

            [Symbol(PS.VL256, "VL=1")]
            VL256 = 1,

            [Symbol(PS.VL512, "VL=2")]
            VL512 = 2
        }
    }
}