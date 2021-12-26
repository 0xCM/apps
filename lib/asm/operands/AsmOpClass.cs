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
        /// <summary>
        /// Unclassified
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies a register operand
        /// </summary>
        [Symbol("r", "Classifies a register operand")]
        R = P2ᐞ00,

        /// <summary>
        /// Classifies a memory operand
        /// </summary>
        [Symbol("m", "Classifies a memory operand")]
        M = P2ᐞ01,

        /// <summary>
        /// Classifies an immediate operand
        /// </summary>
        [Symbol("imm", "Classifies an immediate operand")]
        Imm = P2ᐞ02,

        [Symbol("r/m", "Classifies an operand that can refer to a register or memory location")]
        RM = R | M,
    }
}