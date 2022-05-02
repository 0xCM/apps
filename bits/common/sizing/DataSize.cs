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
            => Format(4,4);

        public static string digits(byte index, byte n)
            => Chars.LBrace + $"{index}:D{n}" + Chars.RBrace;

        public string Format(byte pN, byte aN)
            => string.Format(string.Format("{0}:{1}", digits(0,pN), digits(1, aN)), Packed, Aligned);

        public string Format(byte pN, byte aN, bool bracket)
            => bracket ? text.bracket(Format(pN, aN)) : Format(pN, aN);

        public string Format(bool bracket)
            => bracket ? text.bracket(Format()) : Format();

        public override string ToString()
            => Format();

        public int CompareTo(DataSize src)
            => Packed.CompareTo(src.Packed);

        public static DataSize Empty => default;
    }
}