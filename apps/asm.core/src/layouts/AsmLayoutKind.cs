//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Pow2x16;

    /// <summary>
    /// Classifies instruction layout segments
    /// </summary>
    public enum AsmLayoutKind : ushort
    {
        None = 0,

        Escape = P2ᐞ00,

        Legacy = P2ᐞ01,

        Rex = P2ᐞ03,

        Vex = P2ᐞ04,

        Evex = P2ᐞ05,

        OpCode = P2ᐞ06,

        ModRm = P2ᐞ07,

        Sib = P2ᐞ08,

        Imm = P2ᐞ09,

        Disp = P2ᐞ10,
    }
}