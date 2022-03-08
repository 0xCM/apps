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
        [SymSource(xed), DataWidth(3)]
        public enum VexDestKind : byte
        {
            None,

            [Symbol(PS.VEXDEST4)]
            VEXDEST4,

            [Symbol(PS.VEXDEST3)]
            VEXDEST3,

            [Symbol(PS.VEXDEST210)]
            VEXDEST210,

            /// <summary>
            /// VEXDEST3=0b1 VEXDEST210=0b111
            /// </summary>
            [Symbol(PS.NOVSR)]
            NOVSR,

            /// <summary>
            /// VEXDEST3=0b1 VEXDEST210=0b111 VEXDEST4=0b0
            /// </summary>
            [Symbol(PS.NOEVSR)]
            NOEVSR,

            /// <summary>
            /// VEXDEST3=0b1 VEXDEST210=0b111
            /// </summary>
            [Symbol(PS.NO_SPARSE_EVSR)]
            NO_SPARSE_EVSR,
        }
    }
}