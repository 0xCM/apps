//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline)]
        public static BitMask mask(byte width, uint offset)
            => max(width) << (int)offset;

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static T mask<T>(byte width, uint offset)
            => generic<T>(max(width) << (int)offset);

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<T> masks<T>(Index<byte> widths, Index<byte> offsets)
            where T : unmanaged
        {
            var count = Require.equal(offsets.Count, widths.Count);
            var dst = alloc<T>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = mask<T>(widths[i], offsets[i]);
            return dst;
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static void masks<T>(Index<byte> widths, Index<byte> offsets, Index<T> dst)
            where T : unmanaged
        {
            var count = dst.Count;
            for(var i=z8; i<count; i++)
                dst[i] = mask<T>(widths[i], offsets[i]);
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Index<BitMask> masks(BitfieldDataset ds, Index<BitMask> dst)
        {
            var count = dst.Count;
            for(var i=z8; i<count; i++)
                dst[i] = mask(ds.Width(i), ds.Offset(i));
            return dst;
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Index<T> masks<T>(BitfieldDataset ds, Index<T> dst)
            where T : unmanaged
        {
            var count = dst.Count;
            for(var i=z8; i<count; i++)
                dst[i] = mask<T>(ds.Width(i), ds.Offset(i));
            return dst;
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<BitMask> masks(BitfieldDataset ds)
        {
            var dst = alloc<BitMask>(ds.FieldCount);
            for(var i=z8; i<ds.FieldCount; i++)
                seek(dst,i) = mask(ds.Width(i), ds.Offset(i));
            return dst;
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<BitMask> masks<F>(BitfieldDataset<F> spec)
            where F : unmanaged, Enum
        {
            var dst = alloc<BitMask>(spec.FieldCount);
            var fields = spec.Fields;
            for(var i=0; i<spec.FieldCount; i++)
            {
                ref readonly var field = ref fields[i];
                var m = max(spec.Width(field));
                seek(dst,i) = m << (int)spec.Offset(field);
            }
            return dst;
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<T> masks<T>(BitfieldDataset ds)
            where T : unmanaged
        {
            var dst = alloc<T>(ds.FieldCount);
            for(var i=z8; i<ds.FieldCount; i++)
                seek(dst,i) = mask<T>(ds.Width(i), ds.Offset(i));
            return dst;
        }

        public static Index<BitMask> masks<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var fields = src.Fields;
            var dst = alloc<BitMask>(src.FieldCount);
            for(var i=0; i<src.FieldCount; i++)
            {
                ref readonly var field = ref fields[i];
                var m = max(src.Width(field));
                seek(dst,i) = m << (int)src.Offset(field);
            }
            return dst;
        }
    }
}