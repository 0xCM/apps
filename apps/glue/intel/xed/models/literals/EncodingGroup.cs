//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-extension-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// These identifiers were derived from function declarations in the generated file 'xed-encoder.h'
        /// </summary>
        [SymSource(xed)]
        public enum EncodingGroup : byte
        {
            None,

            [Symbol("GPR8_R()")]
            GPR8_R,

            [Symbol("GPR8_B()")]
            GPR8_B,

            [Symbol("GPR8_SB()")]
            GPR8_SB,

            SEGe,

            GPR16e,

            GPR32e,

            GPR32e_m32,

            GPR32e_m64,

            GPR64e,

            [Symbol("ArAX()")]
            ArAX,

            [Symbol("ArBX()")]
            ArBX,

            [Symbol("ArCX()")]
            ArCX,

            [Symbol("ArDX()")]
            ArDX,

            [Symbol("ArSI()")]
            ArSI,

            [Symbol("ArDI()")]
            ArDI,

            [Symbol("ArSP()")]
            ArSP,

            [Symbol("ArBP()")]
            ArBP,

            [Symbol("SrSP()")]
            SrSP,

            [Symbol("SrBP()")]
            SrBP,

            [Symbol("Ar8()")]
            Ar8,

            [Symbol("Ar9()")]
            Ar9,

            [Symbol("Ar10()")]
            Ar10,

            [Symbol("Ar11()")]
            Ar11,

            [Symbol("Ar12()")]
            Ar12,

            [Symbol("Ar13()")]
            Ar13,

            [Symbol("Ar14()")]
            Ar14,

            [Symbol("Ar15()")]
            Ar15,

            [Symbol("rIP()")]
            rIP,

            [Symbol("rIPa()")]
            rIPa,

            [Symbol("OeAX()")]
            OeAX,

            [Symbol("OrAX()")]
            OrAX,

            [Symbol("OrDX()")]
            OrDX,

            [Symbol("OrCX()")]
            OrCX,

            [Symbol("OrBX()")]
            OrBX,

            [Symbol("OrSP()")]
            OrSP,

            [Symbol("OrBP()")]
            OrBP,

            [Symbol("rFLAGS()")]
            rFLAGS,

            [Symbol("MMX_R()")]
            MMX_R,

            [Symbol("MMX_B()")]
            MMX_B,

            [Symbol("GPRv_R()", "When used as the MODRM.REG register")]
            GPRv_R,

            [Symbol("GPRv_SB()")]
            GPRv_SB,

            [Symbol("GPRz_R()")]
            GPRz_R,

            [Symbol("GPRv_B()")]
            GPRv_B,

            [Symbol("GPRz_B()")]
            GPRz_B,

            [Symbol("GPRy_B()")]
            GPRy_B,

            [Symbol("GPRy_R()")]
            GPRy_R,

            [Symbol("GPR64_R()")]
            GPR64_R,

            [Symbol("GPR64_B()")]
            GPR64_B,

            [Symbol("GPR64_SB()")]
            GPR64_SB,

            [Symbol("GPR64_X()")]
            GPR64_X,

            GPR32_R,

            GPR32_B,

            GPR32_SB,

            GPR32_X,

            GPR16_R,

            GPR16_B,

            GPR16_SB,

            CR_R,

            CR_B,

            DR_R,

            X87,

            SEG,

            SEG_MOV,

            FINAL_DSEG,

            FINAL_DSEG_NOT64,

            FINAL_DSEG_MODE64,

            FINAL_DSEG1,

            FINAL_DSEG1_NOT64,

            FINAL_DSEG1_MODE64,

            FINAL_ESEG,

            FINAL_ESEG1,

            FINAL_SSEG1,

            FINAL_SSEG0,

            FINAL_SSEG,

            FINAL_SSEG_NOT64,

            FINAL_SSEG_MODE64,

            XMM_R,

            XMM_R_32,

            XMM_R_64,

            XMM_B,

            XMM_B_32,

            XMM_B_64,

            BND_R,

            BND_B,

            A_GPR_R,

            A_GPR_B,

            XMM_SE,

            XMM_SE64,

            XMM_SE32,

            YMM_SE,

            YMM_SE64,

            YMM_SE32,

            XMM_N,

            XMM_N_32,

            XMM_N_64,

            YMM_N,

            YMM_N_32,

            YMM_N_64,

            YMM_R,

            YMM_R_32,

            YMM_R_64,

            YMM_B,

            YMM_B_32,

            YMM_B_64,

            VGPRy_R,

            VGPRy_B,

            VGPRy_N,

            VGPR32_N,

            VGPR32_B,

            VGPR32_R,

            VGPR32_N_32,

            VGPR32_N_64,

            VGPR64_N,

            VGPR32_R_32,

            VGPR32_R_64,

            VGPR64_R,

            VGPR32_B_32,

            VGPR32_B_64,

            VGPR64_B,

            MASK1,

            MASKNOT0,

            MASK_R,

            MASK_B,

            MASK_N,

            MASK_N64,

            MASK_N32,

            XMM_R3,

            XMM_R3_32,

            XMM_R3_64,

            YMM_R3,

            YMM_R3_32,

            YMM_R3_64,

            ZMM_R3,

            ZMM_R3_32,

            ZMM_R3_64,

            XMM_B3,

            XMM_B3_32,

            XMM_B3_64,

            YMM_B3,

            YMM_B3_32,

            YMM_B3_64,

            ZMM_B3,

            ZMM_B3_32,

            ZMM_B3_64,

            XMM_N3,

            XMM_N3_32,

            XMM_N3_64,

            YMM_N3,

            YMM_N3_32,

            YMM_N3_64,

            ZMM_N3,

            ZMM_N3_32,

            [Symbol("ZMM_N3_64()")]
            ZMM_N3_64,

            TMM_R,

            TMM_B,

            TMM_N,
        }
    }
}