//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Bitfields;

    public readonly struct BitfieldModel
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

        readonly Index<BitfieldSegModel> Data;

        [MethodImpl(Inline)]
        public BitfieldModel(BfOrigin origin, string name, Index<BitfieldSegModel> segs, uint width)
        {
            Origin = origin;
            Name = name;
            SegCount = segs.Count;
            TotalWidth = width;
            Data = segs;
        }

        public bool IsBitvector
        {
            [MethodImpl(Inline)]
            get => SegCount == TotalWidth;
        }

        public Span<BitfieldSegModel> Segments
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public ref BitfieldSegModel Seg(uint i)
            => ref Data[i];

        public ref BitfieldSegModel this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Seg(i);
        }

        [MethodImpl(Inline)]
        public uint SegWidth(uint i)
            => Seg(i).SegWidth;

        [MethodImpl(Inline)]
        public uint SegStart(uint i)
            => Seg(i).MinIndex;

        [MethodImpl(Inline)]
        public uint SegEnd(uint i)
            => Seg(i).SegWidth;

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}