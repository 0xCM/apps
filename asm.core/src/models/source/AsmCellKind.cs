//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Pow2x32;

    /// <summary>
    /// Classifies supported asm cells
    /// </summary>
    [Flags]
    public enum AsmCellKind : uint
    {
        None = 0,

        /// <summary>
        /// An sequence number
        /// </summary>
        Sequence = P2ᐞ00,

        /// <summary>
        /// An global-relative instruction offset
        /// </summary>
        GlobalOffset = P2ᐞ01,

        /// <summary>
        /// A host block address
        /// </summary>
        BlockAddress = P2ᐞ02,

        /// <summary>
        /// An instruction pointer
        /// </summary>
        IP = P2ᐞ03,

        /// <summary>
        /// A block-relative instruction offset
        /// </summary>
        BlockOffset = P2ᐞ04,

        /// <summary>
        /// An instruction statement
        /// </summary>
        Statement = P2ᐞ05,

        /// <summary>
        /// Instruction encoding represented as a sequence of hex bytes
        /// </summary>
        EncodedBytes = P2ᐞ06,

        /// <summary>
        /// An instruction signature
        /// </summary>
        FormSig = P2ᐞ07,

        /// <summary>
        /// An instruction opcode
        /// </summary>
        OpCode = P2ᐞ08,

        /// <summary>
        /// Instruction encoding represented as a bitstring
        /// </summary>
        Bitstring = P2ᐞ09,

        /// <summary>
        /// An operation uri
        /// </summary>
        OpUri = P2ᐞ10,
    }

}