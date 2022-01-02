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
        public enum VexValidityKind : byte
        {
            /// <summary>
            /// VEXVALID=0
            /// </summary>
            [Symbol("VV0", "VEXVALID=0")]
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