//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Pow2x32;

    partial struct RFlags
    {
        /// <summary>
        /// Defines literals corresponding the bits in the RFLAGS register
        /// </summary>
        [Flags,SymSource]
        public enum RFlagBits : ulong
        {
            /// <summary>
            /// Carry Flag (Status Flag): Set if an arithmetic operation generates a carry or a borrow
            /// out of the mostsignificant bit of the result; cleared otherwise. This flag
            /// indicates an overflow condition for unsigned-integer arithmetic. It is also used
            /// in multiple-precision arithmetic
            ///</summary>
            [Symbol("cf", "Carry Flag")]
            CF = P2ᐞ00,

            /// <summary>
            /// Parity Flag (Status Flag): Set if the least-significant byte of the result contains an even number of 1 bits; cleared otherwise.
            ///</summary>
            [Symbol("pf", "Parity Flag")]
            PF = P2ᐞ02,

            /// <summary>
            /// Adjust/Carry Flag (Status Flag): Set if an arithmetic operation generates a carry or a borrow out of bit 3 of the result; cleared otherwise.
            ///</summary>
            [Symbol("af", "Adjust/Carry Flag")]
            AF = P2ᐞ04,

            /// <summary>
            /// Zero Flag (Status Flag): Set if the result is zero; cleared otherwise
            ///</summary>
            [Symbol("zf", "Zero Flag")]
            ZF = P2ᐞ06,

            /// <summary>
            /// Sign Flag (Status Flag): Set equal to the most-significant bit of the result, which is the sign bit of a signed
            /// integer. (0 indicates a positive value and 1 indicates a negative value.)
            ///</summary>
            [Symbol("sf", "Sign Flag")]
            SF = P2ᐞ07,

            /// <summary>
            ///  Trap Flag (System Flag): Set to enable single-step mode for debugging; clear to disable single-step mode.
            ///</summary>
            [Symbol("tf", "Trap Flag")]
            TF = P2ᐞ08,

            /// <summary>
            /// Interupt Flag (System Flag)
            ///</summary>
            [Symbol("if", "Interupt Flag")]
            IF = P2ᐞ09,

            /// <summary>
            /// Direction Flag
            ///</summary>
            [Symbol("df", "Direction Flag")]
            DF = P2ᐞ10,

            /// <summary>
            /// Overflow Flag (Status Flag): Set if the integer result is too large a positive number
            /// or too small a negative number (excluding the sign-bit) to fit in the destination
            /// operand; cleared otherwise. This flag indicates an overflow condition for signed-integer
            /// (two’s complement) arithmetic.
            ///</summary>
            [Symbol("of", "Overflow Flag")]
            OF = P2ᐞ11,

            /// <summary>
            /// Resume Flag
            ///</summary>
            [Symbol("rf", "Resume Flag")]
            RF = P2ᐞ16,

            /// <summary>
            /// Virtual 8086 Mode
            ///</summary>
            [Symbol("vm", "Virtual 8086 Mode")]
            VM = P2ᐞ17,

            /// <summary>
            /// Alignment Check
            ///</summary>
            [Symbol("ac", "Alignment Check")]
            AC = P2ᐞ18,

            /// <summary>
            /// Virtual Interrupt Flag
            ///</summary>
            [Symbol("vif", "Virtual Interrupt Flag")]
            VIF = P2ᐞ19,

            /// <summary>
            /// Virtual Interrupt Pending
            ///</summary>
            [Symbol("vip", "Virtual Interrupt Pending")]
            VIP = P2ᐞ20,

            /// <summary>
            /// CPUID-capability
            ///</summary>
            [Symbol("id", "CPUID-capability")]
            ID = P2ᐞ21,
        }
    }
}