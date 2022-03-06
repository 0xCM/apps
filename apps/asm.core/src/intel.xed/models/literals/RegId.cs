//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("xed"), DataWidth(9)]
    public enum XedRegId : ushort
    {
        [Symbol("")]
        INVALID,

        [Ignore]
        BNDCFGU,

        [Ignore]
        BNDSTATUS,

        BND0,

        BND1,

        BND2,

        BND3,

        CR0,

        CR1,

        CR2,

        CR3,

        CR4,

        CR5,

        CR6,

        CR7,

        CR8,

        CR9,

        CR10,

        CR11,

        CR12,

        CR13,

        CR14,

        CR15,

        DR0,

        DR1,

        DR2,

        DR3,

        DR4,

        DR5,

        DR6,

        DR7,

        FLAGS,

        EFLAGS,

        RFLAGS,

        AX,

        CX,

        DX,

        BX,

        SP,

        BP,

        SI,

        DI,

        R8W,

        R9W,

        R10W,

        R11W,

        R12W,

        R13W,

        R14W,

        R15W,

        EAX,

        ECX,

        EDX,

        EBX,

        ESP,

        EBP,

        ESI,

        EDI,

        R8D,

        R9D,

        R10D,

        R11D,

        R12D,

        R13D,

        R14D,

        R15D,

        RAX,

        RCX,

        RDX,

        RBX,

        RSP,

        RBP,

        RSI,

        RDI,

        R8,

        R9,

        R10,

        R11,

        R12,

        R13,

        R14,

        R15,

        AL,

        CL,

        DL,

        BL,

        SPL,

        BPL,

        SIL,

        DIL,

        R8B,

        R9B,

        R10B,

        R11B,

        R12B,

        R13B,

        R14B,

        R15B,

        AH,

        CH,

        DH,

        BH,

        ERROR,

        RIP,

        EIP,

        IP,

        K0,

        K1,

        K2,

        K3,

        K4,

        K5,

        K6,

        K7,

        [Symbol("MM0")]
        MMX0,

        [Symbol("MM1")]
        MMX1,

        [Symbol("MM2")]
        MMX2,

        [Symbol("MM3")]
        MMX3,

        [Symbol("MM4")]
        MMX4,

        [Symbol("MM5")]
        MMX5,

        [Symbol("MM6")]
        MMX6,

        [Symbol("MM7")]
        MMX7,

        SSP,

        IA32_U_CET,

        MXCSR,

        STACKPUSH,

        STACKPOP,

        GDTR,

        LDTR,

        IDTR,

        TR,

        TSC,

        TSCAUX,

        MSRS,

        FSBASE,

        GSBASE,

        TILECONFIG,

        X87CONTROL,

        X87STATUS,

        X87TAG,

        X87PUSH,

        X87POP,

        X87POP2,

        X87OPCODE,

        [Ignore]
        X87LASTCS,

        [Ignore]
        X87LASTIP,

        [Ignore]
        X87LASTDS,

        [Ignore]
        X87LASTDP,

        ES,

        CS,

        SS,

        DS,

        FS,

        GS,

        [Ignore]
        TMP0,

        [Ignore]
        TMP1,

        [Ignore]
        TMP2,

        [Ignore]
        TMP3,

        [Ignore]
        TMP4,

        [Ignore]
        TMP5,

        [Ignore]
        TMP6,

        [Ignore]
        TMP7,

        [Ignore]
        TMP8,

        [Ignore]
        TMP9,

        [Ignore]
        TMP10,

        [Ignore]
        TMP11,

        [Ignore]
        TMP12,

        [Ignore]
        TMP13,

        [Ignore]
        TMP14,

        [Ignore]
        TMP15,

        TMM0,

        TMM1,

        TMM2,

        TMM3,

        TMM4,

        TMM5,

        TMM6,

        TMM7,

        UIF,

        [Symbol("ST(0)")]
        ST0,

        [Symbol("ST(1)")]
        ST1,

        [Symbol("ST(2)")]
        ST2,

        [Symbol("ST(3)")]
        ST3,

        [Symbol("ST(4)")]
        ST4,

        [Symbol("ST(5)")]
        ST5,

        [Symbol("ST(6)")]
        ST6,

        [Symbol("ST(7)")]
        ST7,

        XCR0,

        XMM0,

        XMM1,

        XMM2,

        XMM3,

        XMM4,

        XMM5,

        XMM6,

        XMM7,

        XMM8,

        XMM9,

        XMM10,

        XMM11,

        XMM12,

        XMM13,

        XMM14,

        XMM15,

        XMM16,

        XMM17,

        XMM18,

        XMM19,

        XMM20,

        XMM21,

        XMM22,

        XMM23,

        XMM24,

        XMM25,

        XMM26,

        XMM27,

        XMM28,

        XMM29,

        XMM30,

        XMM31,

        YMM0,

        YMM1,

        YMM2,

        YMM3,

        YMM4,

        YMM5,

        YMM6,

        YMM7,

        YMM8,

        YMM9,

        YMM10,

        YMM11,

        YMM12,

        YMM13,

        YMM14,

        YMM15,

        YMM16,

        YMM17,

        YMM18,

        YMM19,

        YMM20,

        YMM21,

        YMM22,

        YMM23,

        YMM24,

        YMM25,

        YMM26,

        YMM27,

        YMM28,

        YMM29,

        YMM30,

        YMM31,

        ZMM0,

        ZMM1,

        ZMM2,

        ZMM3,

        ZMM4,

        ZMM5,

        ZMM6,

        ZMM7,

        ZMM8,

        ZMM9,

        ZMM10,

        ZMM11,

        ZMM12,

        ZMM13,

        ZMM14,

        ZMM15,

        ZMM16,

        ZMM17,

        ZMM18,

        ZMM19,

        ZMM20,

        ZMM21,

        ZMM22,

        ZMM23,

        ZMM24,

        ZMM25,

        ZMM26,

        ZMM27,

        ZMM28,

        ZMM29,

        ZMM30,

        ZMM31,
    }
}