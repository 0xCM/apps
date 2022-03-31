//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedModels.NontermKind;

    partial struct XedModels
    {
        public enum GprWidthKind : byte
        {
            GPR16_B = (byte)K.GPR16_B,

            GPR16_R = (byte)K.GPR16_R,

            GPR32_B = (byte)K.GPR32_B,

            GPR32_R = (byte)K.GPR32_R,

            GPR64_B = (byte)K.GPR64_B,

            GPR64_R = (byte)K.GPR64_R,

            GPR8_B = (byte)K.GPR8_B,

            GPR8_R = (byte)K.GPR8_R,

            GPR8_SB = (byte)K.GPR8_SB,

            GPRv_B = (byte)K.GPRv_B,

            GPRv_R = (byte)K.GPRv_R,

            GPRv_SB = (byte)K.GPRv_SB,

            GPRy_B = (byte)K.GPRy_B,

            GPRy_R = (byte)K.GPRy_R,

            GPRz_B = (byte)K.GPRz_B,

            GPRz_R = (byte)K.GPRz_R,

            VGPR32_B = (byte)K.VGPR32_B,

            VGPR32_N = (byte)K.VGPR32_N,

            VGPR32_R = (byte)K.VGPR32_R,

            VGPR64_B = (byte)K.VGPR64_B,

            VGPR64_N = (byte)K.VGPR64_N,

            VGPR64_R = (byte)K.VGPR64_R,

            VGPRy_N = (byte)K.VGPRy_N,
        }

        public enum GprWidthIndex : byte
        {
            GPR16_B,
            GPR16_R,

            GPR32_B,
            GPR32_R,

            GPR64_B,
            GPR64_R,

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

            VGPR32_B,
            VGPR32_N,
            VGPR32_R,

            VGPR64_B,
            VGPR64_N,
            VGPR64_R,

            VGPRy_N,
       }
    }
}