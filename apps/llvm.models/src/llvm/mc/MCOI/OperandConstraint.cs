//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    using T = MCOI.OperandConstraint;


    partial struct MCOI
    {
        /// <summary>
        /// Operand constraints. These are encoded in 16 bits with one of the
        /// low-order 3 bits specifying that a constraint is present and the
        /// corresponding high-order hex digit specifying the constraint value.
        /// This allows for a maximum of 3 constraints.
        /// </summary>
        /// <remarks>
        /// From https://github.com/llvm/llvm-project/blob/68b9b769b510b9f5d3fe20e1f850ab829510673e/llvm/include/llvm/MC/MCInstrDesc.h
        /// </remarks>
        [SymSource(tokens)]
        public enum OperandConstraint : byte
        {
            [Symbol("","Must be allocated the same register as specified value")]
            TIED_TO = 0,

            [Symbol("","If present, operand is an early clobber register.")]
            EARLY_CLOBBER
        };

        public const byte TIED_TO = (byte)T.TIED_TO;

        public const byte EARLY_CLOBBER = (byte)T.EARLY_CLOBBER;
    }
}