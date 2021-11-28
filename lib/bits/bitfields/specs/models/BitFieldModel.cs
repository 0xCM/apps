//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = BitfieldSpecs;

    public readonly struct BitfieldModel
    {
        /// <summary>
        /// The bitfield name
        /// </summary>
        public readonly Identifier Name;

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
        public BitfieldModel(Identifier name, Index<BitfieldSegModel> segs, uint width)
        {
            Name = name;
            SegCount = segs.Count;
            TotalWidth = width;
            Data = segs;
        }

        public bool IsBitvector
        {
            [MethodImpl(Inline)]
            get => api.bitvector(this);
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
            => Seg(i).Width;

        [MethodImpl(Inline)]
        public uint SegStart(uint i)
            => Seg(i).Offset;

        [MethodImpl(Inline)]
        public uint SegEnd(uint i)
            => Seg(i).Width;

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}