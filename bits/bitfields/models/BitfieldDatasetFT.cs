//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BfDatasets;

    public class BitfieldDataset<F,T> : IBitfieldDataset<F>
        where F : unmanaged, Enum
        where T : unmanaged
    {
        public readonly uint FieldCount;

        readonly Index<F> _Fields;

        readonly Index<uint> _Offsets;

        readonly Index<byte> _Widths;

        readonly BitfieldIntervals<F> _Intervals;

        readonly Index<BitMask> _Masks;

        readonly string BitrenderPattern;

        public BitfieldDataset(F[] fields, byte[] widths)
        {
            _Fields = fields;
            _Widths = widths;
            FieldCount = (uint)Require.equal(fields.Length, widths.Length);
            _Offsets = api.offsets(this);
            _Intervals = api.intervals(this);
            _Masks = api.masks(this);
            BitrenderPattern = api.bitrender(this);
        }

        public ref readonly Index<F> Fields
        {
            [MethodImpl(Inline)]
            get => ref _Fields;
        }

        public ref readonly Index<uint> Offsets
        {
            [MethodImpl(Inline)]
            get => ref _Offsets;
        }

        public ref readonly Index<byte> Widths
        {
            [MethodImpl(Inline)]
            get => ref _Widths;
        }

        public ref readonly BitfieldIntervals<F> Intervals
        {
            [MethodImpl(Inline)]
            get => ref _Intervals;
        }

        public ref readonly Index<BitMask> Masks
        {
            [MethodImpl(Inline)]
            get => ref _Masks;
        }

        uint IBitfieldDataset.FieldCount
            => FieldCount;

        string IBitfieldDataset.BitrenderPattern
            => BitrenderPattern;

        ref readonly BitfieldIntervals IBitfieldDataset.Intervals
            => throw new NotImplementedException();

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
        public ref readonly uint Offset(F field)
            => ref Offsets[Index(field)];

        [MethodImpl(Inline)]
        public ref readonly BitMask Mask(F field)
            => ref Masks[Index(field)];

        [MethodImpl(Inline)]
        public ref readonly BitfieldInterval<F> Interval(F field)
            => ref Intervals[Index(field)];

        [MethodImpl(Inline)]
        public T Extract(F field, T src)
            => api.extract(this, field, src);

        [MethodImpl(Inline)]
        public K Extract<K>(F field, T src)
            where K : unmanaged
                => core.@as<T,K>(api.extract(this, field, src));

        [MethodImpl(Inline)]
        public void Store(T src, Index<F,BitfieldCell<T>> dst)
            => api.store(this, src, dst);
    }
}