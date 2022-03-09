//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-width-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum OpVisiblity : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("EXPL")]
            Explicit,

            [Symbol("IMPL")]
            Implicit,

            [Symbol("SUPP")]
            Suppressed,
        }

        [SymSource(xed)]
        public enum VisibilityKind : byte
        {
            [Symbol("")]
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