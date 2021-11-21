//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    /// <summary>
    /// From https://github.com/llvm/llvm-project/blob/abef659a45fff4147f8f0ffd1d0f6600185e4a4e/llvm/include/llvm/MC/MCAsmMacro.h
    /// </summary>
    public enum AsmTokenKind
    {
        // Markers
        Eof,

        Error,

        // String values.
        Identifier,

        String,

        // Integer values.
        Integer,

        BigNum, // larger than 64 bits

        // Real values.
        Real,

        // Comments
        Comment,

        HashDirective,

        // No-value.
        EndOfStatement,

        Colon,

        Space,

        Plus,

        Minus,

        Tilde,

        Slash,     // '/'

        BackSlash, // '\'

        LParen,

        RParen,

        LBrac,

        RBrac,

        LCurly,

        RCurly,

        Star,

        Dot,

        Comma,

        Dollar,

        Equal,

        EqualEqual,

        Pipe,

        PipePipe,

        Caret,

        Amp,

        AmpAmp,

        Exclaim,

        ExclaimEqual,

        Percent,

        Hash,

        Less,

        LessEqual,

        LessLess,

        LessGreater,

        Greater,

        GreaterEqual,

        GreaterGreater,

        At,

        MinusGreater,

        // MIPS unary expression operators such as %neg.
        PercentCall16,

        PercentCall_Hi,

        PercentCall_Lo,

        PercentDtprel_Hi,

        PercentDtprel_Lo,

        PercentGot,

        PercentGot_Disp,

        PercentGot_Hi,

        PercentGot_Lo,

        PercentGot_Ofst,

        PercentGot_Page,

        PercentGottprel,

        PercentGp_Rel,

        PercentHi,

        PercentHigher,

        PercentHighest,

        PercentLo,

        PercentNeg,

        PercentPcrel_Hi,

        PercentPcrel_Lo,

        PercentTlsgd,

        PercentTlsldm,

        PercentTprel_Hi,

        PercentTprel_Lo
    };
}