//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BfDatasets;

    public class BitfieldDataset : IBitfieldDataset
    {
        public readonly uint FieldCount;

        readonly Index<uint> _Offsets;

        readonly Index<byte> _Widths;

        readonly BitfieldIntervals _Intervals;

        readonly Index<BitMask> _Masks;

        public readonly string BitrenderPattern;

        public BitfieldDataset(Index<byte> widths, char sep = Chars.Space)
        {
            FieldCount = widths.Count;
            _Widths = widths;
            _Offsets = api.offsets(widths);
            _Intervals = api.intervals(_Offsets, widths);
            _Masks = api.masks(this);
            BitrenderPattern = api.bitrender(widths, sep);
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

        public ref readonly BitfieldIntervals Intervals
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

        [MethodImpl(Inline)]
        public ref readonly byte Width(int index)
            => ref Widths[index];

        [MethodImpl(Inline)]
        public ref readonly byte Width(uint index)
            => ref Widths[index];

        [MethodImpl(Inline)]
        public ref readonly uint Offset(int index)
            => ref Offsets[index];

        [MethodImpl(Inline)]
        public ref readonly uint Offset(uint index)
            => ref Offsets[index];

        [MethodImpl(Inline)]
        public ref readonly BitMask Mask(int index)
            => ref Masks[index];

        [MethodImpl(Inline)]
        public ref readonly BitMask Mask(uint index)
            => ref Masks[index];

        [MethodImpl(Inline)]
        public ref readonly BitfieldInterval Interval(int index)
            => ref Intervals[index];

        [MethodImpl(Inline)]
        public ref readonly BitfieldInterval Interval(uint index)
            => ref Intervals[index];

        [MethodImpl(Inline)]
        public T Extract<T>(byte index, T src)
            where T : unmanaged
                => Bitfields.extract(src, (byte)Offset(index), Width(index));

        [MethodImpl(Inline)]
        public Index<BitfieldCell<T>> Store<T>(T src, Index<BitfieldCell<T>> dst)
            where T : unmanaged
                => api.store(this, src, dst);
    }
}