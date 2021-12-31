//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-state-bits.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(state, NumericBaseKind.Base2)]
        public enum VexPrefixKind : byte
        {
            /// <summary>
            /// VEX_PREFIX=0
            /// </summary>
            [Symbol("VNP", "VEX_PREFIX=0")]
            VNP = 0,

            /// <summary>
            /// VEX_PREFIX=1
            /// </summary>
            [Symbol("V66", "VEX_PREFIX=1")]
            V66 = 1,

            /// <summary>
            /// VEX_PREFIX=2
            /// </summary>
            [Symbol("VF2", "VEX_PREFIX=2")]
            VF2 = 2,

            /// <summary>
            /// VEX_PREFIX=3
            /// </summary>
            [Symbol("VF3", "VEX_PREFIX=3")]
            VF3 = 3
        }
    }
}