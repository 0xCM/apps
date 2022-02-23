//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-reg-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRegId;

    public readonly struct XedRegIdFacets
    {
        public const XedRegId BNDCFG_FIRST=BNDCFGU;

        public const XedRegId BNDCFG_LAST=BNDCFGU;

        public const XedRegId BNDSTAT_FIRST=BNDSTATUS;

        public const XedRegId BNDSTAT_LAST=BNDSTATUS;

        public const XedRegId BOUND_FIRST=BND0;

        public const XedRegId BOUND_LAST=BND3;

        public const XedRegId CR_FIRST=CR0;

        public const XedRegId CR_LAST=CR15;

        public const XedRegId DR_FIRST=DR0;

        public const XedRegId DR_LAST=DR7;

        public const XedRegId FLAGS_FIRST=FLAGS;

        public const XedRegId FLAGS_LAST=RFLAGS;

        public const XedRegId GPR16_FIRST=AX;

        public const XedRegId GPR16_LAST=R15W;

        public const XedRegId GPR32_FIRST=EAX;

        public const XedRegId GPR32_LAST=R15D;

        public const XedRegId GPR64_FIRST=RAX;

        public const XedRegId GPR64_LAST=R15;

        public const XedRegId GPR8_FIRST=AL;

        public const XedRegId GPR8_LAST=R15B;

        public const XedRegId GPR8h_FIRST=AH;

        public const XedRegId GPR8h_LAST=BH;

        public const XedRegId INVALID_FIRST=INVALID;

        public const XedRegId INVALID_LAST=ERROR;

        public const XedRegId IP_FIRST=RIP;

        public const XedRegId IP_LAST=IP;

        public const XedRegId MASK_FIRST=K0;

        public const XedRegId MASK_LAST=K7;

        public const XedRegId MMX_FIRST=MMX0;

        public const XedRegId MMX_LAST=MMX7;

        public const XedRegId MSR_FIRST=SSP;

        public const XedRegId MSR_LAST=IA32_U_CET;

        public const XedRegId MXCSR_FIRST=MXCSR;

        public const XedRegId MXCSR_LAST=MXCSR;

        public const XedRegId PSEUDO_FIRST=STACKPUSH;

        public const XedRegId PSEUDO_LAST=TILECONFIG;

        public const XedRegId PSEUDOX87_FIRST=X87CONTROL;

        public const XedRegId PSEUDOX87_LAST=X87LASTDP;

        public const XedRegId SR_FIRST=ES;

        public const XedRegId SR_LAST=GS;

        public const XedRegId TMP_FIRST=TMP0;

        public const XedRegId TMP_LAST=TMP15;

        public const XedRegId TREG_FIRST=TMM0;

        public const XedRegId TREG_LAST=TMM7;

        public const XedRegId UIF_FIRST=UIF;

        public const XedRegId UIF_LAST=UIF;

        public const XedRegId X87_FIRST=ST0;

        public const XedRegId X87_LAST=ST7;

        public const XedRegId XCR_FIRST=XCR0;

        public const XedRegId XCR_LAST=XCR0;

        public const XedRegId XMM_FIRST=XMM0;

        public const XedRegId XMM_LAST=XMM31;

        public const XedRegId YMM_FIRST=YMM0;

        public const XedRegId YMM_LAST=YMM31;

        public const XedRegId ZMM_FIRST=ZMM0;

        public const XedRegId ZMM_LAST=ZMM31;
    }

    [SymSource("xed")]
    public enum XedRegId : ushort
    {
        [Symbol("")]
        INVALID,

        BNDCFGU,

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

        MMX0,

        MMX1,

        MMX2,

        MMX3,

        MMX4,

        MMX5,

        MMX6,

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

        X87LASTCS,

        X87LASTIP,

        X87LASTDS,

        X87LASTDP,

        ES,

        CS,

        SS,

        DS,

        FS,

        GS,

        TMP0,

        TMP1,

        TMP2,

        TMP3,

        TMP4,

        TMP5,

        TMP6,

        TMP7,

        TMP8,

        TMP9,

        TMP10,

        TMP11,

        TMP12,

        TMP13,

        TMP14,

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