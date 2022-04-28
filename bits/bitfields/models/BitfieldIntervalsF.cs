//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BitfieldIntervals<F>
        where F : unmanaged
    {
        readonly Index<BitfieldInterval<F>> Data;

        [MethodImpl(Inline)]
        public BitfieldIntervals(BitfieldInterval<F>[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref BitfieldInterval<F> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref BitfieldInterval<F> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public BitfieldInterval<F>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<BitfieldInterval<F>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ReadOnlySpan<BitfieldInterval<F>> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public string Format()
            => Bitfields.format(View);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitfieldIntervals<F>(BitfieldInterval<F>[] src)
            => new BitfieldIntervals<F>(src);

        [MethodImpl(Inline)]
        public static implicit operator BitfieldIntervals<F>(Index<BitfieldInterval<F>> src)
            => new BitfieldIntervals<F>(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator BitfieldInterval<F>[](BitfieldIntervals<F> src)
            => src.Storage;
    }
}