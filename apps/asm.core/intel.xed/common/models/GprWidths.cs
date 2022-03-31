//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using I = XedModels.GprWidthIndex;

    using static XedModels.NontermKind;

    partial struct XedModels
    {
        public readonly struct GprWidths
        {
            public static ReadOnlySpan<GprWidths> All
            {
                [MethodImpl(Inline)]
                get => core.recover<GprWidths>(WidthBytes);
            }

            [MethodImpl(Inline)]
            public static GprWidths define(byte o16, byte o32, byte o64)
                => new GprWidths(o16, o32, o64);

            [MethodImpl(Inline)]
            public static ref readonly GprWidths widths(GprWidthIndex index)
                => ref core.skip(All,(byte)index);

            public static bool widths(NontermKind src, out GprWidths dst)
            {
                dst = GprWidths.Empty;
                switch(src)
                {
                    case GPR16_B:
                        dst = widths(I.GPR16_B);
                        break;
                    case GPR16_R:
                        dst = widths(I.GPR16_R);
                        break;
                    case GPR32_B:
                        dst = widths(I.GPR32_B);
                        break;
                    case GPR32_R:
                        dst = widths(I.GPR32_R);
                        break;
                    case GPR64_B:
                        dst = widths(I.GPR64_B);
                        break;
                    case GPR64_R:
                        dst = widths(I.GPR64_R);
                        break;
                    case GPR8_B:
                        dst = widths(I.GPR8_B);
                        break;
                    case GPR8_R:
                        dst = widths(I.GPR8_R);
                        break;
                    case GPR8_SB:
                        dst = widths(I.GPR8_SB);
                        break;
                    case GPRv_B:
                        dst = widths(I.GPRv_B);
                        break;
                    case GPRv_R:
                        dst = widths(I.GPRv_R);
                        break;
                    case GPRv_SB:
                        dst = widths(I.GPRv_SB);
                        break;
                    case GPRy_B:
                        dst = widths(I.GPRy_B);
                        break;
                    case GPRy_R:
                        dst = widths(I.GPRy_R);
                        break;
                    case GPRz_B:
                        dst = widths(I.GPRz_B);
                        break;
                    case GPRz_R:
                        dst = widths(I.GPRz_R);
                        break;
                    case VGPR32_B:
                        dst = widths(I.VGPR32_B);
                        break;
                    case VGPR32_N:
                        dst = widths(I.VGPR32_N);
                        break;
                    case VGPR32_R:
                        dst = widths(I.VGPR32_R);
                        break;
                    case VGPR64_B:
                        dst = widths(I.VGPR64_B);
                        break;
                    case VGPR64_N:
                        dst = widths(I.VGPR64_N);
                        break;
                    case VGPR64_R:
                        dst = widths(I.VGPR64_R);
                        break;
                    case VGPRy_N:
                        dst = widths(I.VGPRy_N);
                    break;
                }
                return dst.IsNonEmpty;
            }

            readonly uint6 Data;

            [MethodImpl(Inline)]
            public GprWidths(byte o16, byte o32, byte o64)
                : this(Sizes.native(o16), Sizes.native(o32), Sizes.native(o64))
            {

            }

            [MethodImpl(Inline)]
            public GprWidths(NativeSize o16, NativeSize o32, NativeSize o64)
            {
                Data = BitNumbers.join((uint2)(byte)o16,(uint2)(byte)o32,(uint2)(byte)o64);
            }

            public Triple<NativeSize> Defined
            {
                [MethodImpl(Inline)]
                get => (this[w16],this[w32],this[w64]);
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

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            public string Format()
                => string.Format("{0}/{1}/{2}", this[w16].Width, this[w32].Width, this[w64].Width);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator byte(GprWidths src)
                => (byte)src.Data;

            public static GprWidths Empty => default;

            const byte GprWidthCount = 23;

            /// <summary>
            /// See apps\asm.core\intel.xed\res\gpr.widths.csv
            /// </summary>
            static ReadOnlySpan<byte> WidthBytes => new byte[GprWidthCount]{
                define(16,16,16), // GPR16_B,
                define(16,16,16), // GPR16_R,

                define(32,32,32), // GPR32_B,
                define(32,32,32), // GPR32_R,

                define(64,64,64), // GPR64_B,
                define(64,64,64), // GPR64_R,

                define(8,8,8),    // GPR8_B,
                define(8,8,8),    // GPR8_R,
                define(8,8,8),    // GPR8_SB,

                define(16,32,64), // GPRv_B,
                define(16,32,64), // GPRv_R,
                define(16,32,64), // GPRv_SB

                define(32,32,64), // GPRy_B,
                define(32,32,64), // GPRy_R,

                define(16,32,32), // GPRz_B,
                define(16,32,32), // GPRz_R,

                define(32,32,32), // VGPR32_B,
                define(32,32,32), // VGPR32_N,
                define(32,32,32), // VGPR32_R,

                define(64,64,64), // VGPR64_B,
                define(64,64,64), // VGPR64_N,
                define(64,64,64), // VGPR64_R,

                define(32,32,64), // VGPRy_N,
                };
            }
        }
}