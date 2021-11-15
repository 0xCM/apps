//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmAlgorithms
    {
        [SymSource]
        public enum Identifier : byte
        {
            None = 0,

            /// <summary>
            /// Represents an instruction operand-size attribute (16, 32 or 64-bits)
            /// </summary>
            [Symbol("OperandSize", "Represents an instruction operand-size attribute (16, 32 or 64-bits)")]
            OperandSize,

            /// <summary>
            /// Represents an instruction address-size attribute (16, 32 or 64-bits)
            /// </summary>
            [Symbol("AddressSize", "Represents an instruction address-size attribute (16, 32 or 64-bits)")]
            AddressSize,

            /// <summary>
            /// Represents the stack address-size attribute associated with the instruction (16, 32 or 64-bits)
            /// </summary>
            [Symbol("StackAddrSize", "Represents the stack address-size attribute associated with the instruction (16, 32 or 64-bits)   ")]
            StackAddrSize,

            /// <summary>
            /// Represents a source operand
            /// </summary>
            [Symbol("SRC", "Represents a source operand")]
            SRC,

            /// <summary>
            /// Represents a target operand
            /// </summary>
            [Symbol("DEST", "Represents a target operand")]
            DEST,

            /// <summary>
            /// Represents the maximum vector register width pertaining to the instruction.
            /// This is not the vector-length encoding in the instruction's encoding but is
            /// instead determined by the current value of XCR0. Future processors may define
            /// new bits in XCR0 whose setting may imply other values for MAXVL.
            /// </summary>
            [Symbol("MAXVL", "Represents the maximum vector register width pertaining to the instruction, as determined by the current value of XCR0")]
            MAXVL
        }
    }
}