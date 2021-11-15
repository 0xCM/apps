//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Pow2x64;

    /// <summary>
    /// Classifies assembly text fragments
    /// </summary>
    [Flags]
    public enum AsmTextKind : ulong
    {
        None = 0,

        /// <summary>
        /// Indicates an op code representation such as '66 0F 3A 20 /r ib'
        /// </summary>
        OpCode = P2ᐞ01,

        /// <summary>
        /// Indicates an instruction signature such as 'AND r/m8, imm8'
        /// </summary>
        Sig = P2ᐞ02,

        /// <summary>
        /// Indicates an instruction mnemonic with operands
        /// </summary>
        Statement = P2ᐞ04,

        /// <summary>
        /// Indicates a text block of the form ;{content}
        /// </summary>
        Comment = P2ᐞ05,

        /// <summary>
        /// Indicates an instruction encoding rendered as a space-delimited sequence of hex bytes
        /// </summary>
        HexCode = P2ᐞ06,

        /// <summary>
        /// Indicates an instruction encoding rendered as a bitstring
        /// </summary>
        Bitstring = P2ᐞ07,

        /// <summary>
        /// Indicates a line with form {identifier}:
        /// </summary>
        Label = P2ᐞ08,

        /// <summary>
        /// Indicates a line that is consumed by an assembler
        /// </summary>
        Directive = P2ᐞ09,

        /// <summary>
        /// Indicates an Intel-specific encoding rule such as 'ModRM:r/m (r)'
        /// </summary>
        EncodingRule = P2ᐞ10,
    }
}