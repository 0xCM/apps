//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DataSize : IComparable<DataSize>
    {
        const byte AlignedOffset = 56;

        const ulong AlignedMask = 0xFFul << AlignedOffset;

        const ulong PackedMask = ~AlignedMask;

        readonly ulong Data;

        [MethodImpl(Inline)]
        public DataSize(BitWidth width)
        {
            Aligned aligned = (ulong)width;
            Data = ((ulong)aligned << AlignedOffset) | (ulong)width & PackedMask;
        }

        [MethodImpl(Inline)]
        public DataSize(Aligned aligned, BitWidth packed)
        {
            Data = ((ulong)aligned << AlignedOffset) | (packed == 0 ? aligned.Width : (packed & PackedMask));
        }

        public ulong Packed
        {
            [MethodImpl(Inline)]
            get => Data & PackedMask;
        }

        public Aligned Aligned
        {
            [MethodImpl(Inline)]
            get => (Aligned)((Data & AlignedMask) >> AlignedOffset);
        }

        public bool IsAligned
        {
            [MethodImpl(Inline)]
            get => Aligned.IsDefined;
        }

        public string Format()
            => Packed.ToString();

        public override string ToString()
            => Format();

        public int CompareTo(DataSize src)
            => Packed.CompareTo(src);

        [MethodImpl(Inline)]
        public static implicit operator DataSize(ulong src)
            => new DataSize(src);
    }
}