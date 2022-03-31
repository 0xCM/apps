//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum GprWidthIndex : byte
        {
            GPRv_SB,

            GPRv_R,

            GPRv_B,

            GPRz_R,

            GPRz_B,

            GPRy_R,

            GPRy_B,

            GPR8_R,

            GPR8_B,

            GPR8_SB,

            GPR16_R,

            GPR16_B,

            GPR32_B,

            GPR32_R,

            GPR64_B,

            GPR64_R,

            VGPR32_B,

            VGPR32_R,

            VGPR32_N,

            VGPRy_N,

            VGPR64_B,

            VGPR64_R,

            VGPR64_N,
        }
    }
}