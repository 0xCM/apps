//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedFields
    {
        public class FieldLookup
        {
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
            public static byte items(ReadOnlySpan<FieldKind> src, Span<byte> dst)
            {
                var count = (byte)min(src.Length, SegSize);
                for(byte i=0; i<count; i++)
                    seek(dst,i) = (byte)skip(src,i);
                return count;
            }

            [MethodImpl(Inline)]
            public FieldMatch Match(byte seg, ReadOnlySpan<FieldKind> src)
            {
                var dst = ByteBlock32.Empty;
                items(src, dst.Bytes);
                return new (VLut.select(LU(seg), dst));
            }

            [MethodImpl(Inline)]
            public FieldMatch Match(in VLut32 lu, ReadOnlySpan<FieldKind> src)
            {
                var dst = ByteBlock32.Empty;
                items(src, dst.Bytes);
                return new (VLut.select(lu, dst));
            }

            [MethodImpl(Inline)]
            public FieldMatch Match(byte seg, params FieldKind[] src)
                => Match(seg, @readonly(src));
        }
    }
}