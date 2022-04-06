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
        public readonly struct FieldMatch
        {
            internal const byte SegSize = 32;

            [MethodImpl(Inline)]
            static byte items(ReadOnlySpan<FieldKind> src, Span<byte> dst)
            {
                var count = (byte)min(src.Length, SegSize);
                for(byte i=0; i<count; i++)
                    seek(dst,i) = (byte)skip(src,i);
                return count;
            }

            [MethodImpl(Inline)]
            public static FieldMatch match(FieldLookup lookup, byte seg, ReadOnlySpan<FieldKind> src)
            {
                var dst = ByteBlock32.Empty;
                items(src, dst.Bytes);
                return new (VLut.select(lookup.LU(seg), dst));
            }

            [MethodImpl(Inline)]
            public static FieldMatch match(in VLut32 lu, ReadOnlySpan<FieldKind> src)
            {
                var dst = ByteBlock32.Empty;
                items(src, dst.Bytes);
                return new (VLut.select(lu, dst));
            }

            [MethodImpl(Inline)]
            public static FieldMatch Match(FieldLookup lookup, byte seg, params FieldKind[] src)
                => match(lookup,seg, @readonly(src));

            readonly Vector256<byte> Entries;

            [MethodImpl(Inline)]
            internal FieldMatch(Vector256<byte> src)
            {
                Entries = src;
            }

            [MethodImpl(Inline)]
            public FieldKind Entry(uint5 index)
                => (FieldKind)cpu.vcell(Entries,index);

            public FieldKind this[uint5 index]
            {
                [MethodImpl(Inline)]
                get => Entry(index);
            }
        }
    }
}