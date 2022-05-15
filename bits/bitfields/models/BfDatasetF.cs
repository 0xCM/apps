//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BfDatasets;

    public class BfdDataset<F> : IBfDataset<F>
        where F : unmanaged, Enum
    {
        public readonly asci64 Name;

        public readonly uint FieldCount;

        readonly Index<F> _Fields;

        readonly Index<uint> _Offsets;

        readonly Index<byte> _Widths;

        readonly Dictionary<F,uint> _Indices;

        readonly BfIntervals<F> _Intervals;

        public readonly string BitrenderPattern;

        readonly Index<BitMask> _Masks;

        public BfdDataset(F[] fields, Dictionary<F,uint> indices, byte[] widths)
        {
            FieldCount = (uint)Require.equal(fields.Length, widths.Length);
            Name = typeof(F).Name;
            _Fields = fields;
            _Indices = indices;
            _Widths = widths;
            _Offsets = api.offsets(widths);
            _Intervals = api.intervals(this);
            _Masks = api.masks(this);
            BitrenderPattern = api.bitrender(widths, Chars.Space);
        }

        public ref readonly BfIntervals<F> Intervals
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

        asci64 IBfDataset.Name
            => Name;

        uint IBfDataset.FieldCount
            => FieldCount;

        string IBfDataset.BitrenderPattern
            => BitrenderPattern;

        ref readonly BfIntervals IBfDataset.Intervals
            => throw new NotImplementedException();

        public ref readonly Index<BitMask> Masks
        {
            [MethodImpl(Inline)]
            get => ref _Masks;
        }

        [MethodImpl(Inline)]
        public uint Index(F field)
            => _Indices[field];

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
        public ref readonly BfInterval<F> Interval(F field)
            => ref Intervals[Index(field)];

        [MethodImpl(Inline)]
        public T Extract<T>(F field, T src)
            where T : unmanaged
                => Bitfields.extract(src, (byte)Offset(field), Width(field));

        [MethodImpl(Inline)]
        public T Extract<T>(F field, uint src)
            where T : unmanaged
                => core.@as<uint,T>(Bitfields.extract(src, (byte)Offset(field), Width(field)));
    }
}