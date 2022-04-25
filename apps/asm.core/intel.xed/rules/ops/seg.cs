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
        public static SegField segfield(FieldKind field, SegVar seg)
            => new SegField(seg,field);

        [MethodImpl(Inline), Op]
        public static SegField segfield(FieldKind field, char c0)
            => new SegField(c0,field);

        [MethodImpl(Inline), Op]
        public static SegField segfield(FieldKind field, byte n, byte value)
            => SegField.literal(field,n,value);

    }
}