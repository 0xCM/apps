//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        public static Index<BitMask> masks<W>()
            where W : unmanaged, Enum
        {
            var widths = BfDatasets.widths<W>();
            var count = widths.Count;
            var offset = 0u;
            var dst = alloc<BitMask>(count);
            Bitfields.masks(widths, dst);
            return dst;
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void masks(BfDataset spec, Span<BitMask> dst)
        {
            var count = dst.Length;
            for(var i=z8; i<count; i++)
                seek(dst,i) = Bitfields.mask(spec.Width(i), spec.Offset(i));
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void masks<T>(BfDataset spec, Span<T> dst)
            where T : unmanaged
        {
            var count = dst.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = Bitfields.mask<T>(spec.Width(i), spec.Offset(i));
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<BitMask> masks(BfDataset spec)
        {
            var dst = alloc<BitMask>(spec.FieldCount);
            for(var i=z8; i<spec.FieldCount; i++)
                seek(dst,i) = Bitfields.mask(spec.Width(i), spec.Offset(i));
            return dst;
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<BitMask> masks<F>(BfDataset<F> spec)
            where F : unmanaged, Enum
        {
            var dst = alloc<BitMask>(spec.FieldCount);
            var fields = spec.Fields;
            for(var i=0; i<spec.FieldCount; i++)
            {
                ref readonly var field = ref fields[i];
                var m = Numbers.max(spec.Width(field));
                seek(dst,i) = m << (int)spec.Offset(field);
            }
            return dst;
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<T> masks<T>(BfDataset ds)
            where T : unmanaged
        {
            var dst = alloc<T>(ds.FieldCount);
            for(var i=z8; i<ds.FieldCount; i++)
                seek(dst,i) = Bitfields.mask<T>(ds.Width(i), ds.Offset(i));
            return dst;
        }

        public static Index<BitMask> masks<F,T>(BfDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var fields = src.Fields;
            var dst = alloc<BitMask>(src.FieldCount);
            for(var i=0; i<src.FieldCount; i++)
            {
                ref readonly var field = ref fields[i];
                var m = Numbers.max(src.Width(field));
                seek(dst,i) = m << (int)src.Offset(field);
            }
            return dst;
        }
    }
}