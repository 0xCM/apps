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
        [SymSource(xed)]
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