//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.FieldKind;

    using static XedRules.SegSpecLiterals;

    partial class XedRules
    {
        public readonly struct SegSpecs
        {
            public static SegSpec imm(ImmSpec spec)
            {
                var dst = SegSpec.Empty;
                switch(spec)
                {
                    case ImmSpec.i8:
                        dst = Imm8;
                    break;
                    case ImmSpec.i16:
                        dst = Imm16;
                    break;
                    case ImmSpec.i32:
                        dst = Imm32;
                    break;
                    case ImmSpec.i64:
                        dst = Imm64;
                    break;
                }
                return dst;
            }

            public static SegSpec imm(byte width)
                => imm((ImmSpec)width);

            public static SegSpec disp(DispSpec spec)
            {
                var dst = SegSpec.Empty;
                switch(spec)
                {
                    case DispSpec.d8:
                        dst = Disp8;
                    break;
                    case DispSpec.d16:
                        dst = Disp16;
                    break;
                    case DispSpec.d32:
                        dst = Disp32;
                    break;
                    case DispSpec.d64:
                        dst = Disp64;
                    break;
                }
                return dst;
            }

            public static SegSpec disp(byte width)
                => disp((DispSpec)width);

            public static SegSpec addressdisp(AddressDispSpec spec)
            {
                var dst = SegSpec.Empty;
                switch(spec)
                {
                    case AddressDispSpec.a8:
                        dst = AddressDisp8;
                    break;
                    case AddressDispSpec.a16:
                        dst = AddressDisp16;
                    break;
                    case AddressDispSpec.a32:
                        dst = AddressDisp32;
                    break;
                    case AddressDispSpec.a64:
                        dst = AddressDisp64;
                    break;
                }
                return dst;
            }

            public static SegSpec addressdisp(byte width)
                => addressdisp((AddressDispSpec)width);

            public static SegSpec bitfield(FieldKind src)
            {
                var dst = SegSpec.Empty;
                switch(src)
                {
                    case K.VEXDEST3:
                        dst = VexDest3;
                    break;
                    case K.VEXDEST210:
                        dst = VexDest210;
                    break;
                    case K.REXX:
                        dst = RexX;
                    break;
                    case K.REXB:
                        dst = RexB;
                    break;
                    case K.REXR:
                        dst = RexR;
                    break;
                    case K.REXW:
                        dst = RexW;
                    break;
                    case K.SIBBASE:
                        dst = SibBase;
                    break;
                    case K.SIBINDEX:
                        dst = SibIndex;
                    break;
                    case K.SIBSCALE:
                        dst = SibScale;
                    break;
                    case K.LLRC:
                        dst = Llrc;
                    break;
                    case K.BCRC:
                        dst = Bcrc;
                    break;
                    case K.MASK:
                        dst = Mask;
                    break;
                    case K.ZEROING:
                        dst = Zero;
                    break;
                }
                return dst;
            }

            public static SegSpec Sib => new SegSpec(SegSpecKind.Bitfield, ss_iii_bbb);

            public static SegSpec SibBase => new SegSpec(SegSpecKind.Bitfield, bbb);

            public static SegSpec SibIndex => new SegSpec(SegSpecKind.Bitfield, iii);

            public static SegSpec SibScale => new SegSpec(SegSpecKind.Bitfield, ss);

            public static SegSpec Znnb => new SegSpec(SegSpecKind.Bitfield, z_nn_b);

            public static SegSpec Llrc => new SegSpec(SegSpecKind.Bitfield, nn);

            public static SegSpec Bcrc => new SegSpec(SegSpecKind.Bitfield, b);

            public static SegSpec Zero => new SegSpec(SegSpecKind.Bitfield, z);

            public static SegSpec Mask => new SegSpec(SegSpecKind.Bitfield, aaa);

            public static SegSpec Disp8 => new SegSpec(DispSpec.d8, d8);

            public static SegSpec Disp16 => new SegSpec(DispSpec.d16, d16);

            public static SegSpec Disp32 => new SegSpec(DispSpec.d32, d32);

            public static SegSpec Disp64 => new SegSpec(DispSpec.d64, d64);

            public static SegSpec AddressDisp8 => new SegSpec(AddressDispSpec.a8, a8);

            public static SegSpec AddressDisp16 => new SegSpec(AddressDispSpec.a16, a16);

            public static SegSpec AddressDisp32 => new SegSpec(AddressDispSpec.a32, a32);

            public static SegSpec AddressDisp64 => new SegSpec(AddressDispSpec.a64, a64);

            public static SegSpec Imm8 => new SegSpec(ImmSpec.i8, i8);

            public static SegSpec Imm16 => new SegSpec(ImmSpec.i16, i16);

            public static SegSpec Imm32 => new SegSpec(ImmSpec.i32, i32);

            public static SegSpec Imm64 => new SegSpec(ImmSpec.i64, i64);

            public static SegSpec RexW => new SegSpec(SegSpecKind.Bitfield, Chars.w);

            public static SegSpec RexR => new SegSpec(SegSpecKind.Bitfield, Chars.r);

            public static SegSpec RexX => new SegSpec(SegSpecKind.Bitfield, Chars.x);

            public static SegSpec RexB => new SegSpec(SegSpecKind.Bitfield, Chars.b);

            public static SegSpec VexDest3 =>  new SegSpec(SegSpecKind.Bitfield, Chars.u);

            public static SegSpec VexDest210 =>  new SegSpec(SegSpecKind.Bitfield, ddd);
        }
    }
}