//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-iclass-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static XedModels.OperandKind;

    partial struct XedModels
    {
        [MethodImpl(Inline), Op]
        public static bool is_memory_addressing_register(OperandKind kind)
            => kind == BASE0 || kind == BASE1 ||
              kind == SEG0  || kind == SEG1 ||
              kind == INDEX;

        [MethodImpl(Inline), Op]
        public static bool is_register(OperandKind kind)
            => kind >= REG0 && kind <= REG9;

        [MethodImpl(Inline), Op]
        public static bool is_memory(OperandKind kind)
            => kind == MEM0 || kind == MEM1;

        [MethodImpl(Inline), Op]
        public static bool is_imm(OperandKind kind)
            => kind == IMM0 || kind == IMM1;

        [Op]
        public static sbyte reg_index(OperandKind kind)
            => kind switch
            {
                REG0 => 0,
                REG1 => 1,
                REG2 => 2,
                REG3 => 3,
                REG4 => 4,
                REG5 => 5,
                REG6 => 6,
                REG7 => 7,
                REG8 => 8,
                REG9 => 9,
                _ => -1,
            };

        [Op]
        public static sbyte base_reg_index(OperandKind kind)
            => kind switch
            {
                BASE0 => 0,
                BASE1 => 1,
                _ => -1,
            };

        [Op]
        public static sbyte seg_reg_index(OperandKind kind)
            => kind switch
            {
                SEG0 => 0,
                SEG1 => 1,
                _ => -1,
            };

        [Op]
        public static sbyte imm_index(OperandKind kind)
            => kind switch
            {
                IMM0 => 0,
                IMM1 => 1,
                _ => -1,
            };

        [Op]
        public static sbyte mem_index(OperandKind kind)
            => kind switch
            {
                MEM0 => 0,
                MEM1 => 1,
                _ => -1,
            };

        [SymSource(xed)]
        public enum OperandKind : byte
        {
            INVALID,

            AGEN,

            AMD3DNOW,

            ASZ,

            BASE0,

            BASE1,

            BCAST,

            BCRC,

            BRDISP_WIDTH,

            CET,

            CHIP,

            CLDEMOTE,

            DEFAULT_SEG,

            DF32,

            DF64,

            DISP,

            DISP_WIDTH,

            DUMMY,

            EASZ,

            ELEMENT_SIZE,

            ENCODER_PREFERRED,

            ENCODE_FORCE,

            EOSZ,

            ERROR,

            ESRC,

            FIRST_F2F3,

            HAS_MODRM,

            HAS_SIB,

            HINT,

            ICLASS,

            ILD_F2,

            ILD_F3,

            ILD_SEG,

            IMM0,

            IMM0SIGNED,

            IMM1,

            IMM1_BYTES,

            IMM_WIDTH,

            INDEX,

            LAST_F2F3,

            LLRC,

            LOCK,

            LZCNT,

            MAP,

            MASK,

            MAX_BYTES,

            MEM0,

            MEM1,

            MEM_WIDTH,

            MOD,

            MODE,

            MODEP5,

            MODEP55C,

            MODE_FIRST_PREFIX,

            MODRM_BYTE,

            MPXMODE,

            MUST_USE_EVEX,

            NEEDREX,

            NEED_MEMDISP,

            NEED_SIB,

            NELEM,

            NOMINAL_OPCODE,

            NOREX,

            NO_SCALE_DISP8,

            NPREFIXES,

            NREXES,

            NSEG_PREFIXES,

            OSZ,

            OUTREG,

            OUT_OF_BYTES,

            P4,

            POS_DISP,

            POS_IMM,

            POS_IMM1,

            POS_MODRM,

            POS_NOMINAL_OPCODE,

            POS_SIB,

            PREFIX66,

            PTR,

            REALMODE,

            REG,

            REG0,

            REG1,

            REG2,

            REG3,

            REG4,

            REG5,

            REG6,

            REG7,

            REG8,

            REG9,

            RELBR,

            REP,

            REX,

            REXB,

            REXR,

            REXRR,

            REXW,

            REXX,

            RM,

            ROUNDC,

            SAE,

            SCALE,

            SEG0,

            SEG1,

            SEG_OVD,

            SIBBASE,

            SIBINDEX,

            SIBSCALE,

            SMODE,

            SRM,

            TZCNT,

            UBIT,

            UIMM0,

            UIMM1,

            USING_DEFAULT_SEGMENT0,

            USING_DEFAULT_SEGMENT1,

            VEXDEST210,

            VEXDEST3,

            VEXDEST4,

            VEXVALID,

            VEX_C4,

            VEX_PREFIX,

            VL,

            WBNOINVD,

            ZEROING,

            LAST
        }
    }
}