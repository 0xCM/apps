//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct SegSpecs
        {
            public static SegSpec find(SegSpecType type)
                => new SegSpec(type, XedLookups.Service.SegSpecPattern(type.Id));

            public static SegSpec find(string pattern)
                => new SegSpec(new(XedLookups.Service.SegSpecId(pattern)), pattern);

            // static SegSpecType type(string src)
            //     => new SegSpecType(XedLookups.Service.SegSpecId(src));

            // public static SegSpec Mask => new SegSpec(type(aaa), Chars.a, Chars.a, Chars.a);

            // public static SegSpec SibBase => new SegSpec(type(bbb), Chars.b, Chars.b, Chars.b);

            // public static SegSpec SibIndex => new SegSpec(type(iii), Chars.i, Chars.i, Chars.i);

            // public static SegSpec SibScale => new SegSpec(type(ss), Chars.s, Chars.s);

            // public static SegSpec Llrc => new SegSpec(type(nn), Chars.n, Chars.n);

            // public static SegSpec Bcrc => new SegSpec(type(b), Chars.b);

            // public static SegSpec Zero => new SegSpec(type(z), Chars.z);

            // public static SegSpec RexW => new SegSpec(type(w), Chars.w);

            // public static SegSpec RexR => new SegSpec(type(r), Chars.r);

            // public static SegSpec RexX => new SegSpec(type(x), Chars.x);

            // public static SegSpec RexB => new SegSpec(type(b), Chars.b);

            // public static SegSpec VexDest3 =>  new SegSpec(type(u), Chars.u);

            // public static SegSpec VexDest210 =>  new SegSpec(type(ddd), Chars.d, Chars.d, Chars.d);

            // public static SegSpec Disp8 => new SegSpec(type(d8), d8);

            // public static SegSpec Disp16 => new SegSpec(type(d16), d16);

            // public static SegSpec Disp32 => new SegSpec(type(d32), d32);

            // public static SegSpec Disp64 => new SegSpec(type(d64), d64);

            // public static SegSpec AddressDisp8 => new SegSpec(type(a8), a8);

            // public static SegSpec AddressDisp16 => new SegSpec(type(a16), a16);

            // public static SegSpec AddressDisp32 => new SegSpec(type(a32), a32);

            // public static SegSpec AddressDisp64 => new SegSpec(type(a64), a64);

            // public static SegSpec Imm8 => new SegSpec(type(i8), i8);

            // public static SegSpec Imm16 => new SegSpec(type(i16), i16);

            // public static SegSpec Imm32 => new SegSpec(type(i32), i32);

            // public static SegSpec Imm64 => new SegSpec(type(i64), i64);
        }
    }
}