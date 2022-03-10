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
        [SymSource(xed_state), DataWidth(3)]
        public enum VexClass : byte
        {
            /// <summary>
            /// VEXVALID=0
            /// </summary>
            [Symbol(PS.VV0, "VEXVALID=0")]
            VV0 = 0,

            /// <summary>
            /// VEXVALID=1
            /// </summary>
            [Symbol(PS.VV1, "VEXVALID=1")]
            VV1 = 1,

            /// <summary>
            /// VEXVALID=2
            /// </summary>
            [Symbol(PS.EVV, "VEXVALID=2")]
            EVV = 2,

            /// <summary>
            /// VEXVALID=3
            /// </summary>
            [Symbol(PS.XOPV, "VEXVALID=3")]
            XOPV = 3,

            /// <summary>
            /// VEXVALID=4
            /// </summary>
            [Symbol(PS.KVV, "VEXVALID=4, KNC EVEX")]
            KVV = 4,
        }
    }
}