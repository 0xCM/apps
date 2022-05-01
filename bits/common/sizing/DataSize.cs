//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(StorageWidth)]
    public readonly record struct DataSize : IComparable<DataSize>
    {
        public const uint StorageWidth = 64;

        const byte AlignedOffset = 56;

        const ulong AlignedMask = 0xFFul << AlignedOffset;

        const ulong PackedMask = ~AlignedMask;

        readonly ulong Data;

        [MethodImpl(Inline)]
        public DataSize(BitWidth width)
        {
            AlignedWidth aligned = (ulong)width;
            Data = ((ulong)aligned << AlignedOffset) | (ulong)width & PackedMask;
        }

        [MethodImpl(Inline)]
        public DataSize(AlignedWidth aligned, BitWidth packed)
        {
            Data = ((ulong)aligned << AlignedOffset) | (packed == 0 ? aligned.Value : (packed & PackedMask));
        }

        public ulong Packed
        {
            [MethodImpl(Inline)]
            get => Data & PackedMask;
        }

        public AlignedWidth Aligned
        {
            [MethodImpl(Inline)]
            get => (AlignedWidth)((Data & AlignedMask) >> AlignedOffset);
        }

        public bool IsAligned
        {
            [MethodImpl(Inline)]
            get => Aligned.IsDefined;
        }

        public string Format()
            => Packed.ToString();

        public string FormatSemantic(bool bracket = true)
            => bracket ? text.bracket(string.Format("{0}:{1}", Aligned, Packed)) : string.Format("{0}:{1}", Aligned, Packed);

        public override string ToString()
            => Format();

        public int CompareTo(DataSize src)
            => Packed.CompareTo(src);

        [MethodImpl(Inline)]
        public static implicit operator DataSize(ulong src)
            => new DataSize(src);
    }
}