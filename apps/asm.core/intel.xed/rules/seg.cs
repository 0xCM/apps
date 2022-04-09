//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static Seg seg(FieldKind field, asci8 value)
            => new Seg(field, (byte)value.Length, value);

        [MethodImpl(Inline), Op]
        public static Seg seg(FieldKind field, char c0)
            => new Seg(field, 1, new (c0));

        [MethodImpl(Inline), Op]
        public static Seg seg(FieldKind field, char c0, char c1)
            => new Seg(field, 2, new (c0,c1));

        [MethodImpl(Inline), Op]
        public static Seg seg(FieldKind field, char c0, char c1, char c2)
            => new Seg(field, 3, new (c0,c1,c2));

        [MethodImpl(Inline), Op]
        public static Seg seg(N1 n, FieldKind field, bit b0)
            => new Seg(field, n, new (b0.ToChar()));

        [MethodImpl(Inline), Op]
        public static Seg seg(N2 n, FieldKind field, byte value)
            => new Seg(field, n, BitRender.render2(value, out asci8 _));

        [MethodImpl(Inline), Op]
        public static Seg seg(N2 n, FieldKind field, bit b0, bit b1)
            => new Seg(field, n, new (b0.ToChar(),b1.ToChar()));

        [MethodImpl(Inline), Op]
        public static Seg seg(N3 n, FieldKind field, byte value)
            => new Seg(field, n, BitRender.render3(value, out asci8 _));

        [MethodImpl(Inline), Op]
        public static Seg seg(N3 n, FieldKind field, bit b0, bit b1, bit b2)
            => new Seg(field, n, new (b0.ToChar(), b1.ToChar(), b2.ToChar()));

        [MethodImpl(Inline), Op]
        public static Seg seg(N4 n, FieldKind field, byte value)
            => new Seg(field, n, BitRender.render4(value, out asci8 _));

        [MethodImpl(Inline), Op]
        public static Seg seg(N4 n, FieldKind field, bit b0, bit b1, bit b2, bit b3)
            => new Seg(field, 4, new (b0.ToChar(),b1.ToChar(), b2.ToChar(), b3.ToChar()));
    }
}