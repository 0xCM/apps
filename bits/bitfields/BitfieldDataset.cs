//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitfieldDataset
    {
        public static BitfieldDataset<F,T> create<F,W,T>()
            where F : unmanaged, Enum
            where W : unmanaged, Enum
            where T : unmanaged
                => new BitfieldDataset<F,T>(Symbols.index<F>().Kinds.ToArray(), widths<W>());

        internal static Index<BitfieldInterval> intervals<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
                => map(src.Fields, field => new BitfieldInterval(src.Offset(field), src.Width(field)));

        public static Index<byte> offsets<F,T>(BitfieldDataset<F,T> src)
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

        internal static Index<byte> widths<W>()
            where W : unmanaged, Enum
                => Symbols.index<W>().Kinds.Map(x => bw8(x)).ToArray();

        // public static BitfieldDataset<F,T> dataset<F,W,T>()
        //     where F : unmanaged, Enum
        //     where W : unmanaged, Enum
        //     where T : unmanaged
        //         => new BitfieldDataset<F,T>(Symbols.index<F>().Kinds.ToArray(), widths<W>());

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