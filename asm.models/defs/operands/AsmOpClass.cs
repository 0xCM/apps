//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Pow2x8;

    [Flags]
    public enum AsmOpClass : byte
    {
        /// <summary>
        /// Unclassified
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies a register operand
        /// </summary>
        R = P2ᐞ00,

        /// <summary>
        /// Classifies a memory operand
        /// </summary>
        M = P2ᐞ01,

        /// <summary>
        /// Classifies an immediate operand
        /// </summary>
        Imm = P2ᐞ02,
    }
}