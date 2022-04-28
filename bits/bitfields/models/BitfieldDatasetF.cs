//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BitfieldDatasets;

    public class BitfieldDataset<F>
        where F : unmanaged, Enum
    {
        public readonly Index<F> Fields;

        public readonly byte FieldCount;

        public readonly Index<byte> Offsets;

        public readonly Index<byte> Widths;

        public readonly BitfieldIntervals<F> Intervals;

        public readonly string RenderPattern;

        public BitfieldDataset(F[] fields, byte[] widths, char sep = Chars.Space)
        {
            Fields = fields;
            Widths = widths;
            FieldCount = (byte)Require.equal(fields.Length, widths.Length);
            Offsets = api.offsets(widths);
            Intervals = api.intervals(this);
            RenderPattern = api.bitrender(Widths, sep);
        }

        [MethodImpl(Inline)]
        public byte Index(F field)
            => core.bw8(field);

        [MethodImpl(Inline)]
        public ref readonly F Field(byte index)
            => ref Fields[index];

        [MethodImpl(Inline)]
        public ref readonly byte Width(F field)
            => ref Widths[Index(field)];

        [MethodImpl(Inline)]
        public ref readonly byte Offset(F field)
            => ref Offsets[Index(field)];

        [MethodImpl(Inline)]
        public ref readonly BitfieldInterval<F> Interval(F field)
            => ref Intervals[Index(field)];

        [MethodImpl(Inline)]
        public T Extract<T>(F field, T src)
            where T : unmanaged
                => Bitfields.extract(src, Offset(field), Width(field));

        [MethodImpl(Inline)]
        public T Extract<T>(F field, uint src)
            where T : unmanaged
                => core.@as<uint,T>(Bitfields.extract(src, Offset(field), Width(field)));

        [MethodImpl(Inline)]
        public void Cells<T>(T src, Index<BitfieldCell<T>> dst)
            where T : unmanaged
                => api.cells(src, Offsets, Widths, dst);
    }
}