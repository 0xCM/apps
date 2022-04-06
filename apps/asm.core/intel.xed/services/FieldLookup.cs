//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedRules
    {
        public class FieldLookup
        {
            public static FieldLookup create()
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

            [StructLayout(LayoutKind.Sequential,Pack=1)]
            public struct LookupData
            {
                public VLut32 LU0;

                public VLut32 LU1;

                public VLut32 LU2;

                public VLut32 LU3;
            }

            readonly LookupData Data;

            internal FieldLookup(LookupData data)
            {
                 Data = data;
            }

            [MethodImpl(Inline)]
            public ref readonly VLut32 LU(byte i)
                => ref @as<VLut32>(seek(bytes(Data), i*SegSize));

            internal const byte SegSize = 32;

            internal const byte SegCount = 4;

            [MethodImpl(Inline)]
            public FieldMatch Match(byte seg, ReadOnlySpan<FieldKind> src)
                => FieldMatch.match(this, seg, src);

            [MethodImpl(Inline)]
            public FieldMatch Match(in VLut32 lu, ReadOnlySpan<FieldKind> src)
                => FieldMatch.match(lu, src);

            [MethodImpl(Inline)]
            public FieldMatch Match(byte seg, params FieldKind[] src)
                => FieldMatch.match(this, seg, src);
        }
    }
}