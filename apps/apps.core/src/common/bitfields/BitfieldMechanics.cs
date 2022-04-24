//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitfieldMechanics
    {
        [MethodImpl(Inline)]
        public static T extract<T>(T src, byte offset, byte width)
            where T : unmanaged
                => generic<T>(bits.extract(@bw64(src), offset, math.add(offset, width)));

        [MethodImpl(Inline)]
        public static T extract<F,T>(BitfieldDataset<F,T> bitfield, F field, T src)
            where F : unmanaged, Enum
            where T : unmanaged
                => extract(src, bitfield.Offset(field), bitfield.Width(field));

        [MethodImpl(Inline)]
        public static BitfieldInterval interval(byte offset, byte width)
            => new BitfieldInterval(offset,width);

        [MethodImpl(Inline)]
        public static BitfieldCell<T> cell<T>(BitfieldInterval i, T value)
            where T : unmanaged
                => new BitfieldCell<T>(i,value);

        public static string format<T>(BitfieldCell<T> src)
            where T : unmanaged
        {
            var dw = core.width<T>();
            var bits = EmptyString;
            var offset = dw - src.Interval.Width;
            if(dw == 8)
                bits = bw8(src.Value).FormatBits();
            if(dw == 16)
                bits = bw16(src.Value).FormatBits();
            else if(dw == 32)
                bits = bw32(src.Value).FormatBits();
            else if(dw == 64)
                bits = bw64(src.Value).FormatBits();

            return text.format(slice(span(bits), offset));
        }

        public static string format(BitfieldInterval src)
            => string.Format("[{0}:{1}]", src.Max, src.Min);

        internal static Index<byte> widths<W>()
            where W : unmanaged, Enum
                => Symbols.index<W>().Kinds.Map(x => bw8(x)).ToArray();

        internal static Index<BitfieldInterval> intervals<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
                => map(src.Fields, field => new BitfieldInterval(src.Offset(field), src.Width(field)));

        public static BitfieldDataset<F,T> dataset<F,W,T>()
            where F : unmanaged, Enum
            where W : unmanaged, Enum
            where T : unmanaged
                => new BitfieldDataset<F,T>(Symbols.index<F>().Kinds.ToArray(), BitfieldMechanics.widths<W>());

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
        public static T segment<F,T>(BitfieldDataset<F,T> ds, F field, T src)
            where F : unmanaged, Enum
            where T : unmanaged
                => generic<T>(bits.extract(bw64(src), ds.Offset(field), (byte)(ds.Offset(field) + ds.Width(field))));

        public static Index<BitfieldCell<T>> cells<F,T>(BitfieldDataset<F,T> ds, T src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var dst = alloc<BitfieldCell<T>>(ds.FieldCount);
            var fields = ds.Fields;
            for(var i=0; i<ds.FieldCount; i++)
            {
                ref readonly var field = ref ds.Fields[i];
                seek(dst,i) = new BitfieldCell<T>(interval(ds.Offset(field), ds.Width(field)), segment(ds, field, src));
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
                var m = (ulong)HexMax.max(src.Width(field));
                seek(dst,i) = m << src.Offset(field);
            }
            return dst;
        }

        internal static string rp<F,T>(BitfieldDataset<F,T> src)
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