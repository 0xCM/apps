//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Pow2x8;

    [Flags,SymSource("asm")]
    public enum AsmOpClass : byte
    {
        None = 0,

        [Symbol("r", "Classifies a register operand")]
        R = P2ᐞ00,

        [Symbol("m", "Classifies a memory operand")]
        M = P2ᐞ01,

        [Symbol("imm", "Classifies an immediate operand")]
        Imm = P2ᐞ02,

        [Symbol("disp", "Classifies a displacement operand")]
        Disp = P2ᐞ03,

        [Symbol("mask", "Classifies a regmask operand")]
        Mask = P2ᐞ04,
    }
}