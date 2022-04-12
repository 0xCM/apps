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
        public static SegField seg(FieldKind field, SegFieldType vt)
            => new SegField(field, vt);

        [MethodImpl(Inline), Op]
        public static SegField seg(FieldKind field, char c0)
            => new SegField(field, c0);

        [MethodImpl(Inline), Op]
        public static SegField seg(FieldKind field, char c0, char c1)
            => new SegField(field, c0, c1);

        [MethodImpl(Inline), Op]
        public static SegField seg(FieldKind field, char c0, char c1, char c2)
            => new SegField(field, c0,c1,c2);

        [MethodImpl(Inline), Op]
        public static SegField seg(FieldKind field, uint1 value)
            => new SegField(field, 1, value);

        [MethodImpl(Inline), Op]
        public static SegField seg(FieldKind field, uint2 value)
            => new SegField(field, 2, value);

        [MethodImpl(Inline), Op]
        public static SegField seg(FieldKind field, uint3 value)
            => new SegField(field, 3, value);

        [MethodImpl(Inline), Op]
        public static SegField seg(FieldKind field, uint4 value)
            => new SegField(field, 4, value);
    }
}