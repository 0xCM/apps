//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitfieldDatasets
    {
        public static BitfieldDataset<F,T> create<F,W,T>()
            where F : unmanaged, Enum
            where W : unmanaged, Enum
            where T : unmanaged
                => Bitfields.dataset<F,W,T>();

        public static BitfieldDataset dataset(Index<byte> widths)
            => Bitfields.dataset(widths);

        public static ulong max(byte width)
            => width switch
            {
                0 => 0,
                1 => (ulong)Limits.Max1u,
                2 => (ulong)Limits.Max2u,
                3 => (ulong)Limits.Max3u,
                4 => (ulong)Limits.Max4u,
                5 => (ulong)Limits.Max6u,
                6 => (ulong)Limits.Max6u,
                7 => (ulong)Limits.Max7u,
                8 => (ulong)Limits.Max8u,
                9 => (ulong)Limits.Max9u,
                10 => (ulong)Limits.Max10u,
                11 => (ulong)Limits.Max11u,
                12 => (ulong)Limits.Max12u,
                13 => (ulong)Limits.Max13u,
                14 => (ulong)Limits.Max14u,
                15 => (ulong)Limits.Max15u,
                16 => (ulong)Limits.Max16u,
                17 => (ulong)Limits.Max17u,
                18 => (ulong)Limits.Max18u,
                19 => (ulong)Limits.Max19u,
                20 => (ulong)Limits.Max20u,
                21 => (ulong)Limits.Max21u,
                22 => (ulong)Limits.Max22u,
                23 => (ulong)Limits.Max23u,
                24 => (ulong)Limits.Max24u,
                32 => (ulong)Limits.Max32u,
                64 => (ulong)Limits.Max64u,

                _ => 0
            };

        [MethodImpl(Inline)]
        public static ulong mask(byte offset, byte width)
            => max(width) << offset;

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static T mask<T>(byte offset, byte width)
            => generic<T>(max(width) << offset);

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<T> masks<T>(Index<byte> offsets, Index<byte> widths)
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
        public static void masks<T>(Index<byte> offsets, Index<byte> widths, Index<T> dst)
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
        public static Index<T> masks<T>(BitfieldDataset ds)
            where T : unmanaged
        {
            var dst = alloc<T>(ds.FieldCount);
            for(var i=z8; i<ds.FieldCount; i++)
                seek(dst,i) = mask<T>(ds.Width(i), ds.Offset(i));
            return dst;
        }

        /// <summary>
        /// Infers bitfield segment widths from an enum
        /// </summary>
        /// <typeparam name="W">The defining denum</typeparam>
        public static Index<byte> widths<W>()
            where W : unmanaged, Enum
                => Symbols.index<W>().Kinds.Map(x => bw8(x)).ToArray();

        /// <summary>
        /// Computes a sequence of bitfield offsets given a sequence of field widths
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<byte> offsets(Index<byte> widths)
        {
            var count = widths.Count;
            var dst = alloc<byte>(count);
            var offset = z8;
            for(var i=0; i<count; i++)
            {
                seek(dst,i) = offset;
                offset += widths[i];
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static BitfieldInterval interval(byte offset, byte width)
            => new BitfieldInterval(offset,width);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static T segment<T>(T src, byte index, Index<byte> offsets, Index<byte> widths)
            where T : unmanaged
                => generic<T>(bits.extract(bw64(src), offsets[index], (byte)(offsets[index] + widths[index])));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static T segment<T>(T src, byte offset, byte width)
            where T : unmanaged
                => generic<T>(bits.extract(bw64(src), offset, (byte)(offset + width)));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitfieldCell<T> cell<T>(T src, byte index, byte offset, byte width)
            where T : unmanaged
                => new BitfieldCell<T>(interval(offset,width), segment(src, offset, width));

        /// <summary>
        /// Computes a <see cref='BitfieldInterval'/> sequence given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<BitfieldInterval> intervals(Index<byte> offsets, Index<byte> widths)
            => mapi(offsets, (i,o)=> interval(o, widths[i]));

        /// <summary>
        /// Creates a bitfield render pattern predicated on a sequence of segment widths
        /// </summary>
        /// <param name="widths"></param>
        public static string bitrender(Index<byte> widths, char sep = Chars.Space)
        {
            var dst = text.buffer();
            var count = widths.Count;
            for(var i=z8; i<count; i++)
            {
                var slot = RP.slot(i, math.negate((sbyte)widths[i]));
                dst.Append(slot);
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        internal static Index<BitfieldCell<T>> cells<T>(BitfieldDataset ds, T src)
            where T : unmanaged
        {
            var dst = alloc<BitfieldCell<T>>(ds.FieldCount);
            for(var i=z8; i<ds.FieldCount; i++)
                seek(dst,i) = new BitfieldCell<T>(Bitfields.interval(ds.Offset(i), ds.Width(i)), segment(src, ds.Offset(i),  ds.Width(i)));
            return dst;
        }

        [MethodImpl(Inline)]
        internal static Index<BitfieldCell<T>> cells<T>(in T src, Index<byte> offsets, Index<byte> widths, Index<BitfieldCell<T>> dst)
            where T : unmanaged
        {
            var count = Require.equal(Require.equal(offsets.Count, widths.Count), dst.Count);
            for(var i=z8; i<count; i++)
                dst[i].Value = segment(src, offsets[i], widths[i]);
            return dst;
        }

        [MethodImpl(Inline)]
        internal static Index<BitfieldCell<T>> cells<T>(BitfieldDataset ds, in T src, Index<BitfieldCell<T>> dst)
            where T : unmanaged
        {
            for(var i=z8; i<ds.FieldCount; i++)
                dst[i].Value = segment(src, ds.Offset(i), ds.Width(i));
            return dst;
        }

        internal static Index<BitfieldInterval<F>> intervals<F>(BitfieldDataset<F> src)
            where F : unmanaged, Enum
                => map(src.Fields, field => new BitfieldInterval<F>(field, src.Offset(field), src.Width(field)));

        internal static Index<BitfieldInterval> intervals<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
                => map(src.Fields, field => new BitfieldInterval(src.Offset(field), src.Width(field)));

        internal static Index<byte> offsets<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var dst = alloc<byte>(src.FieldCount);
            var fields = src.Fields;
            var offset = z8;
            for(var i=0; i<src.FieldCount; i++)
            {
                var field = fields[i];
                seek(dst,i) = offset;
                offset += src.Width(field);
            }
            return dst;
        }

        [MethodImpl(Inline)]
        internal static T segment<F,T>(BitfieldDataset<F,T> ds, F field, T src)
            where F : unmanaged, Enum
            where T : unmanaged
                => generic<T>(bits.extract(bw64(src), ds.Offset(field), (byte)(ds.Offset(field) + ds.Width(field))));

        internal static Index<BitfieldCell<T>> cells<F,T>(BitfieldDataset<F,T> ds, T src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var dst = alloc<BitfieldCell<T>>(ds.FieldCount);
            var fields = ds.Fields;
            for(var i=0; i<ds.FieldCount; i++)
            {
                ref readonly var field = ref ds.Fields[i];
                seek(dst,i) = new BitfieldCell<T>(Bitfields.interval(ds.Offset(field), ds.Width(field)), segment(ds, field, src));
            }
            return dst;
        }

        [MethodImpl(Inline)]
        internal static Index<BitfieldCell<T>> cells<F,T>(BitfieldDataset<F,T> ds, in T src, Index<BitfieldCell<T>> dst)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            for(var i=0; i<ds.FieldCount; i++)
                dst[i].Value = segment(ds, ds.Fields[i], src);
            return dst;
        }

        internal static Index<ulong> masks<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var fields = src.Fields;
            var dst = alloc<ulong>(src.FieldCount);
            for(var i=0; i<src.FieldCount; i++)
            {
                ref readonly var field = ref fields[i];
                var m = max(src.Width(field));
                seek(dst,i) = m << src.Offset(field);
            }
            return dst;
        }

        internal static string bitrender<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var dst = text.buffer();
            var fields = src.Fields;
            for(var i=z8; i<src.FieldCount; i++)
            {
                ref readonly var field = ref src.Fields[i];
                ref readonly var w = ref src.Width(field);
                var slot = RP.slot(i, math.negate((sbyte)w));
                dst.Append(slot);
                if(i != src.FieldCount - 1)
                    dst.Append(Chars.Space);
            }
            return dst.Emit();
        }
    }
}