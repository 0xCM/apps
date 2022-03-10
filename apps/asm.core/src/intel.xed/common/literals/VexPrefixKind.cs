//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using PS = XedModels.VexPrefixSpecs;

    partial struct XedModels
    {
        [SymSource(xed_state), DataWidth(2)]
        public enum VexKind : byte
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