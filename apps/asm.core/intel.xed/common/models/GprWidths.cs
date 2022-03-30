//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.GprWidths;
/*
# xed/pysrc/enc2gen.py
# list indexed by OSZ (o16,o32,o64)
# gpr_nt_widths_dict['GPRv_SB'] = [16,32,64]
# gpr_nt_widths_dict['GPRv_R'] = [16,32,64]
# gpr_nt_widths_dict['GPRv_B'] = [16,32,64]
# gpr_nt_widths_dict['GPRz_R'] = [16,32,32]
# gpr_nt_widths_dict['GPRz_B'] = [16,32,32]
# gpr_nt_widths_dict['GPRy_R'] = [32,32,64]
# gpr_nt_widths_dict['GPRy_B'] = [32,32,64]

# gpr_nt_widths_dict['GPR8_R'] = [8,8,8]
# gpr_nt_widths_dict['GPR8_B'] = [8,8,8]
# gpr_nt_widths_dict['GPR8_SB'] = [8,8,8]
# gpr_nt_widths_dict['GPR16_R'] = [16,16,16]
# gpr_nt_widths_dict['GPR16_B'] = [16,16,16]
# gpr_nt_widths_dict['GPR32_B'] = [32,32,32]
# gpr_nt_widths_dict['GPR32_R'] = [32,32,32]
# gpr_nt_widths_dict['GPR64_B'] = [64,64,64]
# gpr_nt_widths_dict['GPR64_R'] = [64,64,64]
# gpr_nt_widths_dict['VGPR32_B'] = [32,32,32]
# gpr_nt_widths_dict['VGPR32_R'] = [32,32,32]
# gpr_nt_widths_dict['VGPR32_N'] = [32,32,32]
# gpr_nt_widths_dict['VGPRy_N'] = [32,32,64]

# gpr_nt_widths_dict['VGPR64_B'] = [64,64,64]
# gpr_nt_widths_dict['VGPR64_R'] = [64,64,64]
# gpr_nt_widths_dict['VGPR64_N'] = [64,64,64]

*/
    using K = XedModels.NontermKind;

    partial struct XedModels
    {
        static ReadOnlySpan<GprWidths> GprWidthData
        {
            [MethodImpl(Inline)]
            get => core.recover<GprWidths>(GprWidthBytes);
        }

        static ReadOnlySpan<byte> GprWidthBytes => new byte[]{
            define(16,32,64), // GPRv_SB

            define(16,32,64), // GPRv_R,
            define(16,32,64), // GPRv_B,

            define(16,32,32), // GPRz_R,
            define(16,32,32), // GPRz_B,

            define(32,32,64), // GPRy_R,
            define(32,32,64), // GPRy_B,

            define(8,8,8),    // GPR8_R,
            define(8,8,8),    // GPR8_B,

            define(8,8,8),    // GPR8_SB,

            define(16,16,16), // GPR16_R,
            define(16,16,16), // GPR16_B,

            define(32,32,32), // GPR32_B,
            define(32,32,32), // GPR32_R,

            define(64,64,64), // GPR64_B,
            define(64,64,64), // GPR64_R,
            define(32,32,32), // VGPR32_B,
            define(32,32,32), // VGPR32_R,
            define(32,32,32), // VGPR32_N,
            define(32,32,64), // VGPRy_N,

            define(64,64,64), // VGPR64_B,
            define(64,64,64), // VGPR64_R,
            define(64,64,64), // VGPR64_N,
            };

        public enum GprWidthKind : ushort
        {
            GPRv_SB = K.GPRv_SB,

            GPRv_R = K.GPRv_R,

            GPRv_B = K.GPRv_B,

            GPRz_R = K.GPRz_R,

            GPRz_B = K.GPRz_B,

            GPRy_R = K.GPRy_R,

            GPRy_B = K.GPRy_B,

            GPR8_R = K.GPR8_R,

            GPR8_B = K.GPR8_B,

            GPR8_SB = K.GPR8_SB,

            GPR16_R = K.GPR16_R,

            GPR16_B = K.GPR16_B,

            GPR32_B = K.GPR32_B,

            GPR32_R = K.GPR32_R,

            GPR64_B = K.GPR64_B,

            GPR64_R = K.GPR64_R,

            VGPR32_B = K.VGPR32_B,

            VGPR32_R = K.VGPR32_R,

            VGPR32_N = K.VGPR32_N,

            VGPRy_N = K.VGPRy_N,

            VGPR64_B = K.VGPR64_B,

            VGPR64_R = K.VGPR64_R,

            VGPR64_N = K.VGPR64_N,
        }

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

        public readonly struct GprWidths
        {
            [MethodImpl(Inline)]
            public static ref readonly GprWidths lookup(GprWidthIndex index)
                => ref core.skip(GprWidthData,(byte)index);

            [MethodImpl(Inline)]
            public static GprWidths define(byte o16, byte o32, byte o64)
                => new GprWidths(o16,o32,o64);

            readonly uint6 Data;

            [MethodImpl(Inline)]
            public GprWidths(byte o16, byte o32, byte o64)
                : this(Sizes.native(o16),Sizes.native(o32),Sizes.native(o64))
            {

            }

            [MethodImpl(Inline)]
            public GprWidths(NativeSize o16, NativeSize o32, NativeSize o64)
            {
                Data = BitNumbers.join((uint2)(byte)o16,(uint2)(byte)o32,(uint2)(byte)o64);
            }

            public NativeSize this[NativeSize w]
            {
                [MethodImpl(Inline)]
                get => w == NativeSizeCode.W16 ? this[w16] : w == NativeSizeCode.W32 ? this[w32] : w == NativeSizeCode.W64 ? this[w64] : NativeSizeCode.W8;
            }

            public NativeSize this[W16 w]
            {
                [MethodImpl(Inline)]
                get => (NativeSizeCode)(byte)(Data & uint2.Max);
            }

            public NativeSize this[W32 w]
            {
                [MethodImpl(Inline)]
                get => (NativeSizeCode)(byte)((Data >> 2) & uint2.Max);
            }

            public NativeSize this[W64 w]
            {
                [MethodImpl(Inline)]
                get => (NativeSizeCode)(byte)((Data >> 4) & uint2.Max);
            }

            [MethodImpl(Inline)]
            public static implicit operator byte(GprWidths src)
                => (byte)src.Data;
        }
    }
}