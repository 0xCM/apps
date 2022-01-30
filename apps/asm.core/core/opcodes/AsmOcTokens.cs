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

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmOcToken<K> token<K>(AsmOcTokenKind kind, K value)
            where K : unmanaged
                => new AsmOcToken<K>(kind,value);

        [MethodImpl(Inline), Op]
        public static AsmOcToken token(ushort src)
            => new AsmOcToken(src);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<Hex8Kind> hex8(Hex8 value)
            => token<Hex8Kind>(TK.Hex8, value);

        public static AsmOcToken<OcLiteralToken> word(OcLiteralToken t)
            => token(TK.OcLiteral, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<ExclusionToken> exclude(ExclusionToken t)
            => token(TK.Exclusion, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<RexToken> rex(RexToken t)
            => token(TK.Rex, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<RexBToken> rexb(RexBToken t)
            => token(TK.RexB, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<VexToken> vex(VexToken t)
            => token(TK.Vex, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<EvexToken> evex(EvexToken t)
            => token(TK.Evex, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<DispToken> disp(DispToken t)
            => token(TK.Disp, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<SegOverrideToken> ov(SegOverrideToken t)
            => token(TK.SegOverride, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<OpCodeExtension> extension(OpCodeExtension t)
            => token(TK.OcExtension, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<ImmSizeToken> immsize(ImmSizeToken t)
            => token(TK.ImmSize, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<ModRmToken> modrm(ModRmToken t)
            => token(TK.ModRm, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<FpuDigitToken> fpudigit(FpuDigitToken t)
            => token(TK.FpuDigit, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<MaskToken> mask(MaskToken t)
            => token(TK.Mask, t);

        [MethodImpl(Inline), Op]
        public static AsmOcToken<OperatorToken> op(OperatorToken t)
            => token(TK.Operator, t);

        public readonly struct OpCodeText
        {
            public const string Rex = "REX";

            public const string Vex = "VEX";

            public const string Evex = "EVEX";

            public const string RexW = "REX.W";

            public const string NP = "NP";

            public const string x66 = "66";

            public const string x67 = "67";

            public const string F2 = "F2";

            public const string F3 = "F3";

            public const string x0F = "0F";

            public const string xF0 = "F0";

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

        }

        [SymSource(Group, TK.OcLiteral)]
        public enum OcLiteralToken : byte
        {
            [Symbol("1")]
            x1,

            [Symbol("0F38")]
            x0F38,

            [Symbol("0F3A")]
            x0F3A,
        }

        [SymSource(Group, TK.Lock)]
        public enum LockToken : byte
        {
            [Symbol(T.xF0, "Indicates an atomic instruction")]
            F0,
        }

        [SymSource(Group, TK.Size)]
        public enum SizeToken : byte
        {
            [Symbol(T.x66, "Indicates operand size override")]
            OPSZ,

            [Symbol(T.x67, "Indicates address size override")]
            ADSZ,
        }

        [SymSource(Group, TK.Rex)]
        public enum RexToken : byte
        {
            [Symbol(T.Rex, "Indicates the presence of a REX prefix")]
            Rex,

            [Symbol("REX.W", "Indicates the W-bit is enabled which signals a 64-bit operand size")]
            RexW,

            [Symbol("REX.R", "Identifies the Rex 'R' bit")]
            RexR,

            [Symbol("REX.R", "Identifies the Rex 'X' bit")]
            RexX,

            [Symbol("REX.R", "Identifies the Rex 'B' bit")]
            RexB,
        }

        [SymSource(Group, TK.Vex)]
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

            [Symbol("LIG")]
            LIG,

            [Symbol("WIG")]
            WIG,

            [Symbol("W0")]
            W0,

            [Symbol("W1")]
            W1,

            [Symbol(T.n128)]
            W128,

            [Symbol(T.n256)]
            W256,

            [Symbol("vvvv", "A register specifier in 1's complement form")]
            vvvv,

            [Symbol("mmmmm", "In a 3-byte vex prefix, indicates the least 5 bits of the middle byte")]
            mmmmm,

            [Symbol("pp", "opcode extension providing equivalent functionality of a SIMD prefix")]
            pp,

            [Symbol(T.Vsib)]
            Vsib,
        }

        [SymSource(Group, TK.Evex)]
        public enum EvexToken : byte
        {
            [Symbol(T.Evex)]
            EVEX,

            [Symbol(T.n512)]
            W512,
        }

        [SymSource(Group, TK.Disp)]
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

        [SymSource(Group, TK.Rep)]
        public enum RepToken : byte
        {
            [Symbol(T.F2)]
            F2,

            [Symbol(T.F3)]
            F3,
        }

        [SymSource(Group, TK.SegOverride)]
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

        [SymSource(Group, TK.OcExtension)]
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
        [SymSource(Group, TK.ModRm)]
        public enum ModRmToken : byte
        {
            [Symbol("/r", "The ModR/M byte of the instruction contains a register operand and an r/m operand")]
            r,
        }

        /// <summary>
        /// Indicates the lower 3 bits of the opcode byte is used to encode the register operand without a modR/M byte Represents one of ['+rb', '+rw', '+rd', '+ro']
        /// </summary>
        [SymSource(Group, TK.RexB)]
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
        [SymSource(Group, TK.ImmSize)]
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

        [SymSource(Group, TK.FpuDigit)]
        public enum FpuDigitToken : byte
        {
            [Symbol("+0")]
            st0,

            [Symbol("+1")]
            st1,

            [Symbol("+2")]
            st2,

            [Symbol("+3")]
            st3,

            [Symbol("+4")]
            st4,

            [Symbol("+5")]
            st5,

            [Symbol("+6")]
            st6,

            [Symbol("+7")]
            st7,
        }

        [SymSource(Group, TK.Exclusion)]
        public enum ExclusionToken
        {
            [Symbol(T.NP, "Indicates the use of 66/F2/F3 prefixes are not allowed with the instruction")]
            NP,

            [Symbol("NFx", "Indicates the use of F2/F3 prefixes are not allowed with the instruction")]
            NFx,

            [Symbol("NDS")]
            NDS,
        }

        [SymSource(Group, TK.Mask)]
        public enum MaskToken : byte
        {
            [Symbol("{k1}", "Indicates a mask register used as instruction writemask for instructions that do not allow zeroing-masking but support merging-masking")]
            Mask,

            [Symbol("{z}", "Indicates a mask register used as instruction writemask for instructions that allow zeroing-masking")]
            ZeroMask,

            [Symbol("{k1}{z}", "Indicates a mask register used as instruction writemask")]
            WriteMask,
        }

        [SymSource(Group, TK.Operator)]
        public enum OperatorToken : byte
        {
            [Symbol(T.Plus)]
            Plus,

            [Symbol(T.Dot)]
            Dot,

            [Symbol(T.Sep)]
            Sep,
        }

        public sealed class OpCodeTokenSet : TokenSet<OpCodeTokenSet>
        {
            public override string Name
                => "asm.opcodes";

            public override Type[] Types()
                => typeof(AsmOcTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
        }
    }
}