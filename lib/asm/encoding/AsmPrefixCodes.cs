//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Hex8Seq;
    using static NumericBaseKind;

    public readonly struct AsmPrefixCodes
    {
        public static RexPrefixCode RexW => RexPrefixCode.W;

        const string tokens = "asm.prefixes";

        [SymSource(tokens)]
        public enum VsibField : byte
        {
            /// <summary>
            /// VSIB.base, Bits [3:0]
            /// </summary>
            [Symbol("base")]
            Base = 0,

            /// <summary>
            /// VSIB.index, Bits [5:3]
            /// </summary>
            [Symbol("index")]
            Index = 3,

            /// <summary>
            /// VSIB.SS, Bits [7:6]
            /// </summary>
            [Symbol("SS")]
            SS = 6,
        }

        /// <summary>
        /// Defines REX field identifiers
        /// </summary>
        [SymSource(tokens)]
        public enum RexFieldIndex : byte
        {
            [Symbol("b")]
            B = 0,

            [Symbol("x")]
            X = 1,

            [Symbol("r")]
            R = 2,

            [Symbol("w")]
            W = 3,
        }

        /// <summary>
        /// Defines the lock prefix code
        /// </summary>
        [SymSource(tokens, Base16)]
        public enum LockPrefixCode : byte
        {
            [Symbol("F0", "Lock Prefix")]
            LOCK = 0xF0,
        }

        [SymSource(tokens, Base16)]
        public enum BranchHintCode : byte
        {
            /// <summary>
            /// Branch taken
            /// </summary>
            [Symbol("BT", "2e - Branch Taken")]
            BT = 0x2E,

            /// <summary>
            /// Branch not taken
            /// </summary>
            [Symbol("BT", "3e - Branch Not Taken")]
            BNT = 0x3e,
        }

        [SymSource(tokens, Base16)]
        public enum SizeOverrideCode
        {
            None = 0,

            /// <summary>
            /// Operand size override
            /// </summary>
            /// <remarks>
            /// The operand-size override prefix allows a program to switch between 16- and 32-bit operand sizes.
            /// Either size can be the default; use of the prefix selects the non-default size
            /// </remarks>
            [Symbol("66","Operand size override")]
            OPSZ = 0x66,

            /// <summary>
            /// Address size override
            /// </summary>
            /// <remarks>
            /// The address-size override prefix allows programs to switch between 16- and 32-bit addressing.
            /// Either size can be the default; the prefix selects the non-default size
            /// </remarks>
            [Symbol("67", "Address size override")]
            ADSZ = 0x67,
        }

        /// <summary>
        /// Defines the mandatory prefix codes as specified by Intel Vol II, 2.1.2
        /// </summary>
        [SymSource(tokens, Base16)]
        public enum MandatoryPrefixCode : byte
        {
            [Symbol("66")]
            x66 = 0x66,

            [Symbol("F2")]
            F2 = 0xF2,

            [Symbol("F3")]
            F3 = 0xF3,
        }

        [SymSource(tokens, Base16)]
        public enum EscapeCode : ushort
        {
            [Symbol("0F")]
            x0F = 0x0F,

            [Symbol("0F38")]
            x0F38 = 0x0F38,

            [Symbol("0F3A")]
            x0F3A = 0x0F3A,
        }

        [SymSource(tokens, Base16)]
        public enum BndPrefixCode : byte
        {
            [Symbol("BND")]
            BND = xf2
        }

        /// <summary>
        /// The segment override codes as specified by Intel Vol II, 2.1.1
        /// </summary>
        [SymSource(tokens, Base16)]
        public enum SegOverrideCode : byte
        {
            [Symbol("cs", "CS segment override")]
            CS = 0x2e,

            [Symbol("ss", "SS segment override")]
            SS = 0x36,

            [Symbol("ds","DS segment override")]
            DS = 0x3e,

            [Symbol("es", "ES segment override")]
            ES = 0x26,

            [Symbol("fs", "FS segment override")]
            FS = 0x64,

            [Symbol("gs", "GS segment override")]
            GS = 0x65,
        }

        /// <summary>
        /// Classfies vex prefix codes
        /// </summary>
        [SymSource(tokens, Base16)]
        public enum VexPrefixKind : byte
        {
            [Symbol("C4", "The leading byte of a 3-byte vex prefix sequence")]
            xC4 = 0xC4,

            [Symbol("C5", "The leading byte of a 2-byte vex prefix sequence")]
            xC5 = 0xC5,
        }

        /// <summary>
        /// [0100 0001] | W:0 | R:0 | X:0 | B:1
        /// </summary>
        [Flags]
        [SymSource(tokens, Base16)]
        public enum RexPrefixCode : byte
        {
            /// <summary>
            /// [0100 0000] => [W:0 | R:0 | X:0 | B:0]
            /// </summary>
            [Symbol("REX", "[0100 0000]")]
            Base = 0x40,

            /// <summary>
            /// Extends one of:
            /// - The reg field in the ModR/M byte
            /// - The index field in the SIB byte
            /// - The reg field in the opcode byte
            /// </summary>
            [Symbol("REX.B", "[0100 0001]")]
            B = 0x41,

            /// <summary>
            /// Extends the index field in the SIB byte
            /// </summary>
            [Symbol("REX.X", "[0100 0010]")]
            X = 0x42,

            /// <summary>
            /// Extends the reg field in the ModR/M byte
            /// </summary>
            [Symbol("REX.R", "[0100 0100]")]
            R = 0x44,

            /// <summary>
            /// Wide, enables 64-bit execution
            /// </summary>
            [Symbol("REX.W", "[0100 1000]")]
            W = 0x48,
        }

        [SymSource(tokens, Base16)]
        public enum RepPrefixCode : byte
        {
            [Symbol("F2")]
            REPNZ = 0xf2,

            [Symbol("F3")]
            REPZ = 0xf3,
        }
    }
}