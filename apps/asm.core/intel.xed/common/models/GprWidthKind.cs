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
            GPRv_SB = (byte)K.GPRv_SB,

            GPRv_R = (byte)K.GPRv_R,

            GPRv_B = (byte)K.GPRv_B,

            GPRz_R = (byte)K.GPRz_R,

            GPRz_B = (byte)K.GPRz_B,

            GPRy_R = (byte)K.GPRy_R,

            GPRy_B = (byte)K.GPRy_B,

            GPR8_R = (byte)K.GPR8_R,

            GPR8_B = (byte)K.GPR8_B,

            GPR8_SB = (byte)K.GPR8_SB,

            GPR16_R = (byte)K.GPR16_R,

            GPR16_B = (byte)K.GPR16_B,

            GPR32_B = (byte)K.GPR32_B,

            GPR32_R = (byte)K.GPR32_R,

            GPR64_B = (byte)K.GPR64_B,

            GPR64_R = (byte)K.GPR64_R,

            VGPR32_B = (byte)K.VGPR32_B,

            VGPR32_R = (byte)K.VGPR32_R,

            VGPR32_N = (byte)K.VGPR32_N,

            VGPRy_N = (byte)K.VGPRy_N,

            VGPR64_B = (byte)K.VGPR64_B,

            VGPR64_R = (byte)K.VGPR64_R,

            VGPR64_N = (byte)K.VGPR64_N,
        }
    }
}