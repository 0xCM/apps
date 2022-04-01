//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedFields.FieldLookup;
    using static core;


    partial class XedFields
    {
        public static FieldLookup lookup()
        {
            var src = Symbols.index<FieldKind>().Kinds;
            Require.equal(src.Length,SegSize*SegCount);
            var dst = default(LookupData);
            var seg = z8;
            var offset = 0u;
            dst.LU0 = lut32(seg++, slice(src, offset,SegSize));
            offset += SegSize;
            dst.LU1 = lut32(seg++, slice(src, offset,SegSize));
            offset += SegSize;
            dst.LU2 = lut32(seg++, slice(src, offset,SegSize));
            offset += SegSize;
            dst.LU3 = lut32(seg++, slice(src, offset,SegSize));
            return new FieldLookup(dst);
        }

        [MethodImpl(Inline), Op]
        static VLut32 lut32(byte seg, ReadOnlySpan<FieldKind> src)
        {
            var data = ByteBlock32.Empty;
            var count = min(src.Length, SegSize);
            for(byte i=0; i<count; i++)
                data[i] = (byte)((byte)skip(src,i) - SegSize*4);
            return VLut.init(data.Vector<byte>());
        }
    }
}