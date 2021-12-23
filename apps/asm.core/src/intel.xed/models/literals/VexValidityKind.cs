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
            [Symbol("VV1", "VEXVALID=1")]
            VV1 = 1,

            /// <summary>
            /// VEXVALID=2
            /// </summary>
            [Symbol("EVV", "VEXVALID=2")]
            EVV = 2,
        }
    }
}