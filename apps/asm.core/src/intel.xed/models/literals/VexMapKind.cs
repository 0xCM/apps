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
        public enum VexMapKind : byte
        {
            /// <summary>
            /// MAP=0
            /// </summary>
            [Symbol("V0", "MAP=0")]
            VEX_MAP0 = 0,

            /// <summary>
            /// MAP=1
            /// </summary>
            [Symbol(PS.V0F, "MAP=1")]
            VEX_MAP_0F = 1,

            /// <summary>
            /// MAP=2
            /// </summary>
            [Symbol(PS.V0F38, "MAP=2")]
            VEX_MAP_0F38 = 2,

            /// <summary>
            /// MAP=3
            /// </summary>
            [Symbol(PS.V0F3A, "MAP=3")]
            VEX_MAP_0F3A = 3
        }
    }
}