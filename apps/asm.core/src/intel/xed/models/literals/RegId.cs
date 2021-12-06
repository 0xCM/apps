//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-reg-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum RegId : ushort
        {
            None,

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

            ST0,

            ST1,

            ST2,

            ST3,

            ST4,

            ST5,

            ST6,

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

            BNDCFG_FIRST=BNDCFGU,

            BNDCFG_LAST=BNDCFGU,

            BNDSTAT_FIRST=BNDSTATUS,

            BNDSTAT_LAST=BNDSTATUS,

            BOUND_FIRST=BND0,

            BOUND_LAST=BND3,

            CR_FIRST=CR0,

            CR_LAST=CR15,

            DR_FIRST=DR0,

            DR_LAST=DR7,

            FLAGS_FIRST=FLAGS,

            FLAGS_LAST=RFLAGS,

            GPR16_FIRST=AX,

            GPR16_LAST=R15W,

            GPR32_FIRST=EAX,

            GPR32_LAST=R15D,

            GPR64_FIRST=RAX,

            GPR64_LAST=R15,

            GPR8_FIRST=AL,

            GPR8_LAST=R15B,

            GPR8h_FIRST=AH,

            GPR8h_LAST=BH,

            INVALID_FIRST=None,

            INVALID_LAST=ERROR,

            IP_FIRST=RIP,

            IP_LAST=IP,

            MASK_FIRST=K0,

            MASK_LAST=K7,

            MMX_FIRST=MMX0,

            MMX_LAST=MMX7,

            MSR_FIRST=SSP,

            MSR_LAST=IA32_U_CET,

            MXCSR_FIRST=MXCSR,

            MXCSR_LAST=MXCSR,

            PSEUDO_FIRST=STACKPUSH,

            PSEUDO_LAST=TILECONFIG,

            PSEUDOX87_FIRST=X87CONTROL,

            PSEUDOX87_LAST=X87LASTDP,

            SR_FIRST=ES,

            SR_LAST=GS,

            TMP_FIRST=TMP0,

            TMP_LAST=TMP15,

            TREG_FIRST=TMM0,

            TREG_LAST=TMM7,

            UIF_FIRST=UIF,

            UIF_LAST=UIF,

            X87_FIRST=ST0,

            X87_LAST=ST7,

            XCR_FIRST=XCR0,

            XCR_LAST=XCR0,

            XMM_FIRST=XMM0,

            XMM_LAST=XMM31,

            YMM_FIRST=YMM0,

            YMM_LAST=YMM31,

            ZMM_FIRST=ZMM0,

            ZMM_LAST=ZMM31
        }
    }
}