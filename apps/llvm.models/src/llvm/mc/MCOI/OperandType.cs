//-----------------------------------------------------------------------------
// Copyright   : (c) LLVM Project
// License     : Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using T = MCOI.OperandType;

    partial struct MCOI
    {
        /// <summary>
        /// Classifies an MC operand
        /// </summary>
        /// <remarks>
        /// From https://github.com/llvm/llvm-project/blob/68b9b769b510b9f5d3fe20e1f850ab829510673e/llvm/include/llvm/MC/MCInstrDesc.h
        /// </remarks>
        public enum OperandType : byte
        {
            OPERAND_UNKNOWN = 0,

            OPERAND_IMMEDIATE = 1,

            OPERAND_REGISTER = 2,

            OPERAND_MEMORY = 3,

            OPERAND_PCREL = 4,

            OPERAND_FIRST_GENERIC = 6,

            OPERAND_GENERIC_0 = 6,

            OPERAND_GENERIC_1 = 7,

            OPERAND_GENERIC_2 = 8,

            OPERAND_GENERIC_3 = 9,

            OPERAND_GENERIC_4 = 10,

            OPERAND_GENERIC_5 = 11,

            OPERAND_LAST_GENERIC = 11,

            OPERAND_FIRST_GENERIC_IMM = 12,

            OPERAND_GENERIC_IMM_0 = 12,

            OPERAND_LAST_GENERIC_IMM = 12,

            OPERAND_FIRST_TARGET = 13,
        }

        public const byte OPERAND_UNKNOWN = (byte)T.OPERAND_UNKNOWN;

        public const byte OPERAND_IMMEDIATE = (byte)T.OPERAND_IMMEDIATE;

        public const byte OPERAND_REGISTER = (byte)T.OPERAND_REGISTER;

        public const byte OPERAND_MEMORY = (byte)T.OPERAND_MEMORY;

        public const byte OPERAND_PCREL = (byte)T.OPERAND_PCREL;

        public const byte OPERAND_FIRST_GENERIC = (byte)T.OPERAND_FIRST_GENERIC;

        public const byte OPERAND_GENERIC_0 = (byte)T.OPERAND_GENERIC_0;

        public const byte OPERAND_GENERIC_1  = (byte)T.OPERAND_GENERIC_1 ;

        public const byte OPERAND_GENERIC_2 = (byte)T.OPERAND_GENERIC_2;

        public const byte OPERAND_GENERIC_3 = (byte)T.OPERAND_GENERIC_3;

        public const byte OPERAND_GENERIC_4 = (byte)T.OPERAND_GENERIC_4;

        public const byte OPERAND_GENERIC_5 = (byte)T.OPERAND_GENERIC_5;

        public const byte OPERAND_LAST_GENERIC = (byte)T.OPERAND_LAST_GENERIC;

        public const byte OPERAND_FIRST_GENERIC_IMM = (byte)T.OPERAND_FIRST_GENERIC_IMM;

        public const byte OPERAND_GENERIC_IMM_0 = (byte)T.OPERAND_GENERIC_IMM_0;

        public const byte OPERAND_LAST_GENERIC_IMM = (byte)T.OPERAND_LAST_GENERIC_IMM;

        public const byte OPERAND_FIRST_TARGET = (byte)T.OPERAND_FIRST_TARGET;
    }
}