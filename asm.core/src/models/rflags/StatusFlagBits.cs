//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using RF = RFlags.RFlagBits;

    [Flags,SymSource]
    public enum StatusFlagBits : ushort
    {
        [Symbol("cf", "Carry Flag")]
        CF = (ushort)RF.CF,

        [Symbol("pf", "Parity Flag")]
        PF = (ushort)RF.PF,

        [Symbol("af", "Aux Carry Flag")]
        AF = (ushort)RF.AF,

        [Symbol("zf", "Zero Flag")]
        ZF = (ushort)RF.ZF,

        [Symbol("sf", "Sign Flag")]
        SF = (ushort)RF.SF,

        [Symbol("of", "Overflow Flag")]
        OF = (ushort)RF.OF,
    }
}