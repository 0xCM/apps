//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XTend
    {
        public static RuleName ToRuleName(this NontermKind src)
        {
            var dst = RuleName.None;
            XedParsers.parse(src.ToString(), out dst);
            return dst;
        }

        public static RuleName ToRuleName(this Nonterminal src)
        {
            var dst = RuleName.None;
            XedParsers.parse(src.Kind.ToString(), out dst);
            return dst;
        }
    }

    partial struct XedModels
    {
        [SymSource(xed)]
        public enum NontermKind : ushort
        {
            [Symbol("")]
            None,

            Ar10 = 1,

            Ar11 = 2,

            Ar12 = 3,

            Ar13 = 4,

            Ar14 = 5,

            Ar15,

            Ar8,

            Ar9,

            ArAX,

            ArBP,

            ArBX,

            ArCX,

            ArDI,

            ArDX,

            ArSI,

            ArSP,

            ASZ_NONTERM,

            AVX512_ROUND,

            AVX_INSTRUCTIONS,

            AVX_SPLITTER,

            A_GPR_B,

            A_GPR_R,

            BND_B,

            BND_B_CHECK,

            BND_R,

            BND_R_CHECK,

            BRANCH_HINT,

            BRDISP32,

            BRDISP8,

            BRDISPz,

            CET_NO_TRACK,

            CR_B,

            CR_R,

            CR_WIDTH,

            DF64,

            DR_R,

            ESIZE_128_BITS,

            ESIZE_16_BITS,

            ESIZE_1_BITS,

            ESIZE_2_BITS,

            ESIZE_32_BITS,

            ESIZE_4_BITS,

            ESIZE_64_BITS,

            ESIZE_8_BITS,

            EVEX_INSTRUCTIONS,

            EVEX_SPLITTER,

            FINAL_DSEG,

            FINAL_DSEG1,

            FINAL_DSEG1_MODE64,

            FINAL_DSEG1_NOT64,

            FINAL_DSEG_MODE64,

            FINAL_DSEG_NOT64,

            FINAL_ESEG,

            FINAL_ESEG1,

            FINAL_SSEG,

            FINAL_SSEG0,

            FINAL_SSEG1,

            FINAL_SSEG_MODE64,

            FINAL_SSEG_NOT64,

            FIX_ROUND_LEN128,

            FIX_ROUND_LEN512,

            FORCE64,

            GPR16_B,

            GPR16_R,

            GPR16_SB,

            GPR32_B,

            GPR32_R,

            GPR32_SB,

            GPR32_X,

            GPR64_B,

            GPR64_R,

            GPR64_SB,

            GPR64_X,

            GPR8_B,

            GPR8_R,

            GPR8_SB,

            GPRv_B,

            GPRv_R,

            GPRv_SB,

            GPRy_B,

            GPRy_R,

            GPRz_B,

            GPRz_R,

            IGNORE66,

            IMMUNE66,

            IMMUNE66_LOOP64,

            IMMUNE_REXW,

            INSTRUCTIONS,

            ISA,

            MASK1,

            MASKNOT0,

            MASK_B,

            MASK_N,

            MASK_N32,

            MASK_N64,

            MASK_R,

            MEMDISP,

            MEMDISP16,

            MEMDISP32,

            MEMDISP8,

            MEMDISPv,

            MMX_B,

            MMX_R,

            MODRM,

            MODRM16,

            MODRM32,

            MODRM64ALT32,

            NELEM_EIGHTHMEM,

            NELEM_FULL,

            NELEM_FULLMEM,

            NELEM_GPR_READER,

            NELEM_GPR_READER_BYTE,

            NELEM_GPR_READER_SUBDWORD,

            NELEM_GPR_READER_WORD,

            NELEM_GPR_WRITER_LDOP,

            NELEM_GPR_WRITER_LDOP_D,

            NELEM_GPR_WRITER_LDOP_Q,

            NELEM_GPR_WRITER_STORE,

            NELEM_GPR_WRITER_STORE_BYTE,

            NELEM_GPR_WRITER_STORE_SUBDWORD,

            NELEM_GPR_WRITER_STORE_WORD,

            NELEM_GSCAT,

            NELEM_HALF,

            NELEM_HALFMEM,

            NELEM_MEM128,

            NELEM_MOVDDUP,

            NELEM_QUARTERMEM,

            NELEM_SCALAR,

            NELEM_TUPLE1,

            NELEM_TUPLE1_4X,

            NELEM_TUPLE1_BYTE,

            NELEM_TUPLE1_SUBDWORD,

            NELEM_TUPLE1_WORD,

            NELEM_TUPLE2,

            NELEM_TUPLE4,

            NELEM_TUPLE8,

            OeAX,

            ONE,

            OrAX,

            OrBP,

            OrBX,

            OrCX,

            OrDX,

            OrSP,

            OSZ_NONTERM,

            OVERRIDE_SEG0,

            OVERRIDE_SEG1,

            PREFIXES,

            REFINING66,

            REMOVE_SEGMENT,

            rFLAGS,

            rIP,

            rIPa,

            SAE,

            SEG,

            SEG_MOV,

            SE_IMM8,

            SIB,

            SIB_BASE0,

            SIMM8,

            SIMMz,

            SRBP,

            SRSP,

            TMM_B,

            TMM_N,

            TMM_R,

            UIMM16,

            UIMM32,

            UIMM8,

            UIMM8_1,

            UIMMv,

            UISA_VMODRM_XMM,

            UISA_VMODRM_YMM,

            UISA_VMODRM_ZMM,

            UISA_VSIB_BASE,

            UISA_VSIB_INDEX_XMM,

            UISA_VSIB_INDEX_YMM,

            UISA_VSIB_INDEX_ZMM,

            UISA_VSIB_XMM,

            UISA_VSIB_YMM,

            UISA_VSIB_ZMM,

            VGPR32_B,

            VGPR32_B_32,

            VGPR32_B_64,

            VGPR32_N,

            VGPR32_N_32,

            VGPR32_N_64,

            VGPR32_R,

            VGPR32_R_32,

            VGPR32_R_64,

            VGPR64_B,

            VGPR64_N,

            VGPR64_R,

            VGPRy_B,

            VGPRy_N,

            VGPRy_R,

            VMODRM_XMM,

            VMODRM_YMM,

            VSIB_BASE,

            VSIB_INDEX_XMM,

            VSIB_INDEX_YMM,

            VSIB_XMM,

            VSIB_YMM,

            X87,

            XMM_B,

            XMM_B3,

            XMM_B3_32,

            XMM_B3_64,

            XMM_B_32,

            XMM_B_64,

            XMM_N,

            XMM_N3,

            XMM_N3_32,

            XMM_N3_64,

            XMM_N_32,

            XMM_N_64,

            XMM_R,

            XMM_R3,

            XMM_R3_32,

            XMM_R3_64,

            XMM_R_32,

            XMM_R_64,

            XMM_SE,

            XMM_SE32,

            XMM_SE64,

            XOP_INSTRUCTIONS,

            YMM_B,

            YMM_B3,

            YMM_B3_32,

            YMM_B3_64,

            YMM_B_32,

            YMM_B_64,

            YMM_N,

            YMM_N3,

            YMM_N3_32,

            YMM_N3_64,

            YMM_N_32,

            YMM_N_64,

            YMM_R,

            YMM_R3,

            YMM_R3_32,

            YMM_R3_64,

            YMM_R_32,

            YMM_R_64,

            YMM_SE,

            YMM_SE32,

            YMM_SE64,

            ZMM_B3,

            ZMM_B3_32,

            ZMM_B3_64,

            ZMM_N3,

            ZMM_N3_32,

            ZMM_N3_64,

            ZMM_R3,

            ZMM_R3_32,

            ZMM_R3_64,

            GPR32e_m32,

            MODRM64alt32,

            GPR32e_m64,

            GPR32e,

            SEGe,

            GPR16e,

            GPR64e,

            SrSP,

            SrBP,

            MODRM_MOD_EA16_DISP0,

            MODRM_MOD_EA16_DISP8,

            MODRM_MOD_EA16_DISP16,

            MODRM_MOD_EA32_DISP0,

            MODRM_MOD_EA32_DISP8,

            MODRM_MOD_EA32_DISP32,

            MODRM_MOD_EA64_DISP0,

            MODRM_MOD_EA64_DISP8,

            MODRM_MOD_EA64_DISP32,

            ERROR,

            MODRM_RM_ENCODE_EA16_SIB0,

            MODRM_RM_ENCODE_EA32_SIB0,

            MODRM_RM_ENCODE_EA64_SIB0,

            MODRM_RM_ENCODE_EANOT16_SIB1,

            DISP_WIDTH_16,

            DISP_WIDTH_0_8_16,

            DISP_WIDTH_32,

            DISP_WIDTH_0_8_32,

            REMOVE_SEGMENT_AGEN1,

            SIBBASE_ENCODE_SIB1,

            SIBINDEX_ENCODE_SIB1,

            DISP_WIDTH_8_32,

            XOP_ENC,

            EVEX_ENC,

            REX_PREFIX_ENC,

            NEWVEX_ENC,

            FIXUP_EOSZ_ENC,

            FIXUP_EASZ_ENC,

            PREFIX_ENC,

            VEXED_REX,

            OSZ_NONTERM_ENC,

            SIB_REQUIRED_ENCODE,

            SIBSCALE_ENCODE,

            SIBINDEX_ENCODE,

            SIBBASE_ENCODE,

            MODRM_RM_ENCODE,

            MODRM_MOD_ENCODE,

            SEGMENT_DEFAULT_ENCODE,

            SEGMENT_ENCODE,

            SIB_NT,

            DISP_NT,

            VEX_TYPE_ENC,

            VEX_REXR_ENC,

            VEX_REXXB_ENC,

            VEX_MAP_ENC,

            VEX_REG_ENC,

            VEX_ESCVL_ENC,

            EVEX_62_REXR_ENC_BIND,

            EVEX_REXX_ENC_BIND,

            EVEX_REXB_ENC_BIND,

            EVEX_REXRR_ENC_BIND,

            EVEX_MAP_ENC_BIND,

            EVEX_REXW_VVVV_ENC_BIND,

            EVEX_UPP_ENC_BIND,

            EVEX_LL_ENC_BIND,

            AVX512_EVEX_BYTE3_ENC_BIND,
       }
    }
}