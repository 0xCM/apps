//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using I = RFlags.RFlagIndex;

    /// <summary>
    /// Defines indices into the <see cref='StatusFlagBits'/>
    /// </summary>
    public enum StatusFlagIndex : byte
    {
        CF = I.CF,

        PF = I.PF,

        AF = I.AF,

        ZF = I.ZF,

        SF = I.SF,

        OF = I.OF,
    }
}