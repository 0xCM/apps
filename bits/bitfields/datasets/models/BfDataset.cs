//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BfDatasets;

    public class BfDataset : IBfDataset
    {
        public readonly asci64 Name;

        public readonly uint FieldCount;

        readonly Index<string> _Fields;

        readonly Dictionary<string,uint> _Indices;

        readonly Index<uint> _Offsets;

        readonly Index<byte> _Widths;

        readonly BfIntervals _Intervals;

        readonly Index<BitMask> _Masks;

        public readonly string BitstringPattern;

        public BfDataset(asci64 name, Index<string> fields, Dictionary<string,uint> indices, Index<byte> widths)
        {
            Name = name;
            FieldCount = widths.Count;
            _Indices = indices;
            _Widths = widths;
            _Offsets = api.offsets(widths);
            _Intervals = Bitfields.intervals(_Offsets, widths);
            _Masks = api.masks(this);
            BitstringPattern = api.pattern(widths, Chars.Space);
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

        public ref readonly BfIntervals Intervals
        {
            [MethodImpl(Inline)]
            get => ref _Intervals;
        }

        public ref readonly Index<string> Fields
        {
            [MethodImpl(Inline)]
            get => ref _Fields;
        }

        public ref readonly Index<BitMask> Masks
        {
            [MethodImpl(Inline)]
            get => ref _Masks;
        }

        uint IBfDataset.FieldCount
            => FieldCount;

        string IBfDataset.BitstringPattern
            => BitstringPattern;

        asci64 IBfDataset.Name
            => Name;

        [MethodImpl(Inline)]
        public uint Index(asci64 field)
            => _Indices[field];

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
        public ref readonly BfInterval Interval(int index)
            => ref Intervals[index];

        [MethodImpl(Inline)]
        public ref readonly BfInterval Interval(uint index)
            => ref Intervals[index];

        [MethodImpl(Inline)]
        public T Extract<T>(uint index, T src)
            where T : unmanaged
                => api.segvalue(src, Offset(index), Width(index));
    }
}