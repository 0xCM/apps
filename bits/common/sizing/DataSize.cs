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

        readonly ulong Data;

        public DataSize(uint packed, uint aligned)
        {
            Data = Bitfields.join(packed, aligned);
        }

        public uint Packed
        {
            [MethodImpl(Inline)]
            get => (uint)Data;
        }

        public uint Aligned
        {
            [MethodImpl(Inline)]
            get => (uint)(Data >> 32);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public string Format()
            => Packed.ToString();

        public string FormatSemantic(bool bracket = true)
            => bracket ? text.bracket(string.Format("{0}:{1}", Aligned, Packed)) : string.Format("{0}:{1}", Aligned, Packed);

        public override string ToString()
            => Format();

        public int CompareTo(DataSize src)
            => Packed.CompareTo(src);

        public static DataSize Empty => default;
    }
}