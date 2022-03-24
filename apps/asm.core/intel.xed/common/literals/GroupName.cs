//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// These identifiers were derived from function declarations in the generated file 'xed-encoder.h'
        /// </summary>
        [SymSource(xed)]
        public enum GroupName : byte
        {
            INVALID = 0,

            // GPR8_R,

            // GPR8_B,

            //GPR8_SB,

            SEGe,

            GPR16e,

            GPR32e,

            GPR32e_m32,

            GPR32e_m64,

            GPR64e,

            // ArAX,

            //ArBX,

            //ArCX,

            //ArDX,

            //ArSI,

            //ArDI,

            //ArSP,

            //ArBP,

            SrSP,

            SrBP,

            // Ar8,

            // Ar9,

            // Ar10,

            // Ar11,

            // Ar12,

            // Ar13,

            // Ar14,

            // Ar15,

            // rIP,

            // rIPa,

            //OeAX,

            //OrAX,

            //OrDX,

            //OrCX,

            //OrBX,

            //OrSP,

            //OrBP,

            //rFLAGS,

            // MMX_R,

            // MMX_B,

            //GPRv_R,

            //GPRv_SB,

            //GPRz_R,

            //GPRv_B,

            //GPRz_B,


            //GPRy_B,

            //GPRy_R,

            //GPR64_R,

            GPR64_B,

            GPR64_SB,

            // GPR64_X,

            // GPR32_R,

            // GPR32_B,

            // GPR32_SB,

            GPR32_X,

            //GPR16_R,

            //GPR16_B,

            //GPR16_SB,

            // CR_R,

            // CR_B,

            // DR_R,

            X87,

            SEG,

            //SEG_MOV,

            //FINAL_DSEG,

            // FINAL_DSEG_NOT64,

            // FINAL_DSEG_MODE64,

            // FINAL_DSEG1,

            //FINAL_DSEG1_NOT64,

            //FINAL_DSEG1_MODE64,

            // FINAL_ESEG,

            // FINAL_ESEG1,

            // FINAL_SSEG1,

            //FINAL_SSEG0,

            //FINAL_SSEG,

            //FINAL_SSEG_NOT64,

            //FINAL_SSEG_MODE64,

            // XMM_R,

            // XMM_R_32,

            // XMM_R_64,

            // XMM_B,

            // XMM_B_32,

            // XMM_B_64,

            // BND_R,

            //BND_B,

            //A_GPR_R,

            //A_GPR_B,

            // XMM_SE,

            // XMM_SE64,

            // XMM_SE32,

            // YMM_SE,

            // YMM_SE64,

            // YMM_SE32,

            // XMM_N,

            // XMM_N_32,

            // XMM_N_64,

            // YMM_N,

            // YMM_N_32,

            // YMM_N_64,

            // YMM_R,

            // YMM_R_32,

            // YMM_R_64,

            // YMM_B,

            // YMM_B_32,

            // YMM_B_64,

            VGPRy_R,

            VGPRy_B,

            VGPRy_N,

            // VGPR32_N,

            // VGPR32_B,

            VGPR32_R,

            VGPR32_N_32,

            VGPR32_N_64,

            VGPR64_N,

            VGPR32_R_32,

            VGPR32_R_64,

            VGPR64_R,

            //VGPR32_B_32,

            VGPR32_B_64,

            VGPR64_B,

            //MASK1,

            //MASKNOT0,

            // MASK_R,

            // MASK_B,

            // MASK_N,

            // MASK_N64,

            // MASK_N32,

            //XMM_R3,

            //XMM_R3_32,

            //XMM_R3_64,

            // YMM_R3,

            // YMM_R3_32,

            // YMM_R3_64,

            // ZMM_R3,

            //ZMM_R3_32,

            //ZMM_R3_64,

            // XMM_B3,

            // XMM_B3_32,

            // XMM_B3_64,

            // YMM_B3,

            //YMM_B3_32,

            //YMM_B3_64,

            //ZMM_B3,

            //ZMM_B3_32,

            //ZMM_B3_64,

            // XMM_N3,

            // XMM_N3_32,

            // XMM_N3_64,

            // YMM_N3,

            // YMM_N3_32,

            // YMM_N3_64,

            // ZMM_N3,

            // ZMM_N3_32,

            // ZMM_N3_64,

            // TMM_R,

            // TMM_B,

            // TMM_N,
        }
    }
}