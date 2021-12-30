//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RegIndexCode;
    using static RegClassCode;
    using static NativeSizeCode;
    using static RegFieldFacets;
    using static NumericBaseKind;

    using SR = SegRegKind;
    using F = FlagRegKind;
    using X = XmmRegKind;
    using Y = YmmRegKind;
    using Z = ZmmRegKind;
    using G8 = Gp8Kind;
    using G16 = Gp16Kind;
    using G32 = Gp32Kind;
    using G64 = Gp64Kind;
    using M = MaskRegKind;
    using C = ControlRegKind;
    using XCR = XControlRegKind;
    using D = DebugRegKind;
    using I = IpRegKind;
    using B = BndRegKind;
    using ST = FpuRegKind;
    using MM = MmxRegKind;
    using TR = TestRegKind;
    using SPTR = SysPtrRegKind;

    [SymSource("asm.regs.bits", Base16)]
    public enum RegKind : ushort
    {
        None = 0,

        // ~ FLAGS registers
        // ~ ------------------------------------------------------------------

        [Symbol("flags")]
        FLAGS = F.Flags,

        [Symbol("eflags")]
        EFLAGS = F.EFlags,

        [Symbol("rflags")]
        RFLAGS = F.RFlags,

        // ~ 16-bit segment registers
        // ~ ------------------------------------------------------------------
        [Symbol("cs")]
        CS = SR.CS,

        [Symbol("ds")]
        DS = SR.DS,

        [Symbol("ss")]
        SS = SR.SS,

        [Symbol("es")]
        ES = SR.ES,

        [Symbol("fs")]
        FS = SR.FS,

        [Symbol("gs")]
        GS = SR.GS,

        // ~ 8-bit general-purpose registers
        // ~ ------------------------------------------------------------------

        [Symbol("al")]
        AL = G8.AL,

        [Symbol("ah")]
        AH = G8.AH,

        [Symbol("cl")]
        CL = G8.CL,

        [Symbol("ch")]
        CH = G8.CH,

        [Symbol("dl")]
        DL = G8.DL,

        [Symbol("dh")]
        DH = G8.DH,

        [Symbol("bl")]
        BL = G8.BL,

        [Symbol("bh")]
        BH = G8.BH,

        [Symbol("spl")]
        SPL = G8.SPL,

        [Symbol("bpl")]
        BPL = G8.BPL,

        [Symbol("sil")]
        SIL = G8.SIL,

        [Symbol("dil")]
        DIL = G8.DIL,

        [Symbol("r8b")]
        R8B = G8.R8B,

        [Symbol("r9b")]
        R9B = G8.R9B,

        [Symbol("r10b")]
        R10B = G8.R10B,

        [Symbol("r11b")]
        R11B = G8.R11B,

        [Symbol("r12b")]
        R12B = G8.R12B,

        [Symbol("r13b")]
        R13B = G8.R13B,

        [Symbol("r14b")]
        R14B = G8.R14B,

        [Symbol("r15b")]
        R15B = G8.R15B,

        // ~ 16-bit general-purpose registers
        // ~ ------------------------------------------------------------------

        [Symbol("ax")]
        AX = G16.AX,

        [Symbol("cx")]
        CX = G16.CX,

        [Symbol("dx")]
        DX = G16.DX,

        [Symbol("bx")]
        BX = G16.BX,

        [Symbol("sp")]
        SP = G16.SP,

        [Symbol("bp")]
        BP = G16.BP,

        [Symbol("si")]
        SI = G16.SI,

        [Symbol("di")]
        DI = G16.DI,

        [Symbol("r8w")]
        R8W = G16.R8W,

        [Symbol("r9w")]
        R9W = G16.R9W,

        [Symbol("r10w")]
        R10W = G16.R10W,

        [Symbol("r11w")]
        R11W = G16.R11W,

        [Symbol("r12w")]
        R12W = G16.R12W,

        [Symbol("r13w")]
        R13W = G16.R13W,

        [Symbol("r14w")]
        R14W = G16.R14W,

        [Symbol("r15w")]
        R15W = G16.R15W,

        // ~ 32-bit general-purpose registers
        // ~ ------------------------------------------------------------------

        EAX = G32.EAX,

        ECX = G32.ECX,

        EDX = G32.EDX,

        EBX = G32.EBX,

        ESP = G32.ESP,

        EBP = G32.EBP,

        ESI = G32.ESI,

        EDI = G32.EDI,

        R8D = G32.R8D,

        R9D = G32.R9D,

        R10D = G32.R10D,

        R11D = G32.R11D,

        R12D = G32.R12D,

        R13D = G32.R13D,

        R14D = G32.R14D,

        R15D = G32.R15D,

        // ~ 64-bit general-purpose registers
        // ~ ------------------------------------------------------------------

        RAX = G64.RAX,

        RCX = G64.RCX,

        RDX = G64.RDX,

        RBX = G64.RBX,

        RSP = G64.RSP,

        RBP = G64.RBP,

        RSI = G64.RSI,

        RDI = G64.RDI,

        R8Q = G64.R8Q,

        R9Q = G64.R9Q,

        R10Q = G64.R10Q,

        R11Q = G64.R11Q,

        R12Q = G64.R12Q,

        R13Q = G64.R13Q,

        R14Q = G64.R14Q,

        R15Q = G64.R15Q,

        // ~ 128-bit vectorized registers
        // ~ ------------------------------------------------------------------

        XMM0 = X.XMM0,

        XMM1 = X.XMM1,

        XMM2 = X.XMM2,

        XMM3 = X.XMM3,

        XMM4 = X.XMM4,

        XMM5 = X.XMM5,

        XMM6 = X.XMM6,

        XMM7 = X.XMM7,

        XMM8 = X.XMM8,

        XMM9 = X.XMM9,

        XMM10 = X.XMM10,

        XMM11 = X.XMM11,

        XMM12 = X.XMM12,

        XMM13 = X.XMM13,

        XMM14 = X.XMM14,

        XMM15 = X.XMM15,

        XMM16 = X.XMM16,

        XMM17 = X.XMM17,

        XMM18 = X.XMM18,

        XMM19 = X.XMM19,

        [Symbol("xmm20")]
        XMM20 = X.XMM20,

        [Symbol("xmm21")]
        XMM21 = X.XMM21,

        [Symbol("xmm22")]
        XMM22 = X.XMM22,

        [Symbol("xmm23")]
        XMM23 = X.XMM23,

        [Symbol("xmm24")]
        XMM24 = X.XMM24,

        [Symbol("xmm25")]
        XMM25 = X.XMM25,

        [Symbol("xmm26")]
        XMM26 = X.XMM26,

        [Symbol("xmm27")]
        XMM27 = X.XMM27,

        [Symbol("xmm28")]
        XMM28 = X.XMM28,

        [Symbol("xmm29")]
        XMM29 = X.XMM29,

        [Symbol("xmm30")]
        XMM30 = X.XMM30,

        [Symbol("xmm31")]
        XMM31 = X.XMM31,

        // ~ 256-bit vectorized registers
        // ~ ------------------------------------------------------------------

        YMM0 = Y.YMM0,

        YMM1 = Y.YMM1,

        YMM2 = Y.YMM2,

        YMM3 = Y.YMM3,

        YMM4 = Y.YMM4,

        YMM5 = Y.YMM5,

        YMM6 = Y.YMM6,

        YMM7 = Y.YMM7,

        YMM8 = Y.YMM8,

        YMM9 = Y.YMM9,

        YMM10 = Y.YMM10,

        YMM11 = Y.YMM11,

        YMM12 = Y.YMM12,

        YMM13 = Y.YMM13,

        YMM14 = Y.YMM14,

        YMM15 = Y.YMM15,

        YMM16 = Y.YMM16,

        YMM17 = Y.YMM16,

        YMM18 = Y.YMM18,

        YMM19 = Y.YMM19,

        YMM20 = Y.YMM20,

        YMM21 = Y.YMM21,

        YMM22 = Y.YMM22,

        YMM23 = Y.YMM23,

        YMM24 = Y.YMM24,

        YMM25 = Y.YMM25,

        YMM26 = Y.YMM26,

        YMM27 = Y.YMM27,

        YMM28 = Y.YMM28,

        YMM29 = Y.YMM29,

        YMM30 = Y.YMM30,

        YMM31 = Y.YMM31,

        // ~ 512-bit vectorized registers
        // ~ ------------------------------------------------------------------

        ZMM0 = Z.ZMM0,

        ZMM1 = Z.ZMM1,

        ZMM2 = Z.ZMM2,

        ZMM3 = Z.ZMM3,

        ZMM4 = Z.ZMM4,

        ZMM5 = Z.ZMM5,

        ZMM6 = Z.ZMM6,

        ZMM7 = Z.ZMM7,

        ZMM8 = Z.ZMM8,

        ZMM9 = Z.ZMM9,

        ZMM10 = Z.ZMM10,

        ZMM11 = Z.ZMM11,

        ZMM12 = Z.ZMM12,

        ZMM13 = Z.ZMM13,

        ZMM14 = Z.ZMM14,

        ZMM15 = Z.ZMM15,

        ZMM16 = Z.ZMM16,

        ZMM17 = Z.ZMM17,

        ZMM18 = Z.ZMM18,

        ZMM19 = Z.ZMM19,

        ZMM20 = Z.ZMM20,

        ZMM21 = Z.ZMM21,

        ZMM22 = Z.ZMM22,

        ZMM23 = Z.ZMM23,

        ZMM24 = Z.ZMM24,

        ZMM25 = Z.ZMM25,

        ZMM26 = Z.ZMM26,

        ZMM27 = r27 | ZMM << ClassField | W512 << WidthField,

        ZMM28 = r28 | ZMM << ClassField | W512 << WidthField,

        ZMM29 = r29 | ZMM << ClassField | W512 << WidthField,

        ZMM30 = r30 | ZMM << ClassField | W512 << WidthField,

        ZMM31 = r31 | ZMM << ClassField | W512 << WidthField,

        // ~ 64-bit mask registers
        // ~ ------------------------------------------------------------------

        [Symbol("k0")]
        K0 = M.K0,

        [Symbol("k1")]
        K1 = M.K1,

        [Symbol("k2")]
        K2 = M.K2,

        [Symbol("k3")]
        K3 = M.K3,

        [Symbol("k4")]
        K4 = M.K4,

        [Symbol("k5")]
        K5 = M.K5,

        [Symbol("k6")]
        K6 = M.K6,

        [Symbol("k7")]
        K7 = M.K7,

        // ~ Control registers
        // ~ ------------------------------------------------------------------

        [Symbol("cr0")]
        CR0 = C.CR0,

        [Symbol("cr1")]
        CR1 = C.CR1,

        [Symbol("cr2")]
        CR2 = C.CR2,

        [Symbol("cr3")]
        CR3 = C.CR3,

        [Symbol("cr4")]
        CR4 = C.CR4,

        [Symbol("cr5")]
        CR5 = C.CR5,

        [Symbol("cr6")]
        CR6 = C.CR6,

        [Symbol("cr7")]
        CR7 = C.CR7,

        // ~ Debug registers
        // ~ ------------------------------------------------------------------

        [Symbol("dr0")]
        DR0 = D.DR0,

        [Symbol("dr1")]
        DR1 = D.DR1,

        [Symbol("dr2")]
        DR2 = D.DR2,

        [Symbol("dr3")]
        DR3 = D.DR3,

        [Symbol("dr4")]
        DR4 = D.DR4,

        [Symbol("dr5")]
        DR5 = D.DR5,

        [Symbol("dr6")]
        DR6 = D.DR6,

        [Symbol("dr7")]
        DR7 = D.DR7,

        // ~ Test registers
        // ~ ------------------------------------------------------------------

        [Symbol("tr0")]
        TR0 = TR.TR0,

        [Symbol("tr1")]
        TR1 = TR.TR1,

        [Symbol("tr2")]
        TR2 = TR.TR2,

        [Symbol("tr3")]
        TR3 = TR.TR3,

        [Symbol("tr4")]
        TR4 = TR.TR4,

        [Symbol("tr5")]
        TR5 = TR.TR5,

        [Symbol("tr6")]
        TR6 = TR.TR6,

        [Symbol("tr7")]
        TR7 = TR.TR7,

        // ~ BND registers
        // ~ ------------------------------------------------------------------

        [Symbol("bnd0")]
        BND0 = B.DR0,

        [Symbol("bnd1")]
        BND1 = B.DR1,

        [Symbol("bnd2")]
        BND2 = B.DR2,

        [Symbol("bnd3")]
        BND3 = B.DR3,

        // ~ FP registers
        // ~ ------------------------------------------------------------------

        [Symbol("ST(0)")]
        ST0 = ST.ST0,

        [Symbol("ST(1)")]
        ST1 = ST.ST1,

        [Symbol("ST(2)")]
        ST2 = ST.ST2,

        [Symbol("ST(3)")]
        ST3 = ST.ST3,

        [Symbol("ST(4)")]
        ST4 = ST.ST4,

        [Symbol("ST(5)")]
        ST5 = ST.ST5,

        [Symbol("ST(6)")]
        ST6 = ST.ST6,

        [Symbol("ST(7)")]
        ST7 = ST.ST7,

        // ~ MMX registers
        // ~ ------------------------------------------------------------------

        [Symbol("MM(0)")]
        MM0 = MM.MM0,

        [Symbol("MM(1)")]
        MM1 = MM.MM1,

        [Symbol("MM(2)")]
        MM2 = MM.MM2,

        [Symbol("MM(3)")]
        MM3 = MM.MM3,

        [Symbol("MM(4)")]
        MM4 = MM.MM4,

        [Symbol("MM(5)")]
        MM5 = MM.MM5,

        [Symbol("MM(6)")]
        MM6 = MM.MM6,

        [Symbol("MM(7)")]
        MM7 = MM.MM7,

        // ~ Intruction pointer registers
        // ~ ------------------------------------------------------------------

        [Symbol("ip")]
        IP = I.IP,

        [Symbol("eip")]
        EIP = I.EIP,

        [Symbol("rip")]
        RIP = I.RIP,

        // ~ System pointer registers

        [Symbol("gdtr")]
        GDTR = SPTR.GDTR,

        [Symbol("ldtr")]
        LDTR = SPTR.LDTR,

        [Symbol("idtr")]
        IDTR = SPTR.IDTR,

        [Symbol("xcr0")]
        XCR0 = XCR.XCR0,
    }
}