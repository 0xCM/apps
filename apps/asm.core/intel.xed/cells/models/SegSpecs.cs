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
            public static bool parse(string src, out SegSpec dst)
            {
                var result = false;
                dst = SegSpec.Empty;
                var i = text.index(src,Chars.FSlash);
                if(i > 0)
                {
                    var parts = text.split(src,Chars.FSlash);
                    if(parts.Length == 2)
                    {
                        ref readonly var x = ref core.skip(parts,0);
                        ref readonly var y = ref core.skip(parts,1);
                        if(x.Length == 1 && XedParsers.parse(x, out byte width))
                        {
                            ref readonly var c = ref core.first(x);
                            switch(c)
                            {
                                case Chars.a:
                                    dst = asz(width);
                                    result = true;
                                break;
                                case Chars.d:
                                    dst = brdisp(width);
                                    result = true;
                                break;
                                case Chars.i:
                                    dst = imm(width);
                                    result = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    var j = text.index(src,Chars.Underscore);
                    var k = text.index(src,Chars.Space);
                    if(j>0)
                    {
                        var parts = text.split(src,Chars.Underscore);
                        for(var m=0; j<parts.Length; m++)
                        {
                            ref readonly var part = ref core.skip(parts,m);
                        }
                    }
                    else if(k>0)
                    {
                        var parts = text.split(src,Chars.Space);
                        for(var m=0; j<parts.Length; m++)
                        {
                            ref readonly var part = ref core.skip(parts,m);
                        }
                    }
                }
                return result;
            }

            public static bool parse(FieldKind field, string src, out SegSpec dst)
            {
                var result = false;
                var i = text.index(src,Chars.FSlash);
                result = parse(src, out dst);
                if(dst.IsEmpty)
                {
                    dst = bitfield(field);
                    result = dst.IsNonEmpty;
                }
                return result;
            }

            public static SegSpec imm(byte width)
            {
                var dst = SegSpec.Empty;
                switch(width)
                {
                    case 8:
                        dst = Imm8;
                    break;
                    case 16:
                        dst = Imm16;
                    break;
                    case 32:
                        dst = Imm32;
                    break;
                    case 64:
                        dst = Imm64;
                    break;
                }
                return dst;
            }

            public static SegSpec brdisp(byte width)
            {
                var dst = SegSpec.Empty;
                switch(width)
                {
                    case 8:
                        dst = BranchDisp8;
                    break;
                    case 16:
                        dst = BranchDisp16;
                    break;
                    case 32:
                        dst = BranchDisp32;
                    break;
                    case 64:
                        dst = BranchDisp64;
                    break;
                }
                return dst;
            }

            public static SegSpec asz(byte width)
            {
                var dst = SegSpec.Empty;
                switch(width)
                {
                    case 8:
                        dst = AddressDisp8;
                    break;
                    case 16:
                        dst = AddressDisp16;
                    break;
                    case 32:
                        dst = AddressDisp32;
                    break;
                    case 64:
                        dst = AddressDisp64;
                    break;
                }
                return dst;
            }

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

            public static SegSpec BranchDisp8 => new SegSpec(DispSpec.d8, d8);

            public static SegSpec BranchDisp16 => new SegSpec(DispSpec.d16, d16);

            public static SegSpec BranchDisp32 => new SegSpec(DispSpec.d32, d32);

            public static SegSpec BranchDisp64 => new SegSpec(DispSpec.d64, d64);

            public static SegSpec AddressDisp8 => new SegSpec(SegSpecKind.Disp, a8);

            public static SegSpec AddressDisp16 => new SegSpec(SegSpecKind.Disp, a16);

            public static SegSpec AddressDisp32 => new SegSpec(SegSpecKind.Disp, a32);

            public static SegSpec AddressDisp64 => new SegSpec(SegSpecKind.Disp, a64);

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