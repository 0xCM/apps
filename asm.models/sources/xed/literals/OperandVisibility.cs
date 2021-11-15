//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-width-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum OperandVisibility : byte
        {
            INVALID,

            [Symbol("EXPLICIT","Shows up in operand encoding")]
            EXPLICIT,

            [Symbol("IMPLICIT","Part of the opcode, but listed as an operand")]
            IMPLICIT,

            [Symbol("SUPPRESSED", "Part of the opcode, but not typically listed as an operand")]
            SUPPRESSED,
        }
    }
}