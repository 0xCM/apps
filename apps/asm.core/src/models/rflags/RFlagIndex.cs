//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct RFlags
    {
        /// <summary>
        /// Defines the bitfield index of the flags defined by <see cref='RFlagBits'/>
        /// </summary>
        public enum RFlagIndex : byte
        {
            /// <summary>
            /// Carry Flag (Status Flag): Set if an arithmetic operation generates a carry or a borrow
            /// out of the mostsignificant bit of the result; cleared otherwise. This flag
            /// indicates an overflow condition for unsigned-integer arithmetic. It is also used
            /// in multiple-precision arithmetic
            ///</summary>
            CF = 0,

            /// <summary>
            /// Parity Flag (Status Flag): Set if the least-significant byte of the result contains an even number of 1 bits; cleared otherwise.
            ///</summary>
            PF = 2,

            /// <summary>
            /// Adjust/Carry Flag (Status Flag): Set if an arithmetic operation generates a carry or a borrow out of bit 3 of the result; cleared otherwise.
            ///</summary>
            AF = 4,

            /// <summary>
            /// Zero Flag (Status Flag): Set if the result is zero; cleared otherwise
            ///</summary>
            ZF = 6,

            /// <summary>
            /// Sign Flag (Status Flag): Set equal to the most-significant bit of the result, which is the sign bit of a signed
            /// integer. (0 indicates a positive value and 1 indicates a negative value.)
            ///</summary>
            SF = 7,

            /// <summary>
            ///  Trap Flag (System Flag): Set to enable single-step mode for debugging; clear to disable single-step mode.
            ///</summary>
            TF = 8,

            /// <summary>
            /// Interupt Flag (System Flag)
            ///</summary>
            IF = 9,

            /// <summary>
            /// Direction Flag
            ///</summary>
            DF = 10,

            /// <summary>
            /// Overflow Flag (Status Flag): Set if the integer result is too large a positive number
            /// or too small a negative number (excluding the sign-bit) to fit in the destination
            /// operand; cleared otherwise. This flag indicates an overflow condition for signed-integer
            /// (two’s complement) arithmetic.
            ///</summary>
            OF = 11,

            /// <summary>
            /// Resume Flag
            ///</summary>
            RF = 16,

            /// <summary>
            /// Virtual 8086 Mode
            ///</summary>
            VM = 17,

            /// <summary>
            /// Alignment Check
            ///</summary>
            AC = 18,

            /// <summary>
            /// Virtual Interrupt Flag
            ///</summary>
            VIF = 19,

            /// <summary>
            /// Virtual Interrupt Pending
            ///</summary>
            VIP = 20,

            /// <summary>
            /// CPUID-capability
            ///</summary>
            ID = 21,
        }
    }
}