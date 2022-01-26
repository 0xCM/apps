//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Defines the bitfield index of the flags defined by <see cref='RFlagBits'/>
    /// </summary>
    [SymSource("asm.regs.flags")]
    public enum RFlagIndex : byte
    {
        CF = 0,

        PF = 2,

        AF = 4,

        ZF = 6,

        SF = 7,

        TF = 8,

        IF = 9,

        DF = 10,

        OF = 11,

        RF = 16,

        VM = 17,

        AC = 18,

        VIF = 19,

        VIP = 20,

        ID = 21,
    }
}