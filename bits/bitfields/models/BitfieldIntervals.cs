//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BitfieldIntervals
    {
        readonly Index<BitfieldInterval> Data;

        [MethodImpl(Inline)]
        public BitfieldIntervals(BitfieldInterval[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref BitfieldInterval this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref BitfieldInterval this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public BitfieldInterval[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<BitfieldInterval> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ReadOnlySpan<BitfieldInterval> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public string Format()
            => Bitfields.format(View);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitfieldIntervals(BitfieldInterval[] src)
            => new BitfieldIntervals(src);

        [MethodImpl(Inline)]
        public static implicit operator BitfieldIntervals(Index<BitfieldInterval> src)
            => new BitfieldIntervals(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator BitfieldInterval[](BitfieldIntervals src)
            => src.Storage;
    }
}