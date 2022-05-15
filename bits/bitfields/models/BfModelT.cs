//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BfModel<T>
        where T : unmanaged
    {
        /// <summary>
        /// Specifies the source of the model definition
        /// </summary>
        public readonly BfOrigin Origin;

        /// <summary>
        /// The model name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The number of defined segments
        /// </summary>
        public readonly uint SegCount;

        /// <summary>
        /// The accumulated width of the defined segments
        /// </summary>
        public readonly uint TotalWidth;

        readonly Index<BfSegModel<T>> Data;

        [MethodImpl(Inline)]
        public BfModel(BfOrigin origin, string name, Index<BfSegModel<T>> segments, uint width)
        {
            Origin = origin;
            Name = name;
            SegCount = segments.Count;
            Data = segments;
            TotalWidth = width;
        }

        public ref BfSegModel<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public Span<BfSegModel<T>> Segments
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
        public ref BfSegModel<T> Seg(int index)
            => ref Data[index];
    }
}