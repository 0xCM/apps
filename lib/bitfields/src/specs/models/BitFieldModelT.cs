//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct BitFieldModel<T>
        where T : unmanaged
    {
        public readonly Identifier Name;

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
        public BitFieldModel(Identifier name, Index<BitfieldSegModel<T>> segments, uint width)
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
            => Seg(index).Width;

        [MethodImpl(Inline)]
        public uint Position(int index)
            => bw32(Seg(index).Offset);

        [MethodImpl(Inline)]
        public ref BitfieldSegModel<T> Seg(int index)
            => ref Data[index];
    }
}