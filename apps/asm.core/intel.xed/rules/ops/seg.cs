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
        public static InstSeg seg(FieldKind field, InstSegType vt)
            => new InstSeg(field, vt);

        [MethodImpl(Inline), Op]
        public static SegField seg(FieldKind field, SegVar seg)
            => new SegField(seg,field);

        [MethodImpl(Inline), Op]
        public static InstSeg seg(FieldKind field, char c0)
            => new InstSeg(field, c0);

        // [MethodImpl(Inline), Op]
        // public static InstSeg seg(FieldKind field, uint1 value)
        //     => new InstSeg(field, 1, value);

        // [MethodImpl(Inline), Op]
        // public static InstSeg seg(FieldKind field, uint2 value)
        //     => new InstSeg(field, 2, value);

        // [MethodImpl(Inline), Op]
        // public static InstSeg seg(FieldKind field, uint3 value)
        //     => new InstSeg(field, 3, value);

        // [MethodImpl(Inline), Op]
        // public static InstSeg seg(FieldKind field, uint4 value)
        //     => new InstSeg(field, 4, value);

        [MethodImpl(Inline), Op]
        public static InstSeg seg(FieldKind field, byte n, byte value)
            => new InstSeg(field, n, value);
    }
}