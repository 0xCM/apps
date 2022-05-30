//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using TK = AsmOcTokenKind;
    using T = AsmOcTokens.OpCodeText;

    [ApiHost]
    public readonly struct AsmOcTokens
    {
        const string Group = "asm.opcodes";

        const NumericKind Closure = UnsignedInts;

        public class OcTokenKind : TokenKindAttribute<TK>
        {
            public OcTokenKind(TK kind)
                : base(kind)
            {


            }
        }

        [LiteralProvider]
        public readonly struct OpCodeText
        {
            public const string W0 = "W0";

            public const string W1 = "W1";

            public const string Rex = "REX";

            public const string RexR = "REX.R";

            public const string RexW = "REX.W";

            public const string Vex = "VEX";

            public const string Evex = "EVEX";

            public const string NP = "NP";

            public const string x66 = "66";

            public const string x67 = "67";

            public const string F2 = "F2";

            public const string F3 = "F3";

            public const string x0F = "0F";

            public const string x0F38 = x0F + "38";

            public const string x0F3A = x0F + "3A";

            public const string xF0 = "F0";

            public const string n1 = "1";

            public const string n128 = "128";

            public const string n256 = "256";

            public const string n512 = "512";

            public const string L0 = "L0";

            public const string L1 = "L1";

            public const string L2 = "L2";

            public const string LZ = "LZ";

            public const string Vsib = "/vsib";

            public const string Sep = " ";

            public const string Plus = "+";

            public const string Dot = ".";

            public const string W = "W";

            public const string LIG = "LIG";

            public const string WIG = "WIG";

            public const string R = "R";

            public const string B = "B";

            public const string X = "X";

            public const string cb = "cb";

            public const string cw = "cw";

            public const string cd = "cd";

            public const string cp = "cp";

            public const string co = "co";

            public const string ib = "ib";

            public const string iw = "iw";

            public const string id = "id";

            public const string io = "io";

            public const string ST0 = "+0";

            public const string ST1 = "+1";

            public const string ST2 = "+2";

            public const string ST3 = "+3";

            public const string ST4 = "+4";

            public const string ST5 = "+5";

            public const string ST6 = "+6";

            public const string ST7 = "+7";

            public const string RRM = "/r";

            public const string rd0 = "/0";

            public const string rd1 = "/1";

            public const string rd2 = "/2";

            public const string rd3 = "/3";

            public const string rd4 = "/4";

            public const string rd5 = "/5";

            public const string rd6 = "/6";

            public const string rd7 = "/7";

            public const string mmmmm = "mmmmm";

            public const string vvvv = "vvvv";

            public const string pp = "pp";

            public const string gs = "gs";

            public const string fs = "fs";

        }

        [SymSource(Group), OcTokenKind(TK.Hex16)]
        public enum Hex16Token : byte
        {
            [Symbol(T.x0F38)]
            x0F38,

            [Symbol(T.x0F3A)]
            x0F3A,
        }

        [SymSource(Group), OcTokenKind(TK.Integer)]
        public enum IntegerToken : byte
        {
            [Symbol(T.n1)]
            x1,
        }

        [SymSource(Group), OcTokenKind(TK.Rex)]
        public enum RexToken : byte
        {
            [Symbol(T.Rex, "Indicates the presence of a REX prefix")]
            Rex,

            [Symbol(T.RexW, "Indicates the W-bit is enabled which signals a 64-bit operand size")]
            RexW,

            [Symbol(T.RexR, "Identifies the Rex 'R' bit")]
            RexR,
        }

        [SymSource(Group), OcTokenKind(TK.Vex)]
        public enum VexToken : byte
        {
            [Symbol(T.W, "Opcode extension field")]
            W,

            [Symbol(T.R, "Logically equivalent to REX.R, but represented in 1's complement form")]
            R,

            [Symbol(T.X, "Logically equivalent to REX.X, but represented in 1's complement form")]
            X,

            [Symbol(T.B, "Logically equivalent to REX.B, but represented in 1's complement form")]
            B,

            [Symbol(T.L0)]
            L0,

            [Symbol(T.L1, "Vector length, where 1 => w=256 and 2 => w=128 or scalar")]
            L1,

            [Symbol(T.L2, "Vector length, where 1 => w=256 and 2 => w=128 or scalar")]
            L2,

            [Symbol(T.Vex)]
            VEX,

            [Symbol(T.LZ)]
            LZ,

            [Symbol(T.LIG)]
            LIG,

            [Symbol(T.WIG)]
            WIG,

            [Symbol(T.W0)]
            W0,

            [Symbol(T.W1)]
            W1,

            [Symbol(T.n128)]
            W128,

            [Symbol(T.n256)]
            W256,

            [Symbol(T.vvvv, "A register specifier in 1's complement form")]
            vvvv,

            [Symbol(T.mmmmm, "In a 3-byte vex prefix, indicates the least 5 bits of the middle byte")]
            mmmmm,

            [Symbol(T.pp, "opcode extension providing equivalent functionality of a SIMD prefix")]
            pp,

            [Symbol(T.Vsib)]
            Vsib,
        }

        [SymSource(Group), OcTokenKind(TK.Evex)]
        public enum EvexToken : byte
        {
            [Symbol(T.Evex)]
            EVEX,

            [Symbol(T.n512)]
            W512,
        }

        [SymSource(Group), OcTokenKind(TK.Disp)]
        public enum DispToken : byte
        {
            [Symbol(T.cb, "Indicates a 1-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            cb,

            [Symbol(T.cw, "Indicates a 2-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            cw,

            [Symbol(T.cd, "Indicates a 4-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            cd,

            [Symbol(T.cp, "Indicates a 6-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            cp,

            [Symbol(T.co, "Indicates an 8-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            co,

            [Symbol("ct", "Indicates a 10-byte value follows the opcode to specify a code offset and/or new value for the code segment register")]
            ct,
        }

        [SymSource(Group), OcTokenKind(TK.SegOverride)]
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

            [Symbol(T.fs, "FS segment override")]
            FS,

            [Symbol(T.gs, "GS segment override")]
            GS,
        }

        [SymSource(Group), OcTokenKind(TK.RegDigit)]
        public enum RegDigitToken : byte
        {
            [Symbol(T.rd0, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 0 provides an extension to the instruction's opcode")]
            r0,

            [Symbol(T.rd1, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 1 provides an extension to the instruction's opcode")]
            r1,

            [Symbol(T.rd2, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 2 provides an extension to the instruction's opcode")]
            r2,

            [Symbol(T.rd3, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 3 provides an extension to the instruction's opcode")]
            r3,

            [Symbol(T.rd4, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 4 provides an extension to the instruction's opcode")]
            r4,

            [Symbol(T.rd5, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 5 provides an extension to the instruction's opcode")]
            r5,

            [Symbol(T.rd6, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 6 provides an extension to the instruction's opcode")]
            r6,

            [Symbol(T.rd7, "The ModR/M byte of the instruction uses only the r/m operand; The register field digit 7 provides an extension to the instruction's opcode")]
            r7,
        }

        /// <summary>
        /// Specifies a '/r' token where r = 0..7. A digit between 0 and 7 indicates that the ModR/M byte of the instruction
        /// uses only the r/m (register or memory) operand. The reg field contains the digit that provides an extension to the instruction's opcode.
        /// </summary>
        [SymSource(Group), OcTokenKind(TK.ModRm)]
        public enum ModRmToken : byte
        {
            [Symbol(T.RRM, "The ModR/M byte of the instruction contains a register operand and an r/m operand")]
            r,
        }

        /// <summary>
        /// Indicates the lower 3 bits of the opcode byte is used to encode the register operand without a modR/M byte Represents one of ['+rb', '+rw', '+rd', '+ro']
        /// </summary>
        [SymSource(Group), OcTokenKind(TK.RexB)]
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
        [SymSource(Group), OcTokenKind(TK.ImmSize)]
        public enum ImmSizeToken : byte
        {
            [Symbol(T.ib, "Indicates a 1-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes.")]
            ib,

            [Symbol(T.iw, "Indicates a 2-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes.")]
            iw,

            [Symbol(T.id, "Indicates a 4-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes.")]
            id,

            [Symbol(T.io, "Indicates An 8-byte immediate operand to the instruction that follows the opcode or ModR/M bytes or scale-indexing bytes")]
            io,
        }

        [SymSource(Group), OcTokenKind(TK.FpuDigit)]
        public enum FpuDigitToken : byte
        {
            [Symbol(T.ST0)]
            st0,

            [Symbol(T.ST1)]
            st1,

            [Symbol(T.ST2)]
            st2,

            [Symbol(T.ST3)]
            st3,

            [Symbol(T.ST4)]
            st4,

            [Symbol(T.ST5)]
            st5,

            [Symbol(T.ST6)]
            st6,

            [Symbol(T.ST7)]
            st7,
        }

        [SymSource(Group), OcTokenKind(TK.Exclusion)]
        public enum ExclusionToken
        {
            [Symbol(T.NP, "Indicates the use of 66/F2/F3 prefixes are not allowed with the instruction")]
            NP,

            [Symbol("NFx", "Indicates the use of F2/F3 prefixes are not allowed with the instruction")]
            NFx,

            [Symbol("NDS")]
            NDS,
        }

        [SymSource(Group), OcTokenKind(TK.Mask)]
        public enum MaskToken : byte
        {
            [Symbol("{k1}", "Indicates a mask register used as instruction writemask for instructions that do not allow zeroing-masking but support merging-masking")]
            Mask,

            [Symbol("{z}", "Indicates a mask register used as instruction writemask for instructions that allow zeroing-masking")]
            ZeroMask,

            [Symbol("{k1}{z}", "Indicates a mask register used as instruction writemask")]
            WriteMask,
        }

        [SymSource(Group), OcTokenKind(TK.Operator)]
        public enum OperatorToken : byte
        {
            [Symbol(T.Plus)]
            Plus,

            [Symbol(T.Dot)]
            Dot,
        }

        [SymSource(Group), OcTokenKind(TK.Sep)]
        public enum SeparatorToken : byte
        {
            [Symbol(T.Sep)]
            Sep,
        }

        // [SymSource(Group), OcTokenKind(TK.Rep)]
        // public enum RepKind : byte
        // {
        //     [Symbol(T.F2)]
        //     F2,

        //     [Symbol(T.F3)]
        //     F3,
        // }

        // [SymSource(Group), OcTokenKind(TK.Size)]
        // public enum SizeKind : byte
        // {
        //     [Symbol(T.x66, "Indicates operand size override")]
        //     OPSZ,

        //     [Symbol(T.x67, "Indicates address size override")]
        //     ADSZ,
        // }
    }
}