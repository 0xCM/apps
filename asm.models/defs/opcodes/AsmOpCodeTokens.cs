//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmOpCodeTokens
    {
        const string tokens = nameof(tokens);

        [SymSource(tokens)]
        public enum EscapeToken : ushort
        {
            [Symbol("0F")]
            x0F = 0x0F,

            [Symbol("0F38")]
            x0F38 = 0x0F38,

            [Symbol("0F3A")]
            x0F3A = 0x0F3A,
        }

        [SymSource(tokens)]
        public enum RexToken : byte
        {
            [Symbol("REX", "Indicates the presence of a REX prefix")]
            Rex,

            [Symbol("REX.W", "Indicates the W-bit is enabled which signals a 64-bit operand size")]
            RexW,
        }

        [SymSource(tokens)]
        public enum VexToken : byte
        {
            [Symbol("W", "Opcode extension field")]
            W,

            [Symbol("R", "Logically equivalent to REX.R, but represented in 1's complement form")]
            R,

            [Symbol("X", "Logically equivalent to REX.X, but represented in 1's complement form")]
            X,

            [Symbol("B", "Logically equivalent to REX.B, but represented in 1's complement form")]
            B,

            [Symbol("L", "Vector length, where 1 => w=256 and 2 => w=128 or scalar")]
            L,

            [Symbol("VEX")]
            VEX,

            [Symbol("LZ")]
            LZ,

            [Symbol("LIG")]
            LIG,

            [Symbol("WIG")]
            WIG,

            [Symbol("W0")]
            W0,

            [Symbol("W1")]
            W1,

            [Symbol("128")]
            W128,

            [Symbol("256")]
            W256,

            [Symbol("vvvv", "A register specifier in 1's complement form")]
            vvvv,

            [Symbol("mmmmm", "In a 3-byte vex prefix, indicates the least 5 bits of the middle byte")]
            mmmmm,

            [Symbol("pp", "opcode extension providing equivalent functionality of a SIMD prefix")]
            pp,
        }

        [SymSource(tokens)]
        public enum EvexToken : byte
        {
            [Symbol("EVEX")]
            EVEX,

            [Symbol("LZ")]
            LZ,

            [Symbol("LIG")]
            LIG,

            [Symbol("WIG")]
            WIG,

            [Symbol("W0")]
            W0,

            [Symbol("W1")]
            W1,

            [Symbol("128")]
            W128,

            [Symbol("256")]
            W256,

            [Symbol("512")]
            W512,
        }

        [SymSource(tokens)]
        public enum DispToken : byte
        {
            [Symbol("cb", "Indicates a 1-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            cb,

            [Symbol("cw", "Indicates a 2-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            cw,

            [Symbol("cd", "Indicates a 4-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            cd,

            [Symbol("cp", "Indicates a 6-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            cp,

            [Symbol("co", "Indicates an 8-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            co,

            [Symbol("ct", "Indicates a 10-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            ct,
        }

        [SymSource(tokens)]
        public enum SegOverrideToken : byte
        {
            [Symbol("cs", "CS segment override")]
            CS,

            [Symbol("ss", "SS segment override")]
            SS,

            [Symbol("ds", "DS segment override")]
            DS,

            [Symbol("es", "ES segment override")]
            ES,

            [Symbol("fs", "FS segment override")]
            FS,

            [Symbol("gs", "GS segment override")]
            GS,
        }

        [SymSource(tokens)]
        public enum OpCodeExtension : byte
        {
            [Symbol("/0", "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 0 provides an extension to the instruction's opcode")]
            r0,

            [Symbol("/1", "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 1 provides an extension to the instruction's opcode")]
            r1,

            [Symbol("/2", "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 2 provides an extension to the instruction's opcode")]
            r2,

            [Symbol("/3", "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 3 provides an extension to the instruction's opcode")]
            r3,

            [Symbol("/4", "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 4 provides an extension to the instruction's opcode")]
            r4,

            [Symbol("/5", "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 5 provides an extension to the instruction's opcode")]
            r5,

            [Symbol("/6", "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 6 provides an extension to the instruction's opcode")]
            r6,

            [Symbol("/7", "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 7 provides an extension to the instruction's opcode")]
            r7,
        }

        /// <summary>
        /// Specifies a '/r' token where r = 0..7. A digit between 0 and 7 indicates that the ModR/M byte of the instruction
        /// uses only the r/m (register or memory) operand. The reg field contains the digit that provides an extension to the instruction's opcode.
        /// </summary>
        [SymSource(tokens)]
        public enum ModRmToken : byte
        {
            [Symbol("/r", "The ModR/M byte of the instruction contains a register operand and an r/m operand")]
            r,
        }

        /// <summary>
        /// Indicates the lower 3 bits of the opcode byte is used to encode the register operand without a modR/M byte Represents one of ['+rb', '+rw', '+rd', '+ro']
        /// </summary>
        [SymSource(tokens)]
        public enum RexBToken : byte
        {
            [Symbol("+rb", "For an 8-bit register, indicates the four bit field of REX.b and opcode[2:0] field encodes the register operand of the instruction")]
            rb,

            [Symbol("+rw", "For a 16-bit register, indicates the four bit field of REX.b and opcode[2:0] field encodes the register operand of the instruction")]
            rw,

            [Symbol("+rd", "For a 32-bit register, indicates the four bit field of REX.b and opcode[2:0] field encodes the register operand of the instruction")]
            rd,

            [Symbol("+ro", "For a 64-bit register, indicates the four bit field of REX.b and opcode[2:0] field encodes the register operand of the instruction")]
            ro,
        }

        /// <summary>
        /// "Specifies the size of an immediate operand in the context of an opcode specification"
        /// </summary>
        [SymSource(tokens)]
        public enum ImmSizeToken : byte
        {
            [Symbol("ib", "Indicates a 1-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes.")]
            ib,

            [Symbol("iw", "Indicates a 2-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes.")]
            iw,

            [Symbol("id", "Indicates a 4-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes.")]
            id,

            [Symbol("io", "Indicates An 8-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes")]
            io,
        }

        [SymSource(tokens)]
        public enum FpuDigitToken : byte
        {
            [Symbol("+0")]
            i0,

            [Symbol("+1")]
            i1,

            [Symbol("+2")]
            i2,

            [Symbol("+3")]
            i3,

            [Symbol("+4")]
            i4,

            [Symbol("+5")]
            i5,

            [Symbol("+6")]
            i6,

            [Symbol("+7")]
            i7,
        }

        [SymSource(tokens)]
        public enum ExclusionToken
        {
            [Symbol("NP", "Indicates the use of 66/F2/F3 prefixes are not allowed with the instruction")]
            NP,

            [Symbol("NFx", "Indicates the use of F2/F3 prefixes are not allowed with the instruction")]
            NFx,
        }

        [SymSource(tokens)]
        public enum MaskToken : byte
        {
            [Symbol("{k1}", "Indicates a mask register used as instruction writemask for instructions that do not allow zeroing-masking but support merging-masking")]
            Mask,

            [Symbol("{k1}{z}", "Indicates a mask register used as instruction writemask")]
            WriteMask,
        }

        [SymSource(tokens)]
        public enum OpCodeOperator : byte
        {
            [Symbol("+")]
            Plus,

            [Symbol(".")]
            Dot,
        }
   }
}