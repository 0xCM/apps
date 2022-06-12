//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    using T = MCOI.OperandFlags;

    partial struct MCOI
    {
        /// <summary>
        /// These are flags set on operands, but should be considered
        /// private, all access should go through the MCOperandInfo accessors.
        /// See the accessors for a description of what these are.
        /// </summary>
        /// <remarks>
        /// From https://github.com/llvm/llvm-project/blob/68b9b769b510b9f5d3fe20e1f850ab829510673e/llvm/include/llvm/MC/MCInstrDesc.h
        /// </remarks>
        [SymSource(tokens)]
        public enum OperandFlags : byte
        {
            LookupPtrRegClass = 0,

            Predicate,

            OptionalDef,

            BranchTarget
        }

        public const byte LookupPtrRegClass = (byte)T.LookupPtrRegClass;

        public const byte Predicate = (byte)T.Predicate;

        public const byte OptionalDef = (byte)T.OptionalDef;

        public const byte BranchTarget = (byte)T.BranchTarget;
    }
}