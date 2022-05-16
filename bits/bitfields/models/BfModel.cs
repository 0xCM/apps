//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Bitfields;

    [StructLayout(StructLayout,Pack=1), Doc("Describes a bitfield")]
    public readonly struct BfModel
    {
        /// <summary>
        /// Specifies the source of the model definition
        /// </summary>
        public readonly BfOrigin Origin;

        /// <summary>
        /// The model name
        /// </summary>
        public readonly asci64 Name;

        /// <summary>
        /// The number of defined segments
        /// </summary>
        public readonly uint SegCount;

        /// <summary>
        /// The accumulated width of the defined segments
        /// </summary>
        public readonly uint TotalWidth;

        readonly Index<BfSegModel> Data;

        [MethodImpl(Inline)]
        public BfModel(BfOrigin origin, string name, Index<BfSegModel> segs, uint width)
        {
            Demand.lteq(name.Length, asci64.Size);
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

        public Span<BfSegModel> Segments
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public ref BfSegModel Seg(uint i)
            => ref Data[i];

        public ref BfSegModel this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Seg(i);
        }

        [MethodImpl(Inline)]
        public uint SegWidth(uint i)
            => Seg(i).Width;

        [MethodImpl(Inline)]
        public uint SegStart(uint i)
            => Seg(i).MinPos;

        [MethodImpl(Inline)]
        public uint SegEnd(uint i)
            => Seg(i).Width;

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}