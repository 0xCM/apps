//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitfieldModel<T>
        where T : unmanaged
    {
        public readonly text31 Name;

        /// <summary>
        /// The number of defined segments
        /// </summary>
        public readonly uint SegCount;

        /// <summary>
        /// The accumulated width of the defined segments
        /// </summary>
        public readonly uint TotalWidth;

        readonly Index<BitfieldSegModel<T>> Data;

        [MethodImpl(Inline)]
        public BitfieldModel(text31 name, Index<BitfieldSegModel<T>> segments, uint width)
        {
            Name = name;
            SegCount = segments.Count;
            Data = segments;
            TotalWidth = width;
        }

        public ref BitfieldSegModel<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public Span<BitfieldSegModel<T>> Segments
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public uint Width(int index)
            => Seg(index).SegWidth;

        [MethodImpl(Inline)]
        public uint Position(int index)
            => bw32(Seg(index).MinIndex);

        [MethodImpl(Inline)]
        public ref BitfieldSegModel<T> Seg(int index)
            => ref Data[index];
    }
}