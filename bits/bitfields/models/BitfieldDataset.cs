//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BitfieldDatasets;

    public class BitfieldDataset
    {
        public readonly byte FieldCount;

        public readonly Index<byte> Offsets;

        public readonly Index<byte> Widths;

        public readonly BitfieldIntervals Intervals;

        public readonly string RenderPattern;

        public BitfieldDataset(Index<byte> widths, char sep = Chars.Space)
        {
            Widths = widths;
            FieldCount = (byte)Widths.Count;
            Offsets = api.offsets(Widths);
            Intervals = api.intervals(Offsets,Widths);
            RenderPattern = api.bitrender(Widths, sep);
        }

        [MethodImpl(Inline)]
        public ref readonly byte Width(byte index)
            => ref Widths[index];

        [MethodImpl(Inline)]
        public ref readonly byte Offset(byte index)
            => ref Offsets[index];

        [MethodImpl(Inline)]
        public ref readonly BitfieldInterval Interval(byte index)
            => ref Intervals[index];

        [MethodImpl(Inline)]
        public T Extract<T>(byte index, T src)
            where T : unmanaged
                => Bitfields.extract(src, Offset(index), Width(index));

        [MethodImpl(Inline)]
        public Index<BitfieldCell<T>> Cells<T>(T src, Index<BitfieldCell<T>> dst)
            where T : unmanaged
                => api.cells(this, src, dst);

        [MethodImpl(Inline)]
        public Index<T> Masks<T>(Index<T> dst)
            where T : unmanaged
                => api.masks(this, dst);

        [MethodImpl(Inline)]
        public T Mask<T>(byte index)
            where T : unmanaged
                => api.mask<T>(Offset(index), Width(index));
    }
}