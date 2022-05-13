//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BfDatasets;

    public class BitfieldDataset<F,T>
        where F : unmanaged, Enum
        where T : unmanaged
    {
        public readonly Index<F> Fields;

        public readonly byte FieldCount;

        readonly Index<byte> Offsets;

        readonly Index<ulong> Masks;

        readonly Index<byte> Widths;

        readonly Index<BitfieldInterval> Intervals;

        readonly string RenderPattern;

        public BitfieldDataset(F[] fields, byte[] widths)
        {
            Fields = fields;
            Widths = widths;
            FieldCount = (byte)Require.equal(fields.Length, widths.Length);
            Offsets = api.offsets(this);
            Masks = api.masks(this);
            Intervals = api.intervals(this);
            RenderPattern = api.bitrender(this);
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
        public ref readonly ulong Mask(F field)
            => ref Masks[Index(field)];

        [MethodImpl(Inline)]
        public ref readonly BitfieldInterval Interval(F field)
            => ref Intervals[Index(field)];

        [MethodImpl(Inline)]
        public T Extract(F field, T src)
            => Bitfields.extract(this, field, src);

        [MethodImpl(Inline)]
        public Index<BitfieldCell<T>> Cells(T src)
            => api.cells(this, src);

        public Index<BitfieldCell<T>> CellBuffer()
            => api.cells(this, default(T));

        [MethodImpl(Inline)]
        public void Cells(T src, Index<BitfieldCell<T>> dst)
            => api.cells(this, src, dst);
    }
}