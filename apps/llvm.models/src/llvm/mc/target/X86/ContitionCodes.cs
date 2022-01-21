//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.X86
{
    using static CondCode;

    /// <summary>
    /// X86 specific condition code. These correspond to X86_*_COND in X86InstrInfo.td. They must be kept in synch.
    /// </summary>
    /// <remarks>https://github.com/llvm/llvm-project/blob/ce548aa236962f95ccaf59f8692ed0861f3769dd/llvm/lib/Target/X86/MCTargetDesc/X86BaseInfo.h</remarks>
    public enum CondCode : byte
    {
        COND_O = 0,

        COND_NO = 1,

        COND_B = 2,

        COND_AE = 3,

        COND_E = 4,

        COND_NE = 5,

        COND_BE = 6,

        COND_A = 7,

        COND_S = 8,

        COND_NS = 9,

        COND_P = 10,

        COND_NP = 11,

        COND_L = 12,

        COND_GE = 13,

        COND_LE = 14,

        COND_G = 15,
    }

    public enum CondCodeAlt : byte
    {
        COND_C = COND_B,

        COND_NC = COND_AE,

        COND_Z = COND_E,

        COND_NZ = COND_NE,

        COND_NA = COND_BE,

        COND_NBE = COND_A,

        COND_PE = COND_P,

        COND_PO = COND_NP,

        COND_NGE = COND_L,

        COND_NL = COND_GE,

        COND_NG = COND_LE,

        COND_NLE = COND_G,
    }
}