//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BfDatasets;

    public class BitfieldDataset<F> : IBitfieldDataset<F>
        where F : unmanaged, Enum
    {
        public readonly uint FieldCount;

        readonly Index<F> _Fields;

        readonly Index<uint> _Offsets;

        readonly Index<byte> _Widths;

        readonly BitfieldIntervals<F> _Intervals;

        public readonly string BitrenderPattern;

        readonly Index<BitMask> _Masks;

        public BitfieldDataset(F[] fields, byte[] widths, char sep = Chars.Space)
        {
            FieldCount = (uint)Require.equal(fields.Length, widths.Length);
            _Fields = fields;
            _Widths = widths;
            _Offsets = api.offsets(widths);
            _Intervals = api.intervals(this);
            _Masks = api.masks(this);
            BitrenderPattern = api.bitrender(widths, sep);
        }

        public ref readonly BitfieldIntervals<F> Intervals
        {
            [MethodImpl(Inline)]
            get => ref _Intervals;
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

        uint IBitfieldDataset.FieldCount
            => FieldCount;

        string IBitfieldDataset.BitrenderPattern
            => BitrenderPattern;

        ref readonly BitfieldIntervals IBitfieldDataset.Intervals
            => throw new NotImplementedException();

        public ref readonly Index<BitMask> Masks
        {
            [MethodImpl(Inline)]
            get => ref _Masks;
        }

        [MethodImpl(Inline)]
        public byte Index(F field)
            => core.bw8(field);

        [MethodImpl(Inline)]
        public ref readonly F Field(byte index)
            => ref Fields[index];

        [MethodImpl(Inline)]
        public ref readonly byte Width(F field)
            => ref _Widths[Index(field)];

        [MethodImpl(Inline)]
        public ref readonly uint Offset(F field)
            => ref _Offsets[Index(field)];

        [MethodImpl(Inline)]
        public ref readonly BitfieldInterval<F> Interval(F field)
            => ref Intervals[Index(field)];

        [MethodImpl(Inline)]
        public T Extract<T>(F field, T src)
            where T : unmanaged
                => Bitfields.extract(src, (byte)Offset(field), Width(field));

        [MethodImpl(Inline)]
        public T Extract<T>(F field, uint src)
            where T : unmanaged
                => core.@as<uint,T>(Bitfields.extract(src, (byte)Offset(field), Width(field)));

        [MethodImpl(Inline)]
        public void Store<T>(T src, Index<BitfieldCell<T>> dst)
            where T : unmanaged
                => api.store(src, _Offsets, _Widths, dst);
    }
}