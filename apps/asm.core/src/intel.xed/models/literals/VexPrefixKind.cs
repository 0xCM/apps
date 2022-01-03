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
        [SymSource(state, NumericBaseKind.Base2), DataWidth(2)]
        public enum VexPrefixKind : byte
        {
            /// <summary>
            /// VEX_PREFIX=0
            /// </summary>
            [Symbol(PS.VNP, "VEX_PREFIX=0")]
            VNP = 0,

            /// <summary>
            /// VEX_PREFIX=1
            /// </summary>
            [Symbol(PS.V66, "VEX_PREFIX=1")]
            V66 = 1,

            /// <summary>
            /// VEX_PREFIX=2
            /// </summary>
            [Symbol(PS.VF2, "VEX_PREFIX=2")]
            VF2 = 2,

            /// <summary>
            /// VEX_PREFIX=3
            /// </summary>
            [Symbol(PS.VF3, "VEX_PREFIX=3")]
            VF3 = 3
        }
    }
}