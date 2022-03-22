//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = XedNames;

    partial struct XedModels
    {
        [SymSource(xed), DataWidth(3)]
        public enum VexDestKind : byte
        {
            None,

            [Symbol(N.NOVSR, "VEXDEST3=0b1 VEXDEST210=0b111")]
            NOVSR,

            [Symbol(N.NOEVSR, "VEXDEST3=0b1 VEXDEST210=0b111 VEXDEST4=0b0")]
            NOEVSR,

            [Symbol(N.NO_SPARSE_EVSR, "VEXDEST3=0b1 VEXDEST210=0b111")]
            NO_SPARSE_EVSR,
        }
    }
}